using System;

namespace Xdgk.Communi
{
    /// <summary>
    /// ָʾվ���ͨѶ��ʽ
    /// </summary>
    public abstract class CommuniType
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="option"></param>
        //public CommuniType(CommuniTypeOption option)
        //{
        //    this.m_communiTypeOption = option;
        //}

        //~CommuniType()
        //{

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public CommuniTypeOption CommuniTypeOption
        //{
        //    get { return m_communiTypeOption; }
        //    set { m_communiTypeOption = value; }
        //}private CommuniTypeOption m_communiTypeOption;
        abstract public string ToXml();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public CommuniType Parse(string xml)
        {
            return CommuniTypeFactory.Create(xml);
        }

    }
}