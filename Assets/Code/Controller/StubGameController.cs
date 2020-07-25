using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Helper;
using Assets.Code.Model;

namespace Assets.Code.Controller
{
    public class StubGameController : IGameController
    {
        public List<Player> Players { get; set; }
        public SettingsModel SettingsModel { get; set; }
        public Stat[] Stats { get; set; }
        public Buff[] Buffs { get; set; }

        public StubGameController()
        {
            SettingsModel = new SettingsModel();
            SettingsModel.PlayersCount = 10;
            SettingsModel.WithBuffs = false;

            Stats = new Stat[1];
            Stat stat = new Stat();
            Stats[0] = stat;
            stat.id = 0;
            stat.value = 100;
        }

        public void EndGame()
        {
        }

        public void InitPlayers(List<Player> players)
        {
            Players = players;
        }
    }
}