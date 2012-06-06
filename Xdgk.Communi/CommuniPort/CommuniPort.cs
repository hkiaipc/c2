using System;
using Xdgk.Common;

namespace Xdgk.Communi
{
    /// <summary>
    /// 通讯口基类
    /// </summary>
    public abstract class CommuniPort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        abstract public bool Write(byte[] bytes);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public byte[] Read();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        abstract public bool Match(CommuniType communiType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialPortSetting"></param>
        /// <returns></returns>
        abstract public bool MatchSerialPortSetting(SerialPortSetting serialPortSetting);


        #region CanOpen
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public bool CanOpen
        {
            get;
        }
        #endregion //CanOpen

        /// <summary>
        /// 
        /// </summary>
        abstract public void Open();


        #region IsOpened
        /// <summary>
        /// 
        /// </summary>
        abstract public bool IsOpened
        {
            get;
        }
        #endregion //IsOpened


        #region IsReady
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsReady
        {
            get
            {
                return this.CommuniPortState.IsReady;
            }
        }
        #endregion //IsReady

        /// <summary>
        /// 
        /// </summary>
        abstract public void Close ();


        #region SerialPortSetting
        /// <summary>
        /// 
        /// </summary>
        abstract public SerialPortSetting SerialPortSetting
        {
            get;
            set;
        }
        #endregion //SerialPortSetting


        #region CommuniPortState
        /// <summary>
        /// 
        /// </summary>
        public CommuniPortState CommuniPortState
        {
            get { return _communiPortState; }
            set { _communiPortState = value; }
        } private CommuniPortState _communiPortState;
        #endregion //CommuniPortState


        #region SerialPortSettingEnabled
        /// <summary>
        /// 
        /// </summary>
        abstract public bool SerialPortSettingEnabled
        {
            get;
            set;
        } 
        #endregion //SerialPortSettingEnabled


        private DateTime _occupyBeginDT;

        


        #region Occupy
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        public void Occupy(TimeSpan ts)
        {
            if (ts < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException("ts", ts, "must > TimeSpan.Zero");
            if (_occupy)
                throw new InvalidOperationException("cannot Occupy");

            _occupyBeginDT = DateTime.Now;
            _occupyTS = ts;
            _occupy = true;
        } private TimeSpan _occupyTS;
        #endregion //Occupy


        #region IsOccupy
        /// <summary>
        /// 获取该CommuniPort是够被占用标志
        /// </summary>
        public bool IsOccupy
        {
            get 
            {
                if (_occupy)
                {
                    TimeSpan ts = DateTime.Now - _occupyBeginDT;
                    if (ts >= _occupyTS || ts < TimeSpan.Zero)
                    {
                        _occupy = false;
                        return _occupy;
                    }
                    else
                    {
                        return true;
                    }
                }
                return _occupy;
            }
        } private bool _occupy = false;
        #endregion //IsOccupy



        #region Remove
        /// <summary>
        /// 从所属集合中删除该对象
        /// </summary>
        public virtual void Remove()
        {
            if (this.CommuniPorts != null)
            {
                this.CommuniPorts.Remove(this);
            }
        }
        #endregion //Remove


        #region Station
        /// <summary>
        /// 获取或设置与该CommuniPort相关的Station
        /// </summary>
        public Station Station
        {
            get { return _station; }
            set
            {
                if( _station != value )
                    _station = value;
            }
        } private Station _station;
        #endregion //Station


        #region CommuniPorts
        /// <summary>
        /// 获取或设置所属集合
        /// </summary>
        public CommuniPortCollection CommuniPorts
        {
            get { return _communiPorts; }
            set
            {
                if (this._communiPorts != value)
                {
                    _communiPorts = value;
                }
            }
        } private CommuniPortCollection _communiPorts;
        #endregion //CommuniPorts



        #region FilterCollection
        /// <summary>
        /// 
        /// </summary>
        public FilterCollection FilterCollection
        {
            get
            {
                if (_filterCollection == null)
                {
                    _filterCollection = new FilterCollection();
                }
                return _filterCollection;
            }
            set 
            {
                _filterCollection = value;
            }
        } private FilterCollection _filterCollection;
        #endregion //FilterCollection
    }
}
