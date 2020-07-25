using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Helper;
using Assets.Code.Model;

namespace Assets.Code.Controller
{
    public class GameController : IGameController
    {
        public List<Player> Players { get; set; }
        public SettingsModel SettingsModel { get; set; }
        public Stat[] Stats { get; set; }
        public Buff[] Buffs { get; set; }

        public GameController()
        {
            var data = DataLoader.LoadJson();
            InitSettingsModel(data.settings);
            Stats = data.stats;
            Buffs = data.buffs;
        }

        public void InitPlayers(List<Player> players)
        {
            Players = players;
        }

        public void EndGame()
        {
            Players?.Clear();
        }

        private void InitSettingsModel(GameModel gameModel)
        {
            SettingsModel = new SettingsModel();
            SettingsModel.PlayersCount = gameModel.playersCount;
            SettingsModel.BuffCountMin = gameModel.buffCountMin;
            SettingsModel.BuffCountMax = gameModel.buffCountMax;
            SettingsModel.AllowDuplicateBuffs = gameModel.allowDuplicateBuffs;
        }
    }
}