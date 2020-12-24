using System.Collections.Generic;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public class StubPlayerController : IPlayerController
    {
        public List<Player> Players { get; set; }

        public bool CanAttack(int playerId)
        {
            throw new System.NotImplementedException();
        }

        public void EndGame()
        {
        }

        public void InitPlayers(List<Player> players)
        {
            Players = players;
        }

        public void OnAttack(int playerId, float damage)
        {
        }

        public void SetAttack(int playerId, float value)
        {
            throw new System.NotImplementedException();
        }

        public void SetDefense(int playerId, float value)
        {
            throw new System.NotImplementedException();
        }

        public void SetHealth(int playerId, float value)
        {
            throw new System.NotImplementedException();
        }

        public void SetMaxHealth(int playerId, float value)
        {
            throw new System.NotImplementedException();
        }

        public void SetVampire(int playerId, float value)
        {
            throw new System.NotImplementedException();
        }
    }
}