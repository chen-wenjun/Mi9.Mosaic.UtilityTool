using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHardwareInfo
{
    public partial class WindowsHardwareInfoFrm : Form
    {
        public WindowsHardwareInfoFrm()
        {
            InitializeComponent();
        }

        private void loadInfoBtn_Click(object sender, EventArgs e)
        {
            InfoTBox.Clear();

            InfoTBox.Text = LoadHardwareInfo();
        }

        private string LoadHardwareInfo()
        {
            StringBuilder infoBuilder = new StringBuilder();
            infoBuilder.AppendLine(string.Format("Win32_Processor/UniqueId => {0}", FingerPrint.identifier("Win32_Processor", "UniqueId")));
            infoBuilder.AppendLine(string.Format("Win32_Processor/ProcessorId => {0}", FingerPrint.identifier("Win32_Processor", "ProcessorId")));
            infoBuilder.AppendLine(string.Format("Win32_Processor/Name => {0}", FingerPrint.identifier("Win32_Processor", "Name")));
            infoBuilder.AppendLine(string.Format("Win32_Processor/Manufacturer => {0}", FingerPrint.identifier("Win32_Processor", "Manufacturer")));
            infoBuilder.AppendLine(string.Format("Win32_Processor/MaxClockSpeed => {0}", FingerPrint.identifier("Win32_Processor", "MaxClockSpeed")));

            infoBuilder.AppendLine();

            infoBuilder.AppendLine(string.Format("Win32_BIOS/Manufacturer => {0}", FingerPrint.identifier("Win32_BIOS", "Manufacturer")));
            infoBuilder.AppendLine(string.Format("Win32_BIOS/SMBIOSBIOSVersion => {0}", FingerPrint.identifier("Win32_BIOS", "SMBIOSBIOSVersion")));
            infoBuilder.AppendLine(string.Format("Win32_BIOS/IdentificationCode => {0}", FingerPrint.identifier("Win32_BIOS", "IdentificationCode")));
            infoBuilder.AppendLine(string.Format("Win32_BIOS/SerialNumber => {0}", FingerPrint.identifier("Win32_BIOS", "SerialNumber")));
            infoBuilder.AppendLine(string.Format("Win32_BIOS/ReleaseDate => {0}", FingerPrint.identifier("Win32_BIOS", "ReleaseDate")));
            infoBuilder.AppendLine(string.Format("Win32_BIOS/Version => {0}", FingerPrint.identifier("Win32_BIOS", "Version")));

            infoBuilder.AppendLine();

            infoBuilder.AppendLine(string.Format("Win32_BaseBoard/Model => {0}", FingerPrint.identifier("Win32_BaseBoard", "Model")));
            infoBuilder.AppendLine(string.Format("Win32_BaseBoard/Manufacturer => {0}", FingerPrint.identifier("Win32_BaseBoard", "Manufacturer")));
            infoBuilder.AppendLine(string.Format("Win32_BaseBoard/Name => {0}", FingerPrint.identifier("Win32_BaseBoard", "Name")));
            infoBuilder.AppendLine(string.Format("Win32_BaseBoard/SerialNumber => {0}", FingerPrint.identifier("Win32_BaseBoard", "SerialNumber")));

            infoBuilder.AppendLine();

            infoBuilder.AppendLine(string.Format("Win32_VideoController/DriverVersion => {0}", FingerPrint.identifier("Win32_VideoController", "DriverVersion")));
            infoBuilder.AppendLine(string.Format("Win32_VideoController/Name => {0}", FingerPrint.identifier("Win32_VideoController", "Name")));

            return infoBuilder.ToString();

        }
    }
}
