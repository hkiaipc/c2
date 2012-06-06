using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xdgk.Common;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class Filter : ObjectBase 
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get 
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name; 
            }
            set { _name = value; }
        } private string _name;

        /// <summary>
        /// 
        /// </summary>
        public string Pattern
        {
            get
            {
                if (_pattern == null)
                {
                    _pattern = string.Empty;
                }
                return _pattern;
            }
            set { _pattern = value; }
        } private string _pattern;

        Regex _regex;
        RegexOptions _options = RegexOptions.IgnoreCase;
        string _replaceString = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        public Filter(string pattern)
            : this(string.Empty, pattern)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        public Filter(string name ,string pattern)
        {
            this.Name = name;
            this.Pattern = pattern;
            _regex = new Regex(this.Pattern, _options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual byte[] Filt(byte[] source)
        {
            string strTemp = (string)HexStringConverter.Default.ConvertToObject(source);
            strTemp = Filt(strTemp);

            byte[] bs = (byte[])HexStringConverter.Default.ConvertToBytes(strTemp);
            return bs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string Filt(string source)
        {
            bool isMatch = _regex.IsMatch(source);
            if (isMatch)
            {
                source = _regex.Replace(source, _replaceString);
            }
            return source;
        }
    }
}
