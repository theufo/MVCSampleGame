using System.Collections.Generic;
using System.Linq;
using Assets.Code.Data;
using Assets.Code.Model;
using UnityEngine;

namespace Assets.Code.Helper
{
    public static class StatsCreator
    {
        public static List<StatModel> CreateDefaultStats(Stat[] stats)
        {
            var statModels = new List<StatModel>();

            foreach (var stat in stats)
            {
                statModels.Add(new StatModel(stat));
            }

            return statModels;
        }

        public static List<BuffModel> CreateBuffs(List<StatModel> stats, Buff[] buffs, bool random = true)
        {
            var buffModels = new List<BuffModel>();

            foreach (var buff in buffs)
            {
                if(random)
                    if (Random.Range(0, 10) < 5)
                        continue;

                buffModels.Add(new BuffModel(buff));

                foreach (var stat in buff.stats)
                {
                    var statModel = stats.FirstOrDefault(x => x.Id == stat.statId);
                    if (statModel != null) 
                        statModel.Value += stat.value;
                }
            }

            return buffModels;
        }
    }
}