using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi.Interface;

    //public class BCDConvert
    //{
    //    private BCDConvert()
    //    {
    //    }

    //    static public int DecToBCD( int value )
    //    {
    //        return Convert.ToInt32( value.ToString(), 16 );
    //    }

    //    static public int BCDToDec( int value )
    //    {
    //        return Convert.ToInt32( value.ToString("X"), 10 );
    //    }
    //}

namespace Xdgk.Communi
{
    /// <summary>
    /// 提供BCD转换
    /// </summary>
    public class BCDConverter : IBytesConverter
    {
        #region IBytesConverter 成员
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public object ConvertToObject(byte b)
        {
            return Convert.ToInt32( b.ToString("X"), 10 );
        }

        /// <summary>
        /// 将bytes的第一个字节转换为十进制数字
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>int</returns>
        public object ConvertToObject(byte[] bytes)
        {
            byte value = bytes[0];
            return ConvertToObject(value);
        }

        /// <summary>
        /// 将obj转换为BCD码
        /// </summary>
        /// <param name="obj">int</param>
        /// <returns></returns>
        public byte[] ConvertToBytes(object obj)
        {
            int value = Convert.ToInt32(obj);
            if (value < 0 || value > 99)
                throw new ArgumentOutOfRangeException("obj must in [0, 99]");

            byte b = (byte)Convert.ToInt32(value.ToString(), 16);
            return new byte[] { b };
        }

        #endregion
    }
}
