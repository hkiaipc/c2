using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Xdgk.Common;
using Xdgk.Communi.Builder;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    //public class DBHardwareBuilder : HardwareBuilderBase 
    public class DBHardwareBuilder : DBHardwareBuilderBase 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbi"></param>
        public DBHardwareBuilder(DBIBase dbi)
        {
            if (dbi == null)
            {
                throw new ArgumentNullException("dbi");
            }
            this._dbi = dbi;
        }

        /// <summary>
        /// 
        /// </summary>
        private CommuniSoft Soft
        {
            get
            {
                return CommuniSoftFactory.GetCommuniSoft();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DBIBase DBI
        {
            get { return _dbi; }
        } private DBIBase _dbi;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        public override void Build(CommuniSoft soft)
        {
            StationCollection stations = BuildStationCollection();
            foreach (Station st in stations)
            {
                soft.HardwareManager.Stations.Add(st);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override StationCollection BuildStationCollection()
        {
            StationCollection stations = new StationCollection();
            string sql = "select * from tblStation where StationDeleted = 0";
            DataTable stationTbl = DBI.ExecuteDataTable(sql);
            foreach (DataRow row in stationTbl.Rows)
            {
                Station newStation = BuildStation(row);
                stations.Add(newStation);

                DeviceCollection devices = BuildDeviceCollection(newStation);

                newStation.Devices.AddDeviceCollection(devices);
            }
            return stations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override Station BuildStation(object source)
        {
            DataRow row = source as DataRow;
            Station st = BuildStation(row);
            return st;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Station BuildStation(DataRow row)
        {
            string name = row["StationName"].ToString();
            string ctString = row["StationCommuniType"].ToString();
            string remark = row["StationRemark"].ToString().Trim();

            CommuniType ct = CommuniTypeFactory.Create(ctString);
            Station station = new Station(name, ct);
            station.ID = Convert.ToInt32(row["stationID"]);
            station.Description = remark;

            return station;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public override DeviceCollection BuildDeviceCollection(Station station)
        {
            DeviceCollection devices = new DeviceCollection();

            string sql = string.Format(
                "select * from tblDevice where DeviceDeleted = 0 and StationID = {0}",
                station.ID
            );
            DataTable deviceTable = DBI.ExecuteDataTable(sql);
            foreach (DataRow row in deviceTable.Rows)
            {
                Device device = BuildDevice(row);
                if (device != null)
                {
                    devices.Add(device);
                }
            }
            return devices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override Device BuildDevice(object source)
        {
            DataRow row = source as DataRow;
            string devicetype = row["devicetype"].ToString().Trim();
            string name = row["devicename"].ToString();
            Int64 address = Convert.ToInt64(row["Deviceaddress"]);
            string remark = row["DeviceRemark"].ToString().Trim();
            int id = Convert.ToInt32(row["DeviceID"]);

            DeviceDefine dd = this.Soft.DeviceDefineManager.DeviceDefineCollection.FindDeviceDefine(devicetype);
            if (dd != null)
            {
                //Device d = new Device(dd, name, address);
                //d.Remark = remark;
                //return d;
                Device d = OnBuildDevice(dd, name, address, remark, id, source);
                return d;
            }
            else
            {
                this.Soft.UnDefineDeviceType.Add(devicetype);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="remark"></param>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        virtual public Device OnBuildDevice(DeviceDefine dd, string name, Int64 address, string remark, int id, object source)
        {
            Device d = new Device(dd, name, address);
            d.ID = id; 
            d.Remark = remark;
            return d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStation"></param>
        public override void AddStation(Station newStation)
        {
            string sql = "insert into tblStation(stationName, stationCommuniType, stationRemark, stationDeleted) values(@name, @ct, @remark, @deleted)";
            SqlCommand cmd = new SqlCommand(sql);
            DBIBase.AddSqlParameter(cmd, "name", newStation.Name);
            DBIBase.AddSqlParameter(cmd, "ct", newStation.CommuniType.ToXml());
            DBIBase.AddSqlParameter(cmd, "remark", newStation.Description);
            DBIBase.AddSqlParameter(cmd, "deleted", 0);

            DBI.ExecuteScalar(cmd);

            newStation.ID = DBI.GetIdentity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public override void EditStation(Station station)
        {
            string sql = "update tblStation set stationName = @name, StationCommuniType = @ct, StationRemark = @remark " +
                " where stationID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            DBIBase.AddSqlParameter(cmd, "name", station.Name);
            DBIBase.AddSqlParameter(cmd, "ct", station.CommuniType.ToXml());
            DBIBase.AddSqlParameter(cmd, "remark", station.Description);
            DBIBase.AddSqlParameter(cmd, "id", station.ID);

            DBI.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public void DeleteStation(Station station)
        {
            string sql = string.Format("update tblStation set stationDeleted = 1 where stationID = " + station.ID);
            DBI.ExecuteScalar(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDevice"></param>
        public override void AddDevice(Device newDevice)
        {
            string sql = "insert into tblDevice(DeviceName, DeviceAddress, DeviceType, DeviceDeleted, StationID, DeviceRemark) "
            + " values(@name, @address, @type, @deleted, @stationID, @remark)";

            SqlCommand cmd = new SqlCommand(sql);
            DBIBase.AddSqlParameter(cmd, "name", newDevice.Name);
            DBIBase.AddSqlParameter(cmd, "address", newDevice.Address);
            DBIBase.AddSqlParameter(cmd, "type", newDevice.DeviceDefine.DeviceType);
            DBIBase.AddSqlParameter(cmd, "deleted", 0);
            DBIBase.AddSqlParameter(cmd, "StationID", newDevice.Station.ID);
            DBIBase.AddSqlParameter(cmd, "remark", newDevice.Remark);
            DBI.ExecuteScalar(cmd);

            newDevice.ID = DBI.GetIdentity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public override void EditDevice(Device device)
        {
            string sql = "update tblDevice set DeviceName = @name, DeviceAddress = @address, DeviceType = @type, " + 
                "DeviceRemark = @remark where deviceID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            DBIBase.AddSqlParameter(cmd, "name", device.Name);
            DBIBase.AddSqlParameter(cmd, "address", device.Address);
            DBIBase.AddSqlParameter(cmd, "type", device.DeviceDefine.DeviceType);
            DBIBase.AddSqlParameter(cmd, "remark", device.Remark);
            DBIBase.AddSqlParameter(cmd, "id", device.ID);
            DBI.ExecuteScalar(cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public void DeleteDevice(Device device)
        {
            string sql = "update tblDevice set Devicedeleted = 1 where deviceid = " + device.ID;
            DBI.ExecuteScalar(sql);
        }
    }
}
