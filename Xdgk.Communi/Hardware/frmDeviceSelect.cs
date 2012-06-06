using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Communi;

namespace Xdgk.Communi
{
    public partial class frmDeviceSelect : NUnit.UiKit.SettingsDialogBase 
    {
        /// <summary>
        /// 
        /// </summary>
        public frmDeviceSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDeviceSelect_Load(object sender, EventArgs e)
        {
            FillDeviceType();
        }

        /// <summary>
        /// 
        /// </summary>
        private CommuniSoft Soft
        {
            get { return CommuniSoftFactory.GetCommuniSoft(); }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillDeviceType()
        {
            this.lstDeviceType.Items.Clear();
            this.lstDeviceType.DataSource = this.Soft.DeviceDefineManager.DeviceDefineCollection;
            this.lstDeviceType.DisplayMember = "Text";
            this.lstDeviceType.ValueMember = "DeviceType";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            object selObj = this.lstDeviceType.SelectedItem; 
            if( selObj == null)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.PleaseSelectDeviceType);
                return;
            }
            this.DeviceDefine = selObj as DeviceDefine;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// 获取或设置选中的设备类型
        /// </summary>
        public DeviceDefine DeviceDefine
        {
            get { return _deviceDefine; }
            set { _deviceDefine = value; }
        } private DeviceDefine _deviceDefine;
    }
}
