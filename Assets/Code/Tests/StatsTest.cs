using System.Collections;
using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Helper;
using Assets.Code.Model;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class StatsTest
    {
        [Test]
        public void CreateDefaultStats()
        {
            Stat[] stats = new Stat[1];
            Stat stat = new Stat();
            stats[0] = stat;
            stat.id = 1;
            stat.value = 10;
            var statModels = StatsCreator.CreateDefaultStats(stats);

            Assert.True(stats[0].value == statModels[0].Value);
        }

        [Test]
        [TestCase(100, 25)]
        public void BuffChangesStat(int initialValue, int additionalvalue)
        {
            var stats = new Stat[1];
            var stat = new Stat();
            stats[0] = stat;
            stat.id = 0;
            stat.value = initialValue;

            var buffs = new Buff[1];
            var buff = new Buff();
            buffs[0] = buff;

            var buffStats = new BuffStat[1];
            buff.stats = buffStats;
            var buffStat = new BuffStat();
            buffStat.statId = 0;
            buffStat.value = additionalvalue;
            buffStats[0] = buffStat;


            var statModels = StatsCreator.CreateDefaultStats(stats);

            StatsCreator.CreateBuffs(statModels, buffs, false);
            Assert.True(statModels[0].Value > initialValue);
        }
    }
}