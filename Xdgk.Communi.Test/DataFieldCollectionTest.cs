//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xdgk.Communi;
//using NUnit.Framework;

//namespace Xdgk.Communi.Test
//{
//    [TestFixture ]
//    public class DataFieldCollectionTest
//    {

//        [Test]
//        public void t1()
//        {
//            BytesDataField df = new BytesDataField("", 1,1,new BoolBitConverter(),DataFieldOption.BytesVolatile);
//            DataFieldCollection dfs = new DataFieldCollection();
//            dfs.Add( df );
//            Assert.AreEqual(1, dfs.Count);
//            dfs.Remove(df);
//            Assert.AreEqual(0, dfs.Count);
//        }
//    }
//}
