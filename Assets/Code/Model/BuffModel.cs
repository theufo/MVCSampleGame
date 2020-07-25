using Assets.Code.Data;

namespace Assets.Code.Model
{
    public class BuffModel : BaseStat
    {
        public BuffStat[] StatModels;

        public BuffModel(Buff buff)
        {
            Id = buff.id;
            Icon = buff.icon;
            Title = buff.title;
            StatModels = buff.stats;
        }
    }
}