using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialCommuniPortReadyState : CommuniPortState 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialCP"></param>
        public SerialCommuniPortReadyState(SerialCommuniPort serialCP)
            : base(serialCP)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsReady
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Prepare()
        {
            // do nothing 
            //
        }
    }
}
