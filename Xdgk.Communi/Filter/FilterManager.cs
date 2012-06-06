using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterManager
    {
        /// <summary>
        /// 
        /// </summary>
        public CommuniSoft CommuniSoft
        {
            get { return _communiSoft; }
        } private CommuniSoft _communiSoft;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        public FilterManager(CommuniSoft soft)
        {
            if (soft == null)
            {
                throw new ArgumentNullException("soft");
            }
            _communiSoft = soft;
        }

        /// <summary>
        /// 
        /// </summary>
        public FilterDefineCollection FilterDefineCollection
        {
            get
            {
                if (_filterDefineCollection == null)
                {
                    _filterDefineCollection = new FilterDefineCollection();

                }
                return _filterDefineCollection;
            }
        } private FilterDefineCollection _filterDefineCollection;

        #region FilterDefineFileName
        /// <summary>
        /// 
        /// </summary>
        public string FilterDefineFileName
        {
            get { return _filterDefineFileName; }
            set { _filterDefineFileName = value; }
        } private string _filterDefineFileName;
        #endregion //FilterDefineFileName

    }
}
