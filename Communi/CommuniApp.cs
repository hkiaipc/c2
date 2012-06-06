using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using Xdgk.Common;

namespace Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class CommuniApp : App
    {
        /// <summary>
        /// 
        /// </summary>
        public CommuniSoft CommuniSoft
        {
            get
            {
                return CommuniSoftFactory.GetCommuniSoft();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Form MainForm
        {
            get
            {
                if (_frmMain == null)
                {
                    _frmMain = new frmMain();
                }
                return _frmMain;
            }
        } private frmMain _frmMain;
    }
}
