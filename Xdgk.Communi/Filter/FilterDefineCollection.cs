using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xdgk.Common;

namespace Xdgk.Communi
{

    /// <summary>
    /// 
    /// </summary>
    internal class FilterNodeNames
    {
        internal const string
            FilterDefineCollection = "filterdefines",
            FilterDefine = "filterdefine",
            FilterCollection = "filters",
            Filter = "filter",
            FilterName = "name",
            FilterPattern = "pattern";
    }

    /// <summary>
    /// 
    /// </summary>
    public class FilterDefineCollection : Collection<FilterDefine>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public void LoadFromFile(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode filterDefinesNode = doc.SelectSingleNode(FilterNodeNames.FilterDefineCollection);
            if (filterDefinesNode != null)
            {
                LoadFilterDefines(filterDefinesNode);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterDefinesNode"></param>
        private void LoadFilterDefines(XmlNode filterDefinesNode)
        {
            XmlNodeList fdlist = filterDefinesNode.SelectNodes(FilterNodeNames.FilterDefine);
            if (fdlist != null)
            {
                foreach (XmlNode fd in fdlist)
                {
                    LoadFilterDefine(fd);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fd"></param>
        private void LoadFilterDefine(XmlNode fd)
        {
        }
    }
}
