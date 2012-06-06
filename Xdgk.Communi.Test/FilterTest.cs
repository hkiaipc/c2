using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Xdgk.Common;

namespace Xdgk.Communi.Test
{
    [TestFixture]
    public class FilterTest
    {
        [Test]
        public void t()
        {
            byte[] source = new byte[] { 0x21, 0x58, 0x44, 0xaa, 0xaa, 0xaa, 0x21, 0x58, 0x44 };
            string pattern = "21 58 44";
            Filter f = new Filter(pattern);
            source = f.Filt(source);
            Assert.AreEqual(3, source.Length);
        }

        [Test]
        public void NullSource()
        {
            byte[] source = null;
            byte[] source1 = new byte[0];
            byte[][] bss= new byte[][]{source,source1 };
            foreach (byte[] bs in bss)
            {
                Filter f = new Filter("");
                byte[] bs1= f.Filt(bs);
                Assert.IsNotNull(bs1);
            }
        }


        [Test]
        public void FilterCollectionTest()
        {
            byte[] source = new byte[] 
            { 0X21, 0X58, 0X44, 0XAA, 0XDD, 0XDD, 0XDD, 0X0B, 0XAA, 0XAA, 0X22, 0X23, 0X24 };
            string pattern = "21 58 44";
            Filter f = new Filter(pattern);

            string pattern2 = "22 23 24";
            Filter f2 = new Filter(pattern2);

            string pattern3 = "dd dd dd";
            Filter f3 = new Filter(pattern3);

            FilterCollection fs = new FilterCollection();
            fs.Add(f);
            fs.Add(f2);
            fs.Add(f3);
            
            source = fs.Filt(source);
            string str = HexStringConverter.Default.ConvertToObject(source).ToString();
            Console.WriteLine(str);
            Assert.AreEqual(3, source.Length);
        }

    }
}
