using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class AssemblyInfo
    {
        #region Path
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            get
            {
                if (_path == null)
                {
                    _path = string.Empty;
                }
                return _path;
            }
            set
            {
                _path = value;
            }
        } private string _path;
        #endregion //Path

    }

    /// <summary>
    /// 
    /// </summary>
    public class AssemblyInfoCollection : Xdgk.Common.Collection<AssemblyInfo>
    {
    }

    public class AssemblyInfoFactory
    {
        ///// <summary>
        //        /// 
        //        /// </summary>
        //        private const string AssemblyInfoFilePath = "Config\\ContentInfo.xml";

        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <returns></returns>
        //        static public ContentInfoCollection Create()
        //        {
        //            return Create(ContentInfoFilePath);
        //        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public AssemblyInfoCollection CreateFromXml(string path)
        {
            // parse xml file
            //
            path = System.Windows.Forms.Application.StartupPath + "\\" + path;

            AssemblyInfoCollection r = new AssemblyInfoCollection();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode ais = doc.SelectSingleNode(AssemblyInfoNodeName.AssemblyInfoCollection);
            if (ais != null)
            {
                XmlNodeList ciList = ais.SelectNodes(AssemblyInfoNodeName.AssemblyInfo);
                foreach (XmlNode ciNode in ciList)
                {
                    string aipath = XmlHelper.GetAttribute(ciNode, AssemblyInfoNodeName.Path);

                    AssemblyInfo item = new AssemblyInfo();
                    item.Path = aipath;
                    r.Add(item);
                }
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        private class AssemblyInfoNodeName
        {
            /// <summary>
            /// 
            /// </summary>
            private AssemblyInfoNodeName()
            {
            }

            /// <summary>
            /// 
            /// </summary>
            public const string
                Path = "path",
                AssemblyInfoCollection = "assemblyInfoCollection",
                AssemblyInfo = "assemblyInfo";
        }
    }
}
