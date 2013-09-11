// FFXIVAPP.Plugin.Parse
// TotalStat.cs
// 
// � 2013 Ryan Wilson

#region Usings

using FFXIVAPP.Plugin.Parse.Models.Stats;

#endregion

namespace FFXIVAPP.Plugin.Parse.Models.LinkedStats
{
    public class TotalStat : LinkedStat
    {
        public TotalStat(string name, params Stat<decimal>[] dependencies) : base(name, 0m)
        {
        }

        public TotalStat(string name, decimal value) : base(name, 0m)
        {
        }

        public TotalStat(string name) : base(name, 0m)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="previousValue"> </param>
        /// <param name="newValue"> </param>
        public override void DoDependencyValueChanged(object sender, object previousValue, object newValue)
        {
            Value += ((decimal) newValue - (decimal) previousValue);
        }
    }
}