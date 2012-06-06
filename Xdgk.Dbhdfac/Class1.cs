using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
//using Xdgk.commun
using Xdgk.Communi;
using Xdgk.Common;
using Xdgk.Communi.SPU;
using Xdgk.Communi.DPU;

namespace Xdgk.Dbhdfac
{
    /// <summary>
    /// 
    /// </summary>
    public class DB : DBIBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public DB GetDB()
        {

            if (_db == null)
            {
                string conn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                _db = new DB(conn);
            }
            return _db;
        } static private DB _db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public DB(string conn)
            : base(conn)
        {
        }

        public DataTable ExecuteStationDataTable()
        {
            string sql = "select * from tblStation";
            return this.ExecuteDataTable(sql);
        }

        public DataTable ExecuteDeviceDataTable(int stationID)
        {
            string sql = string.Format(
                "select * from tblDevice where StationID = {0}", stationID);

            return this.ExecuteDataTable(sql);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DBHardwareFactory : IHardwareFactory
    {
        CommuniSoft soft;
        public void Create(HardwareManager hardwareManager)
        {
            soft = hardwareManager.CommuniSoft;
            DataTable stationDataTable = DB.GetDB().ExecuteStationDataTable();
            foreach (DataRow row in stationDataTable.Rows)
            {
                //soft.SPUManager.SPUCollection[0].StationFactory.Create(row);
                // TODO:
                //
                string stationType = "";
                int stationID = Convert.ToInt32(row["StationID"]);

                IStationFactory stationFactory = soft.SPUManager.FindStationFactory(stationType);
                if (stationFactory != null)
                {
                    Station st = stationFactory.Create(row);
                    if (st != null)
                    {
                        CreateDevice(st, stationID);
                        hardwareManager.Stations.Add(st);
                    }
                }

                // stationfactory = spumanager.getStationFactory( stationType );
                // st = f.create(row)
                // hd.stations.add(st);

                // dr in device tbl
                // df = dpu.getfactory(device type)
                // df.create(row)
                // st.add(device)
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        private void CreateDevice(Station st, int stationID)
        {
            DataTable stationDataTable = DB.GetDB().ExecuteStationDataTable();
            DataTable tblDevice = DB.GetDB().ExecuteDeviceDataTable(stationID);
            foreach (DataRow row in tblDevice.Rows)
            {
                string deviceType = row["DeviceType"].ToString();
                IDeviceFactory deviceFactory = soft.DPUManager.FindDeviceFactory(deviceType);
                Device device = deviceFactory.CreateDevice(row);
                if (device != null)
                {
                    st.Devices.Add(device);
                }
            }
        }

    }
}
