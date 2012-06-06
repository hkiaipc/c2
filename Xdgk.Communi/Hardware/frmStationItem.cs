using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using Xdgk.Communi;
using System.Net;
//using NUnit.UiKit;

namespace Xdgk.Communi
{
    public partial class frmStationItem : NUnit.UiKit.SettingsDialogBase , IStationForm 
    {

        /// <summary>
        /// 
        /// </summary>
        public frmStationItem()
        {
            InitializeComponent();
            FillDiscriminateMode();
        }

        private StationCollection _stations;

        /// <summary>
        /// 获取新添加或正在编辑的站点
        /// </summary>
        public Station Station
        {
            get { return _station; }
            set
            {
                if (_station != value)
                {
                    _station = value;
                    if (_station != null)
                    {
                        SocketCommuniType socketct = this._station.CommuniType as SocketCommuniType;

                        this.txtStationName.Text = this._station.Name;
                        //this.numOrdinal.Value = this._station.DBStation.Ordinal;
                        this.txtRemark.Text = this._station.Description;
                        //this.txtStreet.Text = this._station.DBStation.Street;

                        if (socketct.DiscriminateMode == DiscriminateMode.ByIPAddress)
                        {
                            this.txtStationIP.Text = socketct.IPAddress.ToString();
                        }
                        this.numLocalPort.Value = socketct.LocalPort;
                        this.numRemotePort.Value = socketct.RemotePort;
                        this.cmbDiscriminateMode.SelectedValue = socketct.DiscriminateMode;
                    }
                }
            }
        } private Station _station;

        ///// <summary>
        ///// 
        ///// </summary>
        //public frmStationItem(StationCollection stations) 
        //    : this()
        //{
        //    _stations = stations; 
        //    // set init value
        //    //
        //    this.cmbDiscriminateMode.SelectedValue = DiscriminateMode.ByIPAddress;
        //    this._adeState = ADEState.Add;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="station"></param>
        //public frmStationItem(StationCollection stations, Station station) 
        //    : this()
        //{
        //    this._stations = stations;
        //    this._station = station;

        //    this.ADEState = ADEState.Edit;

        //    SocketCommuniType socketct = this._station.CommuniType as SocketCommuniType;

        //    this.txtStationName.Text = this._station.Name;
        //    //this.numOrdinal.Value = this._station.DBStation.Ordinal;
        //    this.txtRemark.Text = this._station.Description;
        //    //this.txtStreet.Text = this._station.DBStation.Street;

        //    if (socketct.DiscriminateMode == DiscriminateMode.ByIPAddress)
        //    {
        //        this.txtStationIP.Text = socketct.IPAddress.ToString();
        //    }
        //    this.numLocalPort.Value = socketct.LocalPort;
        //    this.numRemotePort.Value = socketct.RemotePort;
        //    this.cmbDiscriminateMode.SelectedValue = socketct.DiscriminateMode;
        //}

        /// <summary>
        /// 
        /// </summary>
        public ADEState ADEState
        {
            get { return _adeState; }
            protected set { _adeState = value; }
        } private ADEState _adeState;

        /// <summary>
        /// 
        /// </summary>
        private void FillDiscriminateMode()
        {

            this.cmbDiscriminateMode.DataSource = StationDiscriminateMode.Items;
            this.cmbDiscriminateMode.DisplayMember = "Text";
            this.cmbDiscriminateMode.ValueMember = "DiscriminateMode";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckIPAddress()
        {
            IPAddress ip;
            bool b = IPAddress.TryParse(this.txtStationIP.Text, out ip);
            if (!b)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.InvalidIPAddress);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketCT"></param>
        private void EditStation(SocketCommuniType socketCT)
        {
            string oldName = _station.Name;
            _station.Name = this.txtStationName.Text.Trim();
            _station.CommuniType = socketCT;
            _station.Description = this.txtRemark.Text;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketCT"></param>
        private void AddStation(SocketCommuniType socketCT)
        {
            string name = this.txtStationName.Text.Trim();
            string desc = this.txtRemark.Text.Trim();
            Station newStation = new Station(name, socketCT);
            newStation.Description = this.txtRemark.Text;

            _station = newStation;

            this._stations.Add(_station);
        }
        
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CreateSocketCommuniType( out SocketCommuniType ct)
        {
            DiscriminateMode dm = (DiscriminateMode)this.cmbDiscriminateMode.SelectedValue;
            ct = null;
            switch (dm)
            {
                case DiscriminateMode.ByIPAddress :
                    bool b = CheckIPAddress();
                    if (!b)
                        return false;
                    IPAddress ip = GetIPAddress();
                    ct = new SocketCommuniType(ip);
                    break;

                case DiscriminateMode.ByLocalPort:
                    int lp = GetLocalPort();
                    ct = new SocketCommuniType(dm, lp);
                    break; 

                case DiscriminateMode.ByRemotePort:
                    int rp = GetRemotePort();
                    ct = new SocketCommuniType(dm, rp);
                    break;

                default:
                    throw new NotImplementedException("DiscriminateMode: " + dm);
            }

            return true; ;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IPAddress GetIPAddress()
        {
            return IPAddress.Parse(this.txtStationIP.Text);
        }


        /// <summary>
        /// 
        /// </summary>
        private int GetLocalPort()
        {
            return (int)this.numLocalPort.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetRemotePort()
        {
            return (int)this.numRemotePort.Value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckName()
        {
            string name = this.txtStationName.Text.Trim();
            if (name.Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.StationNameCanNotEmpty);
                return false;
            }

            bool b = _stations.ExistName(name, _station);
            if (b)
            {
                string msg = string.Format(strings.ExistStationName, this.txtStationName.Text);
                NUnit.UiKit.UserMessage.DisplayFailure(msg);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStationItem_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dm"></param>
        private void VisiblePanel(DiscriminateMode dm)
        {
            panelByIPAddress.Visible = dm == DiscriminateMode.ByIPAddress;
            panelByLocalPort.Visible = dm == DiscriminateMode.ByLocalPort;
            panelBylRemotePort.Visible = dm == DiscriminateMode.ByRemotePort;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDiscriminateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Xdgk.Common.NameValueCollection 
            object obj = this.cmbDiscriminateMode.SelectedItem;
            StationDiscriminateMode.Item item = obj as StationDiscriminateMode.Item;
            DiscriminateMode dm = item.DiscriminateMode;
            VisiblePanel(dm);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //private bool CheckName()
        //{
        //    string name = this.txtStationName.Text.Trim();
        //    if (name.Length == 0)
        //    {
        //        NUnit.UiKit.UserMessage.DisplayFailure(strings.StationNameCanNotEmpty);
        //        return false;
        //    }

        //    bool b = _stations.ExistName(name, _station);
        //    if (b)
        //    {
        //        string msg = string.Format(strings.ExistStationName, this.txtStationName.Text);
        //        NUnit.UiKit.UserMessage.DisplayFailure(msg);
        //        return false;
        //    }

        //    return true;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!CheckName())
                return;
            SocketCommuniType socketCT;
            bool b = CreateSocketCommuniType(out socketCT);
            if (!b)
                return;

            if (_station == null)
            {
                AddStation(socketCT);
            }
            else
            {
                EditStation(socketCT);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region IStationForm 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerStationCollection"></param>
        public void InitForAdd(StationCollection ownerStationCollection)
        {
            this._stations = ownerStationCollection;
            this._adeState = ADEState.Add;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public void InitForEdit(Station station)
        {
            this._stations = station.StationCollection;
            this.Station = station;
            this._adeState = ADEState.Edit;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    internal class StationDiscriminateMode
    {
        public class Item
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="dm"></param>
            /// <param name="text"></param>
            public Item(DiscriminateMode dm, string text)
            {
                this._discriminateMode = dm;
                this._text = text;
            }

            /// <summary>
            /// 
            /// </summary>
            public DiscriminateMode DiscriminateMode
            {
                get { return _discriminateMode; }
            } private DiscriminateMode _discriminateMode;

            /// <summary>
            /// 
            /// </summary>
            public string Text
            {
                get { return _text; }
            } private string _text;
        }

        /// <summary>
        /// 
        /// </summary>
        static public Item[] Items
        {
            get { return s_items; }
        }

        /// <summary>
        /// 
        /// </summary>
        static private Item[] s_items = new Item[] 
        {
            new Item(DiscriminateMode.ByIPAddress, strings.ByIP ),
            new Item(DiscriminateMode.ByLocalPort, strings.ByLocalPort ),
            new Item (DiscriminateMode.ByRemotePort, strings.ByRemotePort )
        };
    }

}
