using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public class PlayerController : IPlayerController
    {
        public List<Player> Players { get; set; }

        private IGameController _gameController;

        public PlayerController(IGameController gameController)
        {
            _gameController = gameController;
        }

        public void InitPlayers(List<Player> players)
        {
            Players = players;
            foreach (var player in Players)
            {
                player.PlayerModel.OnHealthChange += PlayerModel_OnHealthChange;
                player.PlayerView.HealthBar.Init(player);
            }
        }

        public void EndGame()
        {
            if (Players != null)
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

        public bool CanAttack(int playerId)
        {
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player != null)
                return player.PlayerModel.CanAttack;

            return false;
        }

        public void OnAttack(int playerId, float damage)
        {
            var opponents = Players.Where(x => x.PlayerModel.Id != playerId).ToList();
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;

            if (!player.PlayerModel.CanAttack)
                return;

            var canAttack = false;
            foreach (var opponent in opponents)
            {
                var defense = opponent.PlayerModel.Defense;
                var resultingDamage = (int)Math.Round(damage * (1d - defense / 100d));
                if (resultingDamage > opponent.PlayerModel.Health)
                {
                    opponent.PlayerModel.Health = 0;
                    opponent.PlayerView.Die();
                }
                else
                {
                    opponent.PlayerModel.Health -= resultingDamage;
                    canAttack = true;
                }

                var suckPower = player.PlayerModel.Vampire;
                var resultingSuck = (int)Math.Round(resultingDamage * (suckPower / 100d));
                player.PlayerModel.Health += resultingSuck;
                if (player.PlayerModel.Health > player.PlayerModel.MaxHealth)
                    player.PlayerModel.MaxHealth = player.PlayerModel.Health;
            }

            player.PlayerModel.CanAttack = canAttack;
        }

        public void SetHealth(int playerId, float value)
        {
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;

            player.PlayerModel.Health = value;
        }

        public void SetAttack(int playerId, float value)
        {
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;

            player.PlayerModel.Attack = value;
        }

        public void SetDefense(int playerId, float value)
        {
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;

            player.PlayerModel.Defense = value;
        }

        public void SetVampire(int playerId, float value)
        {
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;

            player.PlayerModel.Vampire = value;
        }

        public void SetMaxHealth(int playerId, float value)
        {
            var player = Players.FirstOrDefault(x => x.PlayerModel.Id == playerId);
            if (player == null)
                return;

            player.PlayerModel.MaxHealth = value;
        }
    }
}