using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using System.Xml;
using Xdgk.Communi.XmlBuilder;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDefine
    {
        /// <summary>
        /// 获取或设置默认任务超时时间
        /// </summary>
        static public TimeSpan DefaultTaskTimeout
        {
            // TODO: 2010-11-24 range 
            //
            get { return _defaultTaskTimeout; }
            set { _defaultTaskTimeout = value; }
        } static private TimeSpan _defaultTaskTimeout = TimeSpan.FromSeconds(10);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="operaName"></param>
        /// <param name="strategyDefine"></param>
        /// <param name="taskTimeout"></param>
        public TaskDefine(string deviceType, string operaName, StrategyDefine strategyDefine,
            TimeSpan taskTimeout)
        {
            if (strategyDefine == null)
            {
                throw new ArgumentNullException("strategyDefine");
            }

            this.DeviceType = deviceType;
            this.OperaName = operaName;
            this.StrategyDefine = strategyDefine;
            this.TimeOut = taskTimeout;
        }

        #region DeviceType
        /// <summary>
        /// 
        /// </summary>
        public string DeviceType
        {
            get { return _deviceType; }
            set { _deviceType = value; }
        } private string _deviceType;
        #endregion //DeviceType

        #region OperaName
        /// <summary>
        /// 
        /// </summary>
        public string OperaName
        {
            get { return _operaName; }
            set { _operaName = value; }
        } private string _operaName;
        #endregion //OperaName

        #region TimeOut
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        } private TimeSpan _timeOut;
        #endregion //TimeOut

        #region 
        /// <summary>
        /// 
        /// </summary>
        public StrategyDefine  StrategyDefine
        {
            get { return _strategyDefine; }
            set { _strategyDefine = value; }
        } private StrategyDefine _strategyDefine;
        #endregion //


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationCollection"></param>
        /// <returns></returns>
        public TaskCollection Create(StationCollection stationCollection)
        {
            if (stationCollection == null)
            {
                throw new ArgumentNullException("stationCollection");
            }

            TaskCollection taskCollection = new TaskCollection();
            foreach( Station st in stationCollection )
            {
                foreach (Device device in st.Devices)
                {
                    if (StringHelper.Equal(device.DeviceDefine.DeviceType,
                        this.DeviceType))
                    {
                        Opera opera = device.DeviceDefine.CreateOpera(this.OperaName);
                        Strategy strategy = this.StrategyDefine.Create();
                        Task task = new Task(device, opera, strategy, TimeOut);
                        taskCollection.Add(task);
                    }
                }
            }
            return taskCollection;
        }
    }


}
