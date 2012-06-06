using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xdgk.Communi.Builder;

namespace Xdgk.Communi
{

    /// <summary>
    /// 
    /// </summary>
    public class HardwareManager
    {
        
        #region HardwareManager
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        public HardwareManager(CommuniSoft soft)
        {
            if (soft == null)
                throw new ArgumentNullException("communiSoft");
            this._communiSoft = soft;
        }
        #endregion //HardwareManager


        #region CommuniSoft
        /// <summary>
        /// 
        /// </summary>
        public CommuniSoft CommuniSoft
        {
            get { return _communiSoft; }
        } private CommuniSoft _communiSoft;
        #endregion //CommuniSoft


        #region GetStation
        /// <summary>
        /// 获取指定名称的站Station, 如不存在返回null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Station GetStation(string name)
        {
            name = name.Trim();
            foreach (Station st in this.Stations)
            {
                if (string.Compare(st.Name, name, true) == 0)
                    return st;
            }
            return null;
        }
        #endregion //GetStation


        
        /// <summary>
        /// 根据communiPort查找Station, 如找不到返回null
        /// </summary>
        /// <param name="communiPort"></param>
        /// <returns></returns>
        public Station FindStation(CommuniPort communiPort)
        {
            foreach (Station st in this.Stations)
            {
                if (communiPort.Match(st.CommuniType))
                {
                    return st;
                }
            }
            return null;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="communiPort"></param>
        ///// <returns></returns>
        //public Station AssocCommuniPort(CommuniPort communiPort)
        //{
        //    if (communiPort == null)
        //        throw new ArgumentNullException("communiPort");
        //    foreach (Station st in this.Stations)
        //    {
        //        if (communiPort.Match(st.CommuniType))
        //        {
        //            st.CommuniPort = communiPort;
        //            return st;
        //        }
        //    }
        //    return null;
        //}

        #region GetStation
        /// <summary>
        /// 获取device相关的station
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public Station GetStation(Device device)
        {
            //foreach (Station st in this.Stations)
            //{
            //    if( st.Devices.Contains(device) )
            //    {
            //        return st;
            //    }
            //}
            //return null;
            return device.Station;
        }
        #endregion //GetStation


        #region Stations
        /// <summary>
        /// 
        /// </summary>
        public StationCollection Stations
        {
            get
            {
                if (m_StationCollection == null)
                    m_StationCollection = new StationCollection(this);
                return m_StationCollection;
            }
            set { m_StationCollection = value; }
        }private StationCollection m_StationCollection;
        #endregion //Stations

        /// <summary>
        /// 
        /// </summary>
        public event HardwareChangedEventHandler HardwareChangedEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hardwareType"></param>
        /// <param name="changedHardware"></param>
        /// <param name="changedType"></param>
        public void HardwareChanged(HardwareType hardwareType, object changedHardware, HardwareChangedType changedType)
        {
            //HardwareBuilderBase build = CommuniSoftFactory.HardwareBuilder;
            DBHardwareBuilderBase build = CommuniSoftFactory.HardwareBuilder as DBHardwareBuilderBase;
            Debug.Assert(build != null, "CommuniSoftFactory.HardwareBuilder is not DBHardwareBuilderBase");

            if (hardwareType == HardwareType.Station)
            {
                Station station = changedHardware as Station;
                switch (changedType)
                {
                    case HardwareChangedType.Add:
                        build.AddStation(station);
                        break;

                    case HardwareChangedType.Edit :
                        build.EditStation(station);
                        break;

                    case HardwareChangedType.Delete :
                        // TODO: delete station
                        //
                        break;
                }
            }
            else if (hardwareType == HardwareType.Device)
            {
                Device device = changedHardware as Device;
                switch (changedType)
                {
                    case HardwareChangedType.Add:
                        build.AddDevice(device);
                        break;

                    case HardwareChangedType.Edit:
                        build.EditDevice(device);
                        break;

                    case HardwareChangedType.Delete:
                        // TODO: delete device
                        //
                        break;
                }
            }

            HardwareChangedEventArgs e = new HardwareChangedEventArgs();
            e.HardwareType = hardwareType;
            e.ChangedHardware = changedHardware;
            e.ChangedType = changedType;
            OnHardwareChanged(e);
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnHardwareChanged(HardwareChangedEventArgs e)
        {
            if (HardwareChangedEvent != null)
            {
                HardwareChangedEvent(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public HardwareUI HardwareUI
        {
            get 
            {
                if (_hardwareUI == null)
                {
                    _hardwareUI = new HardwareUI(this);
                }
                return _hardwareUI; 
            }
            set 
            {
                if (_hardwareUI != null)
                {
                    _hardwareUI = value;
                    if (_hardwareUI != null)
                    {
                        _hardwareUI.HardwareManager = this;
                    }
                }
            }
        } private HardwareUI _hardwareUI;
    }
}
