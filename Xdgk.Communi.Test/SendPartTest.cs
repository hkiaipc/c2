//using System;
//using System.Collections.Generic;
//using System.Text;
//using NUnit.Framework;
//using Xdgk.Communi;

//namespace Xdgk.Communi.Test
//{
//    [TestFixture]
//    public class SendPartTest
//    {
//        [Test]
//        public void ToBytes()
//        {
//            SendPart sp = new SendPart();
//            DataField df = new DataField("h", 0, 3, BytesConverter.OriginalConverter);
//            //df.IsValueVolatile = true;
//            //df.IsValueVolatile = false;
//            sp.Add(df);
//            df.Value = new byte[] {1,1,1 };
//            byte[] bs = sp.ToBytes();
//            //Assert.AreEqual(3, bs.Length);
//        }
//    }
//}
