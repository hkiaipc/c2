///////////////////////////////////////////////////////////
//  SerialCommuniType.cs
//  Implementation of the Class SerialCommuniType
//  Generated by Enterprise Architect
//  Created on:      08-七月-2009 11:33:58
//  Original author: LiZhL
///////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Xdgk.Communi
{

    /// <summary>
    /// 串口通讯类型
    /// </summary>
    public class SerialCommuniType : CommuniType
    {
        #region Members

        #endregion // Members

        public override string ToXml()
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="com"></param>
        ///// <param name="baud"></param>
        //public SerialCommuniType(int com, int baud)
        //    : base(CommuniTypeOption.SerialCommuni)
        //{
        //    if (com < 1 || com > 10)
        //        throw new ArgumentOutOfRangeException("Com Out" + com.ToString());
        //    m_Com = com;
        //    m_Baud = baud;
        //}

        public SerialCommuniType(int comm)
            : this( comm, "9600,n,8,1")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comm"></param>
        /// <param name="settings"></param>
        public SerialCommuniType(int comm, string settings)
        {
            this.Comm = comm;
            this.Settings = settings;
            throw new NotImplementedException("serialcommunitype");
        }
        #region Properties
        ///// <summary>
        ///// 
        ///// </summary>
        //public byte CommPort
        //{
        //    get {
        //        string pn = m_sp.PortName;
        //        pn = pn.ToUpper().Replace("COM","");
        //        return byte.Parse(pn);
        //    }
        //    set { m_sp.PortName = "COM" + value; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public int CommBaud
        //{
        //    get { return m_sp.BaudRate; }
        //    set { m_sp.BaudRate = value; }
        //}
        /// <summary>
        /// 获取或设置串口号
        /// </summary>
        public int Comm
        {
            get
            {
                return _com;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Comm", value, "must > 0");
                _com = value;
            }
        }private int _com;

        ///// <summary>
        ///// 获取或设置波特率
        ///// </summary>
        //public int Baud
        //{
        //    get { return m_Baud; }
        //    set { m_Baud = value; }
        //}

        /// <summary>
        /// 
        /// </summary>
        public string Settings
        {
            get { return _settings; }
            set
            {
                if (!CheckSettings(value))
                    throw new ArgumentException("Invalid Settings: " + value, "Settings");
                _settings = value; 
            }
        } private string _settings;
        #endregion // Properties

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool CheckSettings(string val)
        {
            return true;
        }

    }//end SerialCommuniType
}