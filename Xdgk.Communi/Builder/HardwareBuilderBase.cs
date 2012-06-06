
namespace Xdgk.Communi.Builder
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class HardwareBuilderBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        abstract public void Build(CommuniSoft soft);
    }

    /// <summary>
    /// 
    /// </summary>
    abstract public class DBHardwareBuilderBase : HardwareBuilderBase
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="soft"></param>
        //abstract public void Build(CommuniSoft soft);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public StationCollection BuildStationCollection();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        abstract public Station BuildStation( object source );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        abstract public DeviceCollection BuildDeviceCollection(Station station);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        abstract public Device BuildDevice(object source);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStation"></param>
        abstract public void AddStation(Station newStation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        abstract public void EditStation(Station station);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDevice"></param>
        abstract public void AddDevice(Device newDevice);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        abstract public void EditDevice(Device device);
    }
}
