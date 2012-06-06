using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class HardwareUI
    {
        /// <summary>
        /// 
        /// </summary>
        public HardwareUI()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hardwareManager"></param>
        public HardwareUI(HardwareManager hardwareManager)
        {
            if (hardwareManager == null)
            {
                throw new ArgumentNullException("hardwareManager");
            }
            this.HardwareManager = hardwareManager;
        }

        #region HardwareManager
        /// <summary>
        /// 
        /// </summary>
        public HardwareManager HardwareManager
        {
            get { return _hardwareManager; }
            set { _hardwareManager = value; }
        } private HardwareManager _hardwareManager;
        #endregion //HardwareManager


        /// <summary>
        /// 
        /// </summary>
        public DialogResult AddStation()
        {
            if (HardwareManager == null)
            {
                throw new InvalidOperationException("HardwareManager == null");
            }
            IStationForm f = GetStationForm();
            f.InitForAdd(this.HardwareManager.Stations);

            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                HardwareManager.HardwareChanged(HardwareType.Station, f.Station,
                    HardwareChangedType.Add);
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public DialogResult EditStation(Station st)
        {
            if (HardwareManager == null)
            {
                throw new InvalidOperationException("HardwareManager == null");
            }
            IStationForm f = GetStationForm();
            f.InitForEdit(st);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //CommuniSoftFactory.HardwareBuilder.EditStation(st);
                HardwareManager.HardwareChanged(HardwareType.Station, f.Station,
                    HardwareChangedType.Edit);
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public DialogResult DeleteStation(Station st)
        {
            DialogResult dr = NUnit.UiKit.UserMessage.Ask("delete station?");
            if (dr == DialogResult.OK)
            {
                // TODO: delete station
                //
                HardwareManager.HardwareChanged(HardwareType.Station, st, HardwareChangedType.Delete);
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        virtual protected IStationForm GetStationForm()
        {
            frmStationItem f = new frmStationItem();
            return f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerStation"></param>
        /// <returns></returns>
        public DialogResult AddDevice(Station ownerStation)
        {
            if (ownerStation == null)
            {
                throw new ArgumentNullException("ownerStation");
            }

            DeviceDefine dd = GetDeviceDefine();
            if (dd == null)
            {
                return DialogResult.Cancel;
            }

            IDeviceForm f = GetDeviceForm(dd);

            f.InitForAdd(ownerStation, dd);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                HardwareManager.HardwareChanged(HardwareType.Device,
                    f.Device, HardwareChangedType.Add);
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DeviceDefine GetDeviceDefine()
        {
            frmDeviceSelect f = new frmDeviceSelect();
            DialogResult dr = f.ShowDialog ();

            if (dr == DialogResult.OK)
            {
                return f.DeviceDefine;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public DialogResult EditDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException("device");
            }

            DeviceDefine dd = device.DeviceDefine;
            IDeviceForm f = GetDeviceForm(dd);
            f.InitForEdit(device);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                HardwareManager.HardwareChanged(HardwareType.Device,
                    device, HardwareChangedType.Edit);
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public DialogResult DeleteDevice(Device device)
        {
            DialogResult dr = NUnit.UiKit.UserMessage.Ask("delete device?");
            if (dr == DialogResult.OK)
            {
                // TODO: delete device 
                //
                HardwareManager.HardwareChanged(HardwareType.Device, device, HardwareChangedType.Delete);
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        virtual protected IDeviceForm GetDeviceForm(DeviceDefine dd)
        {
            if (dd == null)
            {
                throw new ArgumentNullException("dd");
            }

            frmDeviceItem f = new frmDeviceItem();
            return f;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IStationForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerStationCollection"></param>
        void InitForAdd(StationCollection ownerStationCollection);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        void InitForEdit(Station station);

        /// <summary>
        /// 
        /// </summary>
        Station Station { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DialogResult ShowDialog();
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDeviceForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerStationCollection"></param>
        void InitForAdd(Station station, DeviceDefine dd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        void InitForEdit(Device device);

        /// <summary>
        /// 
        /// </summary>
        Device Device{ get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DialogResult ShowDialog();
    }
}
