using System.Collections.Generic;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public interface IPlayerController
    {
        List<Player> Players { get; set; }

        void EndGame();
        void InitPlayers(List<Player> players);
        void OnAttack(int playerId, float damage);
    }
}