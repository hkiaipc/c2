using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi.DPU
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDeviceFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceSource"></param>
        /// <returns></returns>
        Device CreateDevice(object deviceSource);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDPU
    {
        /// <summary>
        /// 
        /// </summary>
        string DeviceType { get; }

        /// <summary>
        /// 
        /// </summary>
        DeviceDefine DeviceDefine
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        TaskDefineCollection  TaskDefineCollection
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        IDeviceProcessor DeviceProcessor
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        IDevicePersister DevicePersister
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        IDeviceFactory DeviceFactory
        {
            get;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDeviceProcessor
    {
        void Process(ParseResult pr, bool isFD);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDevicePersister
    {
        void Add(Device device);
        void Update(Device device);
        void Delete(Device device);
    }
}
