using System;
using System.Collections.Generic;
using Assets.Code.Model;

namespace Assets.Code.Helper
{
    public static class ExtensionMethods
    {
        public static void InitModelStats(this PlayerModel playerModel, List<StatModel> statModels)
        {
            foreach (var stat in statModels)
            {
                switch (stat.StatType)
                {
                    case StatType.Health: playerModel.Health = stat.Value;
                        break;
                    case StatType.Defence: playerModel.Defence = stat.Value;
                        break;
                    case StatType.Attack: playerModel.Attack = stat.Value;
                        break;
                    case StatType.Vampire: playerModel.Vampire = stat.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}