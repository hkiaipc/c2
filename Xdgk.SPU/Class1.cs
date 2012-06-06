using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi.SPU;
using Xdgk.Communi;
using Xdgk.Common;
using System.Data;

namespace Xdgk.SPU
{
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
    }

    public class DBCommonStationSPU : ISPU
    {
        #region ISPU 成员

        public string StationType
        {
            get 
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IStationPersister StationPersister
        {
            get 
            {
                if (_dbCommonStationPersister == null)
                {
                    _dbCommonStationPersister = new DBCommonStationPersister();
                }
                return _dbCommonStationPersister;
            }
        }private DBCommonStationPersister _dbCommonStationPersister;

        /// <summary>
        /// 
        /// </summary>
        public IStationFactory StationFactory
        {
            get
            {
                if (_dbCommonStationFactory == null)
                {
                    _dbCommonStationFactory = new DBCommonStationFactory();
                }
                return _dbCommonStationFactory;
            }
        } private DBCommonStationFactory _dbCommonStationFactory;

        #endregion
    }

    public class DBCommonStationFactory : IStationFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationSource"></param>
        /// <returns></returns>
        public Xdgk.Communi.Station Create(object stationSource)
        {
            if (stationSource == null)
            {
                throw new ArgumentNullException("stationSource");
            }

            DataRow stationDR = stationSource as DataRow;
            if (stationDR == null)
            {
                string msg = string.Format("stationSource is not a data row");
                throw new ArgumentException(msg);
            }

            int stationID = (int)stationDR["StationID"];
            string stationName = stationDR["Name"].ToString();
            string xml = stationDR["CommuniTypeContent"].ToString().Trim();

            if (xml.Length == 0)
            {
                // TODO: 2010-09-17
                // log error info
                //
                //continue;
            }


            XmlDataDocument doc = new XmlDataDocument();
            doc.LoadXml(xml);
            XmlNode node = doc.SelectSingleNode("socketcommunitype");
            CommuniType communiType = Xdgk.Communi.XmlBuilder.XmlSocketCommuniBuilder.Build(node);

            Station station = new Station(stationName, communiType);
            station.ID = stationID;

            return station;
                
        }

    }

    public class DBCommonStationPersister : IStationPersister
    {

        #region IStationPersister 成员

        public void Add(Xdgk.Communi.Station station)
        {
            
        }

        public void Update(Xdgk.Communi.Station station)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public void Delete(Xdgk.Communi.Station station)
        {
            int id = station.ID;
            string sql = string.Format ("update tblStation set deleted = 1 where stationID = {0}", 
                id);
            DB.GetDB().ExecuteScalar(sql);
        }

        #endregion
    }
}
