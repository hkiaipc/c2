using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using Xdgk.Common;
using Xdgk.Communi.SPU;
using Xdgk.Communi.DPU;


namespace Xdgk.Communi.Plug.Test
{
    /// <summary>
    /// 
    /// </summary>
    public class HardwareFactoryTest : IHardwareFactory
    {
        #region IHardwareFactory 成员

        public void Create(HardwareManager hardwareManager)
        {
            //hardwareManager .Stations 
            SPUManager sm = hardwareManager.CommuniSoft.SPUManager;
            DPUManager dm = hardwareManager.CommuniSoft.DPUManager;

            object source = new object();
            Station st = sm.SPUCollection[0].StationFactory.Create(source);

            //Device device = dm.DPUCollection[0].devCreateDevice(source);
            //st.Devices.Add(device);

            hardwareManager.Stations.Add(st);
        }

        #endregion
    }


    public class StationTest : Station
    {
        public StationTest()
            : base("", new SocketCommuniType("1234567"))
        {

        }
    }


    public class StationPersisterTest : IStationPersister
    {

        #region IStationPersister 成员

        public void Add(Station station)
        {
            throw new NotImplementedException();
        }

        public void Update(Station station)
        {
            throw new NotImplementedException();
        }

        public void Delete(Station station)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class SPUTest : ISPU
    {
        public class StationFactory1 : IStationFactory
        {

            #region IStationFactory 成员

            public Station Create(object stationSource)
            {
                return new StationTest();
            }

            #endregion
        }

        public string StationType
        {
            get
            {
                return "station type";
            }
        }

        static public int s_no = 1;
        #region ISPU 成员

        //public Station Create(object stationSource)
        //{
        //    StationTest st = new StationTest();
        //    st.Name = "station test " + s_no++ + "#";
        //    return st;
        //}

        public IStationFactory StationFactory
        {
            get {
                return new StationFactory1();
            }
        }
        public IStationPersister StationPersister
        {
            get { return new StationPersisterTest(); }
        }

        #endregion //ISPU 成员
    }




    public class DeviceTest : Device
    {
        public DeviceTest(DeviceDefine dd)
            : base(dd, "d", 1)
        {

        }
    }

    public class DeviceProcessorTest : DPU.IDeviceProcessor
    {

        #region IDeviceProcessor 成员

        public void Process(ParseResult pr, bool isFD)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class DevicePersisterTest : DPU.IDevicePersister
    {


        public void Add(Device device)
        {
            throw new NotImplementedException();
        }

        public void Update(Device device)
        {
            throw new NotImplementedException();
        }

        public void Delete(Device device)
        {
            throw new NotImplementedException();
        }

    }

    public class DPUTest : DPU.IDPU
    {

        #region IDPU 成员

        public string DeviceType
        {
            get { return "deviceTest"; }
        }

        public DeviceDefine DeviceDefine
        {
            get
            {
                return new DeviceDefine(this.DeviceType, "text");
            }
        }

        public TaskDefineCollection TaskDefineCollection
        {
            get { return new TaskDefineCollection(); }
        }

        public Xdgk.Communi.DPU.IDeviceProcessor DeviceProcessor
        {
            get { return new DeviceProcessorTest(); }
        }

        public Xdgk.Communi.DPU.IDevicePersister DevicePersister
        {
            get { return new DevicePersisterTest(); }
        }

        public class DeviceFactory1 : IDeviceFactory
        {

            #region IDeviceFactory 成员

            public Device CreateDevice(object deviceSource)
            {
                return new DeviceTest(null);
            }

            #endregion
        }

        public IDeviceFactory DeviceFactory
        {
            get
            {
                return new DeviceFactory1();
            }
        }

        public Device CreateDevice(object deviceSource)
        {
            return new DeviceTest(this.DeviceDefine);
        }

        #endregion
    }

}
