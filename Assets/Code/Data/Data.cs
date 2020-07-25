using System;

namespace Assets.Code.Data
{
    [Serializable]
    public class Data
    {
        public GameModel settings;
        public Stat[] stats;
        public Buff[] buffs;
    }

    [Serializable]
    public class GameModel
    {
        public int playersCount;
        public int buffCountMin;
        public int buffCountMax;
        public bool allowDuplicateBuffs;
    }

    [Serializable]
    public class Stat
    {
        public int id;
        public string title;
        public string icon;
        public float value;
    }

    [Serializable]
    public class BuffStat
    {
        public float value;
        public int statId;
    }

    [Serializable]
    public class Buff
    {
        public string icon;
        public int id;
        public string title;
        public BuffStat[] stats;
    }
}