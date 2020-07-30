using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public class StubStatController : IStatController
    {
        public void UpdateStat(int id, StatType statType, float value)
        {
        }

        public float GetStat(int id, StatType statType)
        {
            return 0;
        }

        public void InitPlayers(List<Player> list, Stat[] stats)
        {
        }

        public void EndGame()
        {
        }
    }
}