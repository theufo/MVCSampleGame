using System.Collections.Generic;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public class StubPlayerController : IPlayerController
    {
        public List<Player> Players { get; set; }
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
    }
}