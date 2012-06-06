using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using Xdgk.Communi.Interface;

namespace Xdgk.Communi.UITest
{
    //public class TestDevice : Device
    //{
    //    public TestDevice(int address)
    //        : base ("TestDevice",address )
    //    {
    //        _testOpera = CreateTestOpera();
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    private Opera CreateTestOpera()
    //    {
    //        Opera TestOpera = new Opera("testdevice", "test");
    //        //DataField df = new DataField("read", 0, 4, BytesConverter.OriginalConverter, DataFieldOption.ValueVolatile);
    //        //df.Value = ASCIIEncoding.ASCII.GetBytes("read");

    //        TestOpera.SendPart = new SendPart();
    //        //TestOpera.SendPart.Add(df);

    //        //DataField rdf = new DataField("Test", 0, 4, BytesConverter.OriginalConverter, DataFieldOption.BytesVolatile);

    //        TestOpera.ReceivePart = new ReceivePart(1);
    //        //TestOpera.ReceivePart.Add(rdf);
    //        return TestOpera;
    //    }

    //    public Opera TestOpera
    //    {
    //        get { return _testOpera; }
    //    }
    //    private Opera _testOpera;
    //}

}
