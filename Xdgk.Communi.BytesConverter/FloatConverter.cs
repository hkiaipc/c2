using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 提供float到byte[]之间的转换
    /// </summary>
    public class FloatConverter : Xdgk.Communi.Interface.IBytesConverter
    {
        #region IBytesConverter 成员
        public object ConvertToObject(byte[] bytes)
        {
            return BitConverter.ToSingle(bytes, 0);
        }

        public byte[] ConvertToBytes(object obj)
        {
            float f = Convert.ToSingle(obj);
            return BitConverter.GetBytes(f);
        }

        #endregion
    }
}
