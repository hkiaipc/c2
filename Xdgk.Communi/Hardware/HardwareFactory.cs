using System;
using Xdgk.Common ;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHardwareFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hardwareManager"></param>
        void Create(HardwareManager hardwareManager);
    }


    /// <summary>
    /// 
    /// </summary>
    public class HardwareFactoryCollection : Collection<IHardwareFactory>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class HardwareFactoryManager
    {
        #region HardwareFactoryCollection
        /// <summary>
        /// 
        /// </summary>
        public HardwareFactoryCollection HardwareFactoryCollection
        {
            get
            {
                if (_hardwareFactoryCollection == null)
                {
                    _hardwareFactoryCollection = new HardwareFactoryCollection();
                }
                return _hardwareFactoryCollection;
            }
            set
            {
                _hardwareFactoryCollection = value;
            }
        } private HardwareFactoryCollection _hardwareFactoryCollection;
        #endregion //HardwareFactoryCollection


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hardwareManager"></param>
        public void CreateHardware(HardwareManager hardwareManager)
        {
            foreach (IHardwareFactory factory in this.HardwareFactoryCollection)
            {
                factory.Create(hardwareManager);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdf"></param>
        public void Add(IHardwareFactory hdf)
        {
            this.HardwareFactoryCollection.Add(hdf);
        }

    }



    /// <summary>
    /// 
    /// </summary>
    public class HardwareFactoryManagerFactory
    {
        static public HardwareFactoryManager Create(AssemblyInfoCollection assemblyInfos)
        {
            HardwareFactoryManager hdfm = new HardwareFactoryManager();

            foreach (AssemblyInfo ai in assemblyInfos)
            {
                IHardwareFactory hdf = (IHardwareFactory ) ObjectFactory.CreateWithInterface(ai.Path, typeof(IHardwareFactory));
                hdfm.Add(hdf);
            }
            return hdfm;
        }
    }
}
