using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Helper;
using Assets.Code.Model;

namespace Assets.Code.Controller
{
    public interface IGameController
    {
        List<Player> Players { get; set; }
        SettingsModel SettingsModel { get; set; }
        Stat[] Stats { get; set; }
        Buff[] Buffs { get; set; }


        void EndGame();
        void InitPlayers(List<Player> players);
    }
}