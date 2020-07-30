using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public interface IStatController
    {
        void UpdateStat(int id, StatType statType, float value);

        float GetStat(int id, StatType statType);
        void InitPlayers(List<Player> list, Stat[] stats);
        void EndGame();
    }
}