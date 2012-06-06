using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDefineManager
    {
        /// <summary>
        /// 
        /// </summary>
        public TaskDefineManager(CommuniSoft soft)
        {
            if (soft == null)
            {
                throw new ArgumentNullException("soft");
            }
            this._communiSoft = soft;
        }

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
        public string TaskDefineFileName
        {
            get { return _taskDefineFileName; }
            set { _taskDefineFileName = value; }
        } private string _taskDefineFileName;


        /// <summary>
        /// 
        /// </summary>
        public TaskDefineCollection TaskDefineCollection
        {
            get 
            {
                if (_taskDefineCollection == null)
                {
                    _taskDefineCollection = new TaskDefineCollection();
                    _taskDefineCollection.LoadFromFile(TaskDefineFileName);
                }
                return _taskDefineCollection;
            }
        } private TaskDefineCollection _taskDefineCollection;
    }
}
