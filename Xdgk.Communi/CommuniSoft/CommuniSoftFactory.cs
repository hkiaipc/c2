using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi.Builder;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class CommuniSoftFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private CommuniSoftFactory()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public CommuniSoft GetCommuniSoft()
        {
            if( _communiSoft == null )
            {
                CreateCommuniSoft();
            }
            Debug.Assert(_communiSoft != null, "_communiSoft == null");
            return _communiSoft;
        } static private CommuniSoft _communiSoft;

        /// <summary>
        /// 
        /// </summary>
        private static void CreateCommuniSoft()
        {
            _communiSoft = new CommuniSoft();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //static public void Init(HardwareBuilderBase hardwareBuilder )
        //{
        //    if (hardwareBuilder == null)
        //    {
        //        throw new ArgumentNullException("hardwareBuilder");
        //    }

        //    if (_isInited)
        //    {
        //        throw new InvalidOperationException("CommumiSoftFactory already inited");
        //    }

        //    _hardwareBuilder = hardwareBuilder;
        //    _isInited = true;
        //    _communiSoft = new CommuniSoft(null);
        //    hardwareBuilder.Build(_communiSoft);
        //}

        /// <summary>
        /// 
        /// </summary>
        static internal HardwareBuilderBase HardwareBuilder
        {
            get { return _hardwareBuilder; }
        } static private HardwareBuilderBase _hardwareBuilder;
    }
}
