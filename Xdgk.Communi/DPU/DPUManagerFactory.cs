using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi.DPU
{
    /// <summary>
    /// 
    /// </summary>
    public class DPUManagerFactory
    {
        static public DPUManager Create(CommuniSoft soft, AssemblyInfoCollection assemblyInfos)
        {
            DPUManager dpuManager = new DPUManager(soft);
            foreach (AssemblyInfo ai in assemblyInfos)
            {
                IDPU dpu = (IDPU)ObjectFactory.CreateWithInterface(ai.Path, typeof(IDPU));
                dpuManager.Add(dpu);
            }

            return dpuManager;
        }
    }
}
