using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using NUnit.Framework;

namespace Xdgk.Communi.Test
{
    public class StationTest : Station
    {
        public StationTest()
            : this( "nonamestation", "1234567890")
        {

        }
        public StationTest(string name, string description)
            //: base(name, description)
        : base(name, new SocketCommuniType("1234567890"))
        { }
    }

    [TestFixture]
    public class StationCollectionTest
    {
        [Test]
        public void Add()
        {
            string stationName = "aaa";
            string Description = "bbb";
            Station s = new StationTest(stationName, Description);

            //CommuniSoftFactory.Create(null);
            //CommuniSoft soft = new CommuniSoft(null);
            StationCollection ss = CommuniSoft.Default.HardwareManager.Stations;

            Assert.AreEqual(0, ss.Count);
            ss.Add(s);
            
            Assert.AreSame (s.StationCollection ,ss);
            Assert.AreEqual(1, ss.Count);

            ss.Remove(s);
            Assert.AreEqual(0, ss.Count);
            Assert.IsNull(s.StationCollection);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void AddSameName()
        {
            string stationName = "aaa";
            string Description = "bbb";
            Station s = new StationTest(stationName, Description);
            Station s1 = new StationTest(stationName, Description);
            StationCollection ss = StationCollection;

            ss.Add(s);
            ss.Add(s1);

        }

        public StationCollection StationCollection
        {
            get { return CommuniSoft.Default.HardwareManager.Stations; }
        }

    }
}
