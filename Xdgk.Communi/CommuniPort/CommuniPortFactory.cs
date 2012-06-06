using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets ;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class CommuniPortFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public SerialCommuniPort CreateSerialCommuniPort(SerialCommuniType serialCT)
        {
            if (serialCT == null)
                throw new ArgumentNullException("serialCT");

            SerialCommuniPort p = new SerialCommuniPort(serialCT.PortName,
                serialCT.BaudRate, serialCT.Parity, serialCT.DataBits, serialCT.StopBits);
            return p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public SocketCommuniPort CreateSocketCommuniPort(Socket socket )
        {
            if (socket == null)
                throw new ArgumentNullException("socket");

            SocketCommuniPort scp = new SocketCommuniPort(socket);
            return scp;
        }

        //public SerialCommuniType 
    }
}
