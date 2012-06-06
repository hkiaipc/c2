using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class UnDefineDeviceTypeCollection : Collection<string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public bool Exist(string deviceType)
        {
            foreach (string t in this)
            {
                bool b = StringHelper.Equal(t, deviceType);
                if (b)
                    return b;
            }
            return false;
        }
    }
}
