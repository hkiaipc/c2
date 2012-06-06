using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi.SPU
{
    /// <summary>
    /// 
    /// </summary>
    public class SPUManagerFactory
    {
        static public SPUManager Create(CommuniSoft soft, AssemblyInfoCollection assemblyInfos)
        {
            SPUManager spuManager = new SPUManager(soft);
            foreach (AssemblyInfo ai in assemblyInfos)
            {
                ISPU spu = SPUFactory.Create(ai.Path);
                spuManager.Add(spu);
            }


            return spuManager;
        }
    }
}
