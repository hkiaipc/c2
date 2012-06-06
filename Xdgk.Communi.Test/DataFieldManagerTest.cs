//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xdgk.Communi;
//using NUnit.Framework;
//using Xdgk.Communi.Interface;

//namespace Xdgk.Communi.Test
//{
//    [TestFixture]
//    public class DataFieldManagerTest
//    {
//        [Test]
//        public void TestToBytes()
//        {
//            DatafieldManager dfm = new DatafieldManager();
//            DataFieldCollection dfs = dfm.DataFields;
            
//            BytesConverter c = new OriginalConverter ();
//            DataField df = new DataField("Head", 0, 3, c);
//            df.Bytes = new byte[] { 0x21, 0x58, 0x44 };
//            dfs.Add(df);

//            df = new DataField("Address", 3, 1, c);
//            df.Bytes = new byte[] { 00 };
//            dfs.Add(df);

//            df = new DataField("DevType", 4, 1, c);
//            df.Bytes = new byte[] { 0xa1 };
//            dfs.Add(df);

//            df = new DataField("fc", 5, 1, c);
//            df.Bytes = new byte[] { 01 };
//            dfs.Add(df);

//            df = new DataField("datalength", 6, 1, c);
//            df.Bytes = new byte[] { 1 };        // 1 data
//            dfs.Add(df);

//            df = new DataField("data", 7, 1, c);
//            df.Bytes = new byte[] { 0xFF };
//            dfs.Add(df);

//            df = new DataField("crc", 8, 2, c);
//            df.IsCRC = true;
//            dfs.Add(df);

//            dfm.CRCer = new CRC16();
//            byte[] bs = dfm.ToBytes();

//            Assert.AreEqual(10, bs.Length);
//            Console.WriteLine(BitConverter.ToString(df.Bytes));
//            Console.WriteLine(BitConverter.ToString(bs));
//        }

//        [Test]
//        public void TestToValues()
//        {
//            byte[] bs = new byte[] { 0x21, 0x58, 0x44, 0x00, 0xA1, 0x01, 0x01, 0xFF, 0x66, 0xc2 };

//            //byte[] bs = BitConverter.GetBytes(s);

//            DatafieldManager dfm = new DatafieldManager();
//            dfm.CRCer = new CRC16();
//            DataFieldCollection dfs = dfm.DataFields;

//            BytesConverter c = new OriginalConverter ();
//            DataField df = new DataField("crc", 8, 2, c);
//            df.IsCRC = true;
//            dfs.Add(df);

//            ParseResult pr = dfm.ToValues(bs);
//            Console.WriteLine(pr.ToString());
            

//            Assert.IsTrue(dfm.CheckBytes(bs).Success);
//            bool b = dfm.ToValues(bs).Success;
//            Assert.IsTrue(b);

//            Console.WriteLine(BitConverter.ToString(df.Bytes));
//        }
//    }
//}
