using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    public class IntConverter : Xdgk.Communi.Interface.IBytesConverter 
    {
        #region IBytesConverter 成员

        public object ConvertToObject(byte[] bytes)
        {
            return (int)bytes[0];
        }

        public byte[] ConvertToBytes(object obj)
        {
            byte b = Convert.ToByte(obj);
            return new byte[] { b };
        }

        #endregion
    }
}
