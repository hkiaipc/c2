using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi.DPU
{
/// <summary>
    /// 
    /// </summary>
    public class DPUManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        public DPUManager(CommuniSoft soft)
        {
            if( soft == null )
            {
                throw new ArgumentNullException("soft");
            }
            this.Soft = soft;           
        }

        #region Soft
        /// <summary>
        /// 
        /// </summary>
        public CommuniSoft Soft
        {
            get
            {
                return _soft;
            }
            set
            {
                _soft = value;
            }
        } private CommuniSoft _soft;
        #endregion //Soft

        /// <summary>
        /// 
        /// </summary>
        public DPUCollection DPUCollection
        {
            get
            {
                if (_dpuCollection==null)
                {
                    _dpuCollection = new DPUCollection();   
                }
                return _dpuCollection;
            }
        } private DPUCollection _dpuCollection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dpu"></param>
        public void Add(IDPU dpu )
        {
            if (dpu == null)
            {
                throw new ArgumentNullException("dpu");
            }
            this.DPUCollection.Add(dpu);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public IDPU FindDPU(string deviceType)
        {
            foreach (IDPU dpu in this.DPUCollection)
            {
                if (Xdgk.Common.StringHelper.Equal(dpu.DeviceType, deviceType))
                {
                    return dpu;
                }
            }
            return null;
        }

        public IDeviceFactory FindDeviceFactory(string deviceType)
        {
            IDPU dpu = FindDPU(deviceType);
            if (dpu != null)
            {
                return dpu.DeviceFactory;
            }
            else
            {
                return null;
            }

        }
    }
  
}
