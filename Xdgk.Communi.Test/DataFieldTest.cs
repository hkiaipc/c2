using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Xdgk.Communi;
using Xdgk.Common;
namespace Xdgk.Communi.Test
{
    [TestFixture]
    public class DataFieldTest
    {
        //[Test]
        //public void TestIsCRC()
        //{
        //    DataField df = new DataField("a", 1, 1, new HexStringConverter());
        //    Assert.IsFalse(df.IsCRC);

        //    df.IsCRC = true;
        //    Assert.IsTrue(df.IsCRC);

        //    df.IsCRC = false;
        //    Assert.IsFalse(df.IsCRC);

        //    df = new DataField("a", 1, 1, new HexStringConverter(), DataFieldOption.CRC);
        //    Assert.IsTrue(df.IsCRC);
        //}

        //[Test]
        //public void DataFieldOptionTest()
        //{
        //    DataField df = new DataField("a", 0, 1, new HexStringConverter());
        //    Assert.IsFalse(df.IsAddress);
        //    df.IsAddress = true;
        //    Assert.IsTrue(df.IsAddress);
        //    df.IsAddress = false;
        //    Assert.IsFalse(df.IsAddress);

        //    Assert.IsFalse(df.IsIgnore);
        //    df.IsIgnore = true;
        //    Assert.IsTrue(df.IsIgnore);
        //    df.IsIgnore = false;
        //    Assert.IsFalse(df.IsIgnore);
        //}


        [Test
        //, ExpectedException(typeof(ArgumentException))]
        ]
        public void ValueLengthMath()
        {
            //DataField df = new DataField("", 0, 2, BytesConverter.OriginalConverter);
            //df.Value = new byte[] { 1 };
        }

        [Test]
        public void ValueLengthMatch2()
        {
            //DataField df = new DataField("", 0, 2, BytesConverter.OriginalConverter);
            //df.Value = new byte[] { 1, 1 };
        }
    }
}
