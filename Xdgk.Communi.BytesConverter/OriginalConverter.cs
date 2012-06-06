using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi.Interface;

namespace Xdgk.Communi
{

    /// <summary>
    /// byte[]的原始转换
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class OriginalConverter : IBytesConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(object obj)
        {
            return (byte[])obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public object ConvertToObject(byte[] bytes)
        {
            return bytes;
        }
    }
}
