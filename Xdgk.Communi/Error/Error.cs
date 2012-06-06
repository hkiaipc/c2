using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi.Error
{
    /// <summary>
    /// 
    /// </summary>
    public class Error
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        public Error(string description)
            : this ( description ,null )
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description"></param>
        /// <param name="exception"></param>
        public Error(string description, Exception exception)
        {
            this.Description = description;
            this.Exception = exception;
        }
        #endregion //Constructor

        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get
            {
                return _dT;
            }
            set
            {
                _dT = value;
            }
        } private DateTime _dT;
        #endregion //DT

        #region Exception
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        } private Exception _exception;
        #endregion //Exception

        #region Description
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get
            {
                if (_description == null)
                {
                    _description = string.Empty;
                }
                return _description;
            }
            set
            {
                _description = value;
            }
        } private string _description;
        #endregion //Description
    }
}
