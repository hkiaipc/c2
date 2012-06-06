using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class StrategyDefine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public Strategy Create();
    }

    /// <summary>
    /// 
    /// </summary>
    public class CycleStrategyDefine : StrategyDefine 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cycle"></param>
        public CycleStrategyDefine(TimeSpan cycle)
        {
            this.Cycle = cycle;
        }

        #region Cycle
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Cycle
        {
            get { return _cycle; }
            set { _cycle = value; }
        } private TimeSpan _cycle;
        #endregion //Cycle

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Strategy Create()
        {
            return new CycleStrategy(this.Cycle);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class ImmediateStrategyDefine : StrategyDefine
    {
        public override Strategy Create()
        {
            return new ImmediateStrategy();
        }
    }
}
