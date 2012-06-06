using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Xdgk.Communi.Builder;
using Xdgk.Communi.XmlBuilder;

namespace Xdgk.Communi.Test
{
    [TestFixture]
    public class XmlParserTest
    {
        [Test]
        public void soft()
        {
            //CommuniSoft s = new CommuniSoft();

            DeviceDefineBuilderBase d = new XmlDeviceDefineBuild( "xml\\devicedefine.xml" );
            HardwareBuilderBase h = new XmlHardwareBuilder("xml\\hardware.xml");
            TaskFactoryCollectionBuilder t = new XmlTaskFactoryCollectionBuilder("xml\\task.xml");
            ListenBuilderBase l = new XmlListenBuilder("xml\\listenport.xml");

            CommuniSoftBuilder b = new CommuniSoftBuilder(d, h, t, l);
            b.Build( CommuniSoft.Default);
                
            CommuniSoft soft = CommuniSoft.Default;

            //Opera op = soft.OperaFactory.Create("vdevicetype", "operaname");
            //Assert.IsNotNull(op);
            //Assert.AreEqual("operaname", op.Name);
            //Assert.AreEqual(1, op.SendPart.DataFieldManager.DataFields.Count);

            //Assert.AreEqual(1, soft.HardwareManager.Stations.Count);
            //Assert.AreEqual(1, soft.HardwareManager.Stations[0].Devices.Count);
            //Assert.AreEqual(100, soft.HardwareManager.Stations[0].Devices[0].Address);
            ////Assert.AreEqual("vdevicetype", soft.HardwareManager.Stations[0].Devices[0].DeviceType);

            //Assert.AreEqual(1, soft.TaskManager.Tasks.Count);

        }
    }
}
