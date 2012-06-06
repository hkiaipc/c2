using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterDefine
    {
        #region CommuniPortType
        /// <summary>
        /// 
        /// </summary>
        public string CommuniPortType
        {
            get { return _communiPortType; }
            set { _communiPortType = value; }
        } private string _communiPortType;
        #endregion //CommuniPortType

        /// <summary>
        /// 
        /// </summary>
        public FilterCollection FilterCollection
        {
            get
            {
                if (_filterCollection == null)
                {
                    _filterCollection = new FilterCollection();
                }
                return _filterCollection;
            }
        } private FilterCollection _filterCollection;
    }
}
