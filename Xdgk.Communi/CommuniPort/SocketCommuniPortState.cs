using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class SocketCommuniPortConnectedState : CommuniPortState 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socketCP"></param>
        public SocketCommuniPortConnectedState(SocketCommuniPort socketCP)
            : base(socketCP)
        {
        }

        
        /// <summary>
        /// 
        /// </summary>
        public override bool IsReady
        {
            get
            {
                if (!this.CommuniPort.IsOpened)
                    return false;

                if (!this.CommuniPort.SerialPortSettingEnabled)
                    return true;

                bool b = (this.CommuniPort.SerialPortSetting != null);
                return b;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Prepare()
        {
            //throw new NotImplementedException();
        }
    }
}
