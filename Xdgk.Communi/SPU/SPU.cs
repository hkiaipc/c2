using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace Xdgk.Communi.SPU
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStationFactory
    {
        Station Create(object stationSource);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IStationUI
    {
        DialogResult AddStation();
        DialogResult EditStation(Station station);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISPU
    {

        string StationType
        {
            get;
        }

        IStationPersister StationPersister
        {
            get;
        }

        IStationFactory StationFactory
        {
            get;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IStationPersister
    {
        void Add(Station station);
        void Update(Station station);
        void Delete(Station station);
    }

  

}
