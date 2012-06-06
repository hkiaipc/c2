using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xdgk.Common;
using Xdgk.Communi.XmlBuilder;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDefineCollection : Collection<TaskDefine>
    {
        #region LoadFromFile
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public void LoadFromFile(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode tasksNode = doc.SelectSingleNode(TaskFactoryNodeNames.TaskFactoryCollection);
            if (tasksNode != null)
            {
                XmlAttribute att = tasksNode.Attributes[TaskFactoryNodeNames.Timeout];
                if (att != null)
                {
                    TimeSpan taskDefaultTimeout = TimeSpan.Parse(att.Value);
                    TaskDefine.DefaultTaskTimeout = taskDefaultTimeout;
                }

                foreach (XmlNode node in tasksNode)
                {
                    switch (node.Name)
                    {
                        case TaskFactoryNodeNames.TaskFactory:
                            TaskDefine f = CreateTaskDefine(node);
                            this.Add(f);
                            break;
                    }
                }
            }
        }
        #endregion //LoadFromFile

        #region CreateTaskDefine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TaskDefine CreateTaskDefine(XmlNode taskDefineNode)
        {
            string devicetype = string.Empty;
            string opname = string.Empty;
            TimeSpan timeout = TaskDefine.DefaultTaskTimeout;

            StrategyDefine strategyDefine = null;

            foreach (XmlNode node in taskDefineNode.ChildNodes)
            {
                switch (node.Name)
                {
                    case TaskFactoryNodeNames.DeviceType:
                        devicetype = node.InnerText;
                        break;
                    
                    case TaskFactoryNodeNames.TaskOperaName:
                        opname = node.InnerText;
                        break;

                    case TaskFactoryNodeNames.StrategyType:
                        {
                            string type = node.InnerText;
                            if (StringHelper.Equal(type, TaskFactoryNodeNames.CycleStrategy))
                            {
                                XmlNode n2 = taskDefineNode.SelectSingleNode(type);

                                strategyDefine = CreateCycleStrategyDefine(n2);
                            }
                        }
                        break;

                    case TaskFactoryNodeNames.Timeout:
                        timeout = TimeSpan.Parse(node.InnerText);
                        break;
                }
            }

            if (strategyDefine == null)
            {
                string errmsg = string.Format(
                    "cannot find stragegy, devicetype = '{0}', operaname = '{1}'",
                    devicetype , opname);
                throw new ConfigException(errmsg);
            }

            return new TaskDefine(devicetype, opname, strategyDefine, timeout);
        }
        #endregion //CreateTaskDefine

        #region CreateCycleStrategyDefine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private CycleStrategyDefine CreateCycleStrategyDefine(XmlNode cyclenode)
        {
            if (cyclenode == null)
                throw new ArgumentNullException("cycleNode");

            XmlNode node = cyclenode.SelectSingleNode(TaskFactoryNodeNames.CycleValue);
            TimeSpan ts = TimeSpan.Parse(node.InnerText);
            return new CycleStrategyDefine(ts);
        }
        #endregion //CreateCycleStrategyDefine


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationCollection"></param>
        /// <returns></returns>
        public TaskCollection Create(StationCollection stationCollection)
        {
            TaskCollection result = new TaskCollection();

            foreach (TaskDefine td in this)
            {
                TaskCollection tasks = td.Create(stationCollection);
                AddTasks(result, tasks);
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        private void AddTasks(TaskCollection to, TaskCollection from)
        {
            foreach (Task t in from)
            {
                to.Add(t);
            }
        }
    }
}
