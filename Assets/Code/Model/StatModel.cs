using Assets.Code.Data;
using Assets.Code.Helper;

namespace Assets.Code.Model
{
    public class StatModel : BaseStat
    {
        public StatType StatType;
        public float Value;

        public StatModel(Stat stat)
        {
            Id = stat.id;
            StatType = (StatType)stat.id;
            Value = stat.value;
            Icon = stat.icon;
            Title = stat.title;
        }
    }
}