using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WcfRestDateJsonTestTool
{
    public partial class testForm : Form
    {
        public testForm()
        {
            InitializeComponent();
        }

        private void toWcfJsonDateTimeBtn_Click(object sender, EventArgs e)
        {
            //Create a stream to serialize the object to.  
            using (MemoryStream ms = new MemoryStream())
            {
                //DateTime datetimeToConvert;

                // Serializer the object to the stream.  
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DateTime));

                DateTime datetimeToConvert = GetDateTimeToConvert();

                serializer.WriteObject(ms, datetimeToConvert);
                byte[] json = ms.ToArray();

                string jsonString = Encoding.UTF8.GetString(json, 0, json.Length);

                wcfJsonDateTimeTBox.Text = jsonString;
            }

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            ////DateTime time = new DateTimeOffset(2017, 02, 10, 14, 33, 42, 123, TimeSpan.FromHours(-5)).UtcDateTime;
            //DateTime time = new DateTimeOffset(2017, 02, 10, 14, 33, 42, 123, TimeSpan.FromHours(-5)).LocalDateTime;
            //string jsonDate = javaScriptSerializer.Serialize(time);
            //jsonDateTBox.Text = jsonDate;
        }

        private void wcfJsonToDateTimeBtn_Click(object sender, EventArgs e)
        {
            string jsonString = string.Format(@"{0}", wcfJsonDateTimeTBox.Text.Trim());

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DateTime));
                DateTime dateTime = (DateTime)ser.ReadObject(ms);

                SetConvertedDateTime(dateTime);
            }

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //DateTime dateTime = javaScriptSerializer.Deserialize<DateTime>(string.Format(@"""{0}""", jsonDateTBox.Text.Trim()));
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            double offsetHours = DateTimeOffset.Now.Offset.TotalHours;
            timezoneTBox.Text = offsetHours.ToString();
            timezoneTBox2.Text = offsetHours.ToString();

            localNowBtn_Click(null, null);

            DateTime dateTime = DateTime.Now;
            dateTimeTBox2.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            milisecondTBox2.Text = dateTime.Millisecond.ToString();
        }

        private void localNowBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            SetConvertedDateTime(dateTime);
        }

        private void utcNowBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.UtcNow;

            SetConvertedDateTime(dateTime);
        }

        private void otherTimezoneToLocalTimeBtn_Click(object sender, EventArgs e)
        {
            DateTimeOffset inputDateTimeOffset = BuildSpecifiedTimezoneLocalTime();

            DateTime locaDateTime = inputDateTimeOffset.LocalDateTime;

            SetConvertedDateTime(locaDateTime);
        }

        private void otherTimezoneToUtcTimeBtn_Click(object sender, EventArgs e)
        {
            DateTimeOffset inputDateTimeOffset = BuildSpecifiedTimezoneLocalTime();

            DateTime utcDateTime = inputDateTimeOffset.UtcDateTime;

            SetConvertedDateTime(utcDateTime);
        }

        private DateTimeOffset BuildSpecifiedTimezoneLocalTime()
        {
            DateTime inputDateTime = DateTime.ParseExact(dateTimeTBox2.Text.Trim(), "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
            inputDateTime = inputDateTime.AddMilliseconds(Convert.ToDouble(milisecondTBox2.Text.Trim()));

            DateTimeOffset inputDateTimeOffset = new DateTimeOffset(inputDateTime.Year, inputDateTime.Month, inputDateTime.Day,
                inputDateTime.Hour, inputDateTime.Minute, inputDateTime.Second, inputDateTime.Millisecond,
                TimeSpan.FromHours(Convert.ToDouble(timezoneTBox2.Text.Trim())));

            //datetimeToConvert = new DateTimeOffset(2017, 02, 10, 14, 33, 42, 123, TimeSpan.FromHours(-5)).UtcDateTime;
            //datetimeToConvert = new DateTimeOffset(2017, 02, 10, 14, 33, 42, 123, TimeSpan.FromHours(-5)).LocalDateTime;

            return inputDateTimeOffset;
        }

        private void toLocalBtn_Click(object sender, EventArgs e)
        {
            DateTimeKind kind = (DateTimeKind)Enum.Parse(typeof(DateTimeKind), kindCBox.SelectedItem.ToString());
            if (kind == DateTimeKind.Utc)
            {
                DateTime inputDateTime = DateTime.ParseExact(dateTimeTBox.Text.Trim(), "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                inputDateTime = inputDateTime.AddMilliseconds(Convert.ToDouble(milisecondTBox.Text.Trim()));

                DateTime localDateTime = inputDateTime.ToLocalTime();

                SetConvertedDateTime(localDateTime);
            }
            else
            {
                MessageBox.Show("Only UTC time can be converted to local time.");
            }
        }

        private void toUtcBtn_Click(object sender, EventArgs e)
        {
            DateTimeKind kind = (DateTimeKind)Enum.Parse(typeof(DateTimeKind), kindCBox.SelectedItem.ToString());
            if (kind != DateTimeKind.Utc)
            {
                DateTime inputDateTime = DateTime.ParseExact(dateTimeTBox.Text.Trim(), "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                inputDateTime = inputDateTime.AddMilliseconds(Convert.ToDouble(milisecondTBox.Text.Trim()));

                DateTime utcDateTime = inputDateTime.ToUniversalTime();

                SetConvertedDateTime(utcDateTime);

            }
            else
            {
                MessageBox.Show("Already UTC time.");
            }
        }

        private DateTime GetDateTimeToConvert()
        {
            DateTimeKind kind = (DateTimeKind)Enum.Parse(typeof(DateTimeKind), kindCBox.SelectedItem.ToString());
            DateTime inputDateTimeUnspecifiedKind = DateTime.ParseExact(dateTimeTBox.Text.Trim(), "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
            inputDateTimeUnspecifiedKind = inputDateTimeUnspecifiedKind.AddMilliseconds(Convert.ToDouble(milisecondTBox.Text.Trim()));
            DateTime datetimeToConvert = DateTime.SpecifyKind(inputDateTimeUnspecifiedKind, kind);

            return datetimeToConvert;
        }

        private void SetConvertedDateTime(DateTime dateTime)
        {
            dateTimeTBox.Text = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            milisecondTBox.Text = dateTime.Millisecond.ToString();
            kindCBox.SelectedItem = dateTime.Kind.ToString();

        }

        private void toWebApiJsonBtn_Click(object sender, EventArgs e)
        {
            DateTime datetimeToConvert = GetDateTimeToConvert();

            string jsonDateTime = JsonConvert.SerializeObject(datetimeToConvert);

            webApiJsonDateTimeTBox.Text = jsonDateTime;
        }

        private void webApiJsonToDateTimeBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTime = JsonConvert.DeserializeObject<DateTime>(webApiJsonDateTimeTBox.Text.Trim());

            SetConvertedDateTime(dateTime);
        }

    }
}
