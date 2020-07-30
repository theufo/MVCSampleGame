using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Data;
using Assets.Code.Helper;
using Assets.Code.Model;

namespace Assets.Code.Controller
{
    public class StatController : IStatController
    {
        private readonly IGameController _gameController;

        private List<StatModel> _statModels;
        private List<BuffModel> _buffModels;
        private List<Player> _players;

        public StatController(IGameController gameController)
        {
            _gameController = gameController;
        }

        public void InitPlayers(List<Player> players, Stat[] stats)
        {
            _players = players;
            _statModels = new List<StatModel>();
            _buffModels = new List<BuffModel>();
            foreach (var player in players)
            {
                var statModels = StatsCreator.CreateDefaultStats(_gameController.Stats);
                if (_gameController.SettingsModel.WithBuffs)
                {
                    var buffModels = StatsCreator.CreateBuffs(statModels, _gameController.Buffs);
                    InitStats(player, statModels, buffModels);
                }
                else
                    InitStats(player, statModels);

                InitModelStats(player.PlayerModel, statModels);
            }

        }

        public void InitStats(Player player, IEnumerable<StatModel> statModels, List<BuffModel> buffModels = null)
        {
            foreach (var statModel in statModels)
            {
                player.PlayerView.AddStat(statModel);
                statModel.PlayerId = player.PlayerModel.Id;
                _statModels.Add(statModel);
            }

            if (buffModels != null)
                foreach (var buffModel in buffModels)
                {
                    player.PlayerView.AddStat(buffModel);
                    buffModel.PlayerId = player.PlayerModel.Id;
                    _buffModels.Add(buffModel);
                }
        }

        public static void InitModelStats(PlayerModel playerModel, IEnumerable<StatModel> statModels)
        {
            foreach (var stat in statModels)
            {
                switch (stat.StatType)
                {
                    case StatType.Health:
                        playerModel.Health = stat.Value;
                        break;
                    case StatType.Defence:
                        playerModel.Defence = stat.Value;
                        break;
                    case StatType.Attack:
                        playerModel.Attack = stat.Value;
                        break;
                    case StatType.Vampire:
                        playerModel.Vampire = stat.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void EndGame()
        {
            _statModels?.Clear();
            _buffModels?.Clear();

            if (_players == null) 
                return;

            foreach (var player in _players)
                player.PlayerView.ClearStats();
        }

        public void UpdateStat(int id, StatType statType, float value)
        {
            var stat = _statModels?.FirstOrDefault(x => x.PlayerId == id && x.StatType == statType);
            if (stat != null)
                stat.Value = value;
        }

        public float GetStat(int id, StatType statType)
        {
            var stat = _statModels.FirstOrDefault(x => x.PlayerId == id && x.StatType == statType);
            if (stat != null)
                return stat.Value;

            return 0;
        }
    }
}