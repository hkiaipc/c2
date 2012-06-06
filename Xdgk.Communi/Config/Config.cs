using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class Config : IEnumerable 
    {
        /// <summary>
        /// 
        /// </summary>
        private Hashtable _config = new Hashtable();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get 
            {
                return _config[key];
            }
            set
            {
                _config[key] = value;
            }
        }


        #region IEnumerable 成员
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return _config.GetEnumerator();
        }

        #endregion
    }
}
