using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Communi;
using Xdgk.Common;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDeviceItem : NUnit.UiKit.SettingsDialogBase, IDeviceForm
    {
        #region IsAdd
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAdd()
        {
            return ADEState == ADEState.Add;
        }
        #endregion //IsAdd


        #region IsEdit
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEdit()
        {
            return ADEState == ADEState.Edit;
        }
        #endregion //IsEdit


        #region Station
        /// <summary>
        /// 
        /// </summary>
        public Station Station
        {
            get { return this._station; }
            set 
            {
                if (this._station != value)
                {
                    this._station = value;
                    if (this._station != null)
                    {
                        this.txtOwnerStatoin.Text= _station.Name;
                    }
                }
            }
        } private Station _station;
        #endregion //Station


        #region DeviceDefine
        /// <summary>
        /// 
        /// </summary>
        public DeviceDefine DeviceDefine
        {
            get { return _deviceDefine; }
            set 
            {
                if (_deviceDefine != value)
                {
                    _deviceDefine = value;
                    if (_deviceDefine != null)
                    {
                        this.txtDeviceType.Text = _deviceDefine.Text;
                    }
                }
            }
        } private DeviceDefine _deviceDefine;
        #endregion //DeviceDefine


        #region Device
        /// <summary>
        /// 
        /// </summary>
        public Device Device
        {
            get { return _device; }
            set 
            {
                if (_device != value)
                {
                    _device = value;
                    if (_device != null)
                    {
                        this.Station = _device.Station;
                        this.DeviceDefine = _device.DeviceDefine;
                        this.txtName.Text = _device.Name;
                        this.Address = _device.Address;
                        this.Remark = _device.Remark;
                    }
                }
            }
        } private Device _device;
        #endregion //Device

        #region frmDeviceItem
        /// <summary>
        /// 
        /// </summary>
        public frmDeviceItem ()
        {
            InitializeComponent();
            this.Text = strings.Device;
        }
        #endregion //frmDeviceItem

        //#region frmDeviceItem
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="st"></param>
        //public frmDeviceItem(Station st, string deviceType)
        //    : this()
        //{
        //    if (st == null)
        //        throw new ArgumentNullException("st");
        //    this.Station = st;
        //    //this.DeviceType= deviceType;
        //    this._adeState = ADEState.Add;

        //    this.txtOwnerStatoin.Text = Station.Name;

        //    //string deviceText = YeHeCommuniServerApp.Default.CommuniSoft.OperaFactory.DeviceDefineCollection.GetDeviceText(deviceType);
        //    //string deviceText = YeHeCommuniServerApp.Default.CommuniSoft.DeviceDefineManager.DeviceDefineCollection.GetDeviceText(deviceType);
        //    //this.txtDeviceType.Text = deviceText;
        //}
        //#endregion //frmDeviceItem

        //#region frmDeviceItem
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="device"></param>
        //public frmDeviceItem(Device device)
        //    : this()
        //{
            
        //    if (device == null)
        //    {
        //        throw new ArgumentNullException("device");
        //    }
        //    this._device = device;
        //    //this.DeviceType = device.DeviceType;
        //    //this._station = (CZGRStation)device.Station;
        //    this.Station = device.Station;

        //    this.txtOwnerStatoin.Text = this._device.Station.Name;
        //    this.txtDeviceType.Text = this._device.Text;
        //    this.txtName.Text = this._device.Name;
        //    this.txtRemark.Text = this._device.Remark;
        //    //this.cmbDeviceType.Text = CZGRCommon.DeviceTypes.GetText(_device.DeviceType);
        //    this.numDeviceAddress.Value = _device.Address;
        //    this._adeState = ADEState.Edit;
        //}
        //#endregion //frmDeviceItem

        #region Address
        /// <summary>
        /// 
        /// </summary>
        public Int64  Address
        {
            get { return (Int64)this.numDeviceAddress.Value; }
            set { this.numDeviceAddress.Value = value; }
        }
        #endregion //Address



        #region DeviceName
        /// <summary>
        /// 
        /// </summary>
        public string DeviceName
        {
            get { return this.txtName.Text.Trim(); }
            set { this.txtName.Text = value; }
        }
        #endregion //DeviceName


        #region Remark
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return this.txtRemark.Text.Trim(); }
            set { this.txtRemark.Text = value; }
        }
        #endregion //Remark

        #region ExistAddress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        //public bool ExistAddress(string deviceType, int address)
        public bool ExistAddress(string deviceType, Int64 address)
        {
            return this.ExistAddress(deviceType, address, null);
        }
        /// <summary>
        /// 检查集合中是否已经存在相同地址
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool ExistAddress(string deviceType, Int64 address, Device ignore)
        {
            return this.Station.Devices.ExistAddress(deviceType, address, ignore);
        }
        #endregion //ExistAddress


        #region frmDeviceItem_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDeviceItem_Load(object sender, EventArgs e)
        {
            this.UpdateFormText();
        }
        #endregion //frmDeviceItem_Load

        #region VerifyAddress
        /// <summary>
        /// 
        /// </summary>
        public bool VerifyAddress()
        {
            // TODO: 
            //
            if (ExistAddress(this.DeviceDefine.DeviceType, this.Address, this.Device))
            {
                // TODO: deviceTypeText
                //
                string deviceTypeText = "CZGRCommon.DeviceTypes.GetText(this.DeviceType)";

                string msg = string.Format(strings.ExistAddress,
                    deviceTypeText, this.Address);
                NUnit.UiKit.UserMessage.DisplayFailure(msg);
                return false;
            }
            return true;
        }
        #endregion //VerifyAddress

        /// <summary>
        /// 
        /// </summary>
        public void UpdateFormText()
        {
            this.Text += " - " + GetADEStateText(this.ADEState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDEState"></param>
        /// <returns></returns>
        private string GetADEStateText(ADEState aDEState)
        {
            if (aDEState == ADEState.Add)
                return "增加";
            if (aDEState == ADEState.Edit)
                return "修改";
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public ADEState ADEState
        {
            get { return _adeState; }
        } private ADEState _adeState;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (VerifyAddress())
            {
                if (ADEState == ADEState.Edit)
                {
                    EditDevice();
                }
                else
                {
                    Device newDevice = new Device(this.DeviceDefine, this.txtName.Text, this.Address);
                    newDevice.Remark = this.Remark;
                    _device = newDevice;

                    this.Station.Devices.Add(newDevice);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("已经存在相同地址");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void EditDevice()
        {
            this.Device.Name = this.txtName.Text.Trim();
            this.Device.Address = (Int64)this.numDeviceAddress.Value;
            this.Device.Remark = this.txtRemark.Text.Trim();
        }

        #region IDeviceForm 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <param name="dd"></param>
        public void InitForAdd(Station station, DeviceDefine dd)
        {
            if (station == null)
            {
                throw new ArgumentNullException("station");
            }

            if( dd == null )
            {
                throw new ArgumentNullException("dd");
            }

            this.Station = station;
            this.DeviceDefine = dd;
            this._adeState = ADEState.Add;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public void InitForEdit(Device device)
        {
            this.Device = device;
            this._adeState = ADEState.Edit;
        }
        #endregion
    }
}
