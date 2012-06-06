using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using NUnit.Framework;

namespace Xdgk.Communi.Test
{

    public class DeviceTest2 : Device
    {
        static public DeviceDefine DD
        {
            get { return _dd; }
        } static private DeviceDefine _dd = new DeviceDefine("dd", "dd.text");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public DeviceTest2(string a)
            //: base(a,b)
            : base(DD, a,01)
        {
        }
    }

    public class DeviceTest : Device
    {
        public DeviceTest(DeviceDefine dd , string name)
            : base(dd,name,1)
        {
        }

    }

    [TestFixture]
    public class DeviceCollectionTest
    {
        [Test]
        public void Add()
        {
            DeviceTest d = new DeviceTest(DeviceTest2.DD, "a");
            DeviceCollection ds = new DeviceCollection();

            Assert.AreEqual(0, ds.Count);
            ds.Add(d);

            Assert.AreEqual(1, ds.Count);
            Assert.AreSame(d.Devices, ds);

            d.Delete();

            Assert.IsNull(d.Devices);
            Assert.AreEqual(0, ds.Count);


        }


        [Test, ExpectedException(typeof(ArgumentException))]
        public void AddSameAddress()
        {
            DeviceTest d1 = new DeviceTest(DeviceTest2.DD,"dt");
            DeviceTest2 d2 = new DeviceTest2("dt2");
            DeviceCollection ds = new DeviceCollection();
            ds.Add(d1);
            ds.Add(d2);
        }
        

    }
}
