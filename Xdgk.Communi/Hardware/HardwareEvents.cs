using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void HardwareChangedEventHandler(object sender,
        HardwareChangedEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    public class HardwareChangedEventArgs : EventArgs 
    {
        /// <summary>
        /// is station? is device?
        /// </summary>
        public HardwareType HardwareType
        {
            get { return _hardwareType; }
            set { _hardwareType = value; }
        } private HardwareType _hardwareType;

        #region ChangedType
        /// <summary>
        /// 
        /// </summary>
        public HardwareChangedType ChangedType
        {
            get { return _changedType; }
            set { _changedType = value; }
        } private HardwareChangedType _changedType;
        #endregion //ChangedType

        #region 
        /// <summary>
        /// station or device
        /// </summary>
        public object ChangedHardware
        {
            get { return _changedHardware; }
            set { _changedHardware = value; }
        } private object _changedHardware;
        #endregion //

    }


    /// <summary>
    /// 
    /// </summary>
    public enum HardwareChangedType
    {
        Add,
        Edit,
        Delete,
    }


    /// <summary>
    /// 
    /// </summary>
    public enum HardwareType
    {
        /// <summary>
        /// 
        /// </summary>
        Station,

        /// <summary>
        /// 
        /// </summary>
        Device,
    }
}
