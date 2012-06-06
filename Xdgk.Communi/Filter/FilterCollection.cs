using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterCollection : Collection<Filter>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public byte[] Filt(byte[] source)
        {
            if (this.Count == 0)
            {
                return source;
            }

            string temp = (string)HexStringConverter.Default.ConvertToObject(source);
            foreach (Filter f in this)
            {
                temp = f.Filt(temp);
            }
            byte[] bs = (byte[])HexStringConverter.Default.ConvertToBytes(temp);
            return bs;
        }
    }
}
