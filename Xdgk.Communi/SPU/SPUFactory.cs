using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using Xdgk.Communi.DPU;
namespace Xdgk.Communi.SPU
{

    /// <summary>
    /// 
    /// </summary>
    public class SPUFactory
    {
        static public ISPU Create(string path)
        {
            return (ISPU)ObjectFactory.CreateWithInterface(path, typeof(ISPU));
        }
    }


}
