///////////////////////////////////////////////////////////
//  CommuniType.cs
//  Implementation of the Class CommuniType
//  Generated by Enterprise Architect
//  Created on:      08-七月-2009 11:10:30
//  Original author: LiZhL
///////////////////////////////////////////////////////////

using System;

namespace Xdgk.Communi
{
    ///// <summary>
    ///// 通讯方式类选项
    ///// </summary>
    //public enum CommuniTypeOption
    //{
    //    /// <summary>
    //    /// 串口通讯
    //    /// </summary>
    //    SerialCommuni = 0x00,
    //    /// <summary>
    //    /// Gprs通讯
    //    /// </summary>
    //    GprsCommuni = 0x01,
    //}

    /// <summary>
    /// 指示站点的通讯方式
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

    }
}