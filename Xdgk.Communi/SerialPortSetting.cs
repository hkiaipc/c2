using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace Xdgk.Communi
{
        /// <summary>
        /// 
        /// </summary>
        public class SerialPortSetting
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="bardRate"></param>
            /// <param name="parity"></param>
            /// <param name="dataBits"></param>
            /// <param name="stopBits"></param>
            public SerialPortSetting(int baudRate, Parity parity, int dataBits, StopBits stopBits)
            {
                this.BaudRate = baudRate;
                this.Parity = parity;
                this.DataBits = dataBits;
                this.StopBits = stopBits;
            }

            #region BaudRate
            /// <summary>
            /// 
            /// </summary>
            public int BaudRate
            {
                get { return _baudRate; }
                set { _baudRate = value; }
            } private int _baudRate;
            #endregion //BaudRate

            #region StopBits
            /// <summary>
            /// 
            /// </summary>
            public StopBits StopBits
            {
                get { return _stopBits; }
                set { _stopBits = value; }
            } private StopBits _stopBits;
            #endregion //StopBits

            #region Parity
            /// <summary>
            /// 
            /// </summary>
            public Parity Parity
            {
                get { return _parity; }
                set { _parity = value; }
            } private Parity _parity;
            #endregion //Parity

            #region DataBits
            /// <summary>
            /// 
            /// </summary>
            public int DataBits
            {
                get { return _dataBits; }
                set { _dataBits = value; }
            } private int _dataBits;
            #endregion //DataBits
        }
}
