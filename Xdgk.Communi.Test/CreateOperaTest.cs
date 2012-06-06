using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Xdgk.Communi.Test
{
    [TestFixture]
    public class CreateOperaTest
    {
        [Test]
        public void t1()
        {
            //CommuniSoft soft = CommuniSoftFactory.Create(null);
            CommuniSoft soft = null;
            //CommuniSoft.Default = soft;

            XmlBuilder.XmlDeviceDefineBuild ddb = new Xdgk.Communi.XmlBuilder.XmlDeviceDefineBuild(
                @"f:\GRCTRLV2\xml\devicedefine.xml");
            ddb.Build(soft);
        }
    }
}
