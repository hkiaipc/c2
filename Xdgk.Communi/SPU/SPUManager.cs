using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace Xdgk.Communi.SPU
{
    /// <summary>
    /// 
    /// </summary>
    public class SPUManager
    {

        #region SPUManager
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        public SPUManager(CommuniSoft soft)
        {
            if( soft == null )
            {
                throw new ArgumentNullException("soft");
            }
            this.Soft = soft;           
        }
        #endregion //SPUManager

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

        #region SPUCollection
        /// <summary>
        /// 
        /// </summary>
        public SPUCollection SPUCollection
        {
            get
            {
                if (_spuCollection == null)
                {
                    _spuCollection = new SPUCollection();
                }
                    return _spuCollection;
            }
        } private SPUCollection _spuCollection;
        #endregion //SPUCollection

        #region Add
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spu"></param>
        public void Add(ISPU spu)
        {
            if (spu == null)
            {
                throw new ArgumentNullException("spu");
            }

            // TODO: exist
            //
            this.SPUCollection.Add(spu);
        }
        #endregion //Add

        #region Find
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationType"></param>
        /// <returns></returns>
        public ISPU Find(string stationType)
        {
            foreach (ISPU spu in this.SPUCollection)
            {
                if (StringHelper.Equal(spu.StationType, stationType))
                {
                    return spu;
                }
            }
            return null;
        }
        #endregion //Find

        #region FindStationFactory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationType"></param>
        /// <returns></returns>
        public IStationFactory FindStationFactory(string stationType)
        {
            ISPU spu = Find(stationType);
            if (spu != null)
            {
                return spu.StationFactory;
            }
            else
            {
                return null;
            }
        }
        #endregion //FindStationFactory
    }
}
