using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public class PlayerController : IPlayerController
    {
        public List<Player> Players { get; set; }

        public void InitPlayers(List<Player> players)
        {
            Players = players;
            foreach (var player in Players)
            {
                player.PlayerModel.OnHealthChange += PlayerModel_OnHealthChange;
            }
        }

        public void EndGame()
        {
            if(Players != null)
                foreach (var player in Players)
                {
                    player.PlayerModel.OnHealthChange -= PlayerModel_OnHealthChange;
                }
        }

        private void PlayerModel_OnHealthChange(int playerId, float newVal)
        {
            var player = Players.FirstOrDefault(x => x.PlayerView.Id == playerId);
            if (player != null)
                player.PlayerView.Health = newVal;
        }

        public void OnAttack(int playerId, float damage)
        {
            var opponents = Players.Where(x => x.PlayerModel.Id != playerId).ToList();
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;
            foreach (var opponent in opponents)
            {
                var defence = opponent.PlayerModel.Defence;
                var resultingDamage = (int)Math.Round(damage * (1d - defence / 100d));
                opponent.PlayerModel.Health -= resultingDamage;
                if (opponent.PlayerModel.Health <= 0)
                    opponent.PlayerView.Die();

                var suckPower = player.PlayerModel.Vampire;
                var resultingSuck = (int)Math.Round(resultingDamage * (suckPower / 100d));
                player.PlayerModel.Health += resultingSuck;
            }
        }
    }
}