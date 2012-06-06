using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi.Error
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorManager
    {
        /// <summary>
        /// 
        /// </summary>
        public ErrorCollection ErrorCollection
        {
            get
            {
                if (_errorCollection == null)
                {
                    _errorCollection = new ErrorCollection();
                }
                return _errorCollection;
            }
        } private ErrorCollection _errorCollection;
    }
}
