using System.Collections.Generic;
using Assets.Code.Helper;

namespace Assets.Code.Controller
{
    public interface IPlayerController
    {
        List<Player> Players { get; set; }

        void EndGame();
        void InitPlayers(List<Player> players);
        bool CanAttack(int playerId);

        void OnAttack(int playerId, float damage);
        void SetHealth(int playerId, float value);
        void SetAttack(int playerId, float value);
        void SetDefense(int playerId, float value);
        void SetVampire(int playerId, float value);
        void SetMaxHealth(int playerId, float value);
    }
}