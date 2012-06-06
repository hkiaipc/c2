using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class CommuniPortState
    {
        public CommuniPortState(CommuniPort cp)
        {
            if (cp == null)
                throw new ArgumentNullException("cp");
            this._communiPort = cp;

            this.DT = DateTime.Now;
        }

        #region DT
        /// <summary>
        /// 进入时间
        /// </summary>
        public DateTime DT
        {
            get { return _dT; }
            set { _dT = value; }
        } private DateTime _dT;
        #endregion //DT

        /// <summary>
        /// 
        /// </summary>
        public CommuniPort CommuniPort
        {
            get { return _communiPort; }
            set { _communiPort = value; }
        } private CommuniPort _communiPort;

        /// <summary>
        /// 
        /// </summary>
        abstract public bool IsReady
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        abstract public void Prepare();
    }
}
