using System.Collections.Generic;
using System.Linq;
using Assets.Code.Controller;
using Assets.Code.Helper;
using Assets.Code.Model;
using Assets.Code.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code
{
    public class MainScript : MonoBehaviour
    {
        private IGameController _gameController;
        private IPlayerController _playerController;
        private IStatController _statController;
        public Button StartWithBuffsButton;
        public Button StartWithoutBuffsButton;

        void Awake()
        {
            StartWithBuffsButton.onClick.AddListener(StartWithBuffs);
            StartWithoutBuffsButton.onClick.AddListener(StartWithoutBuffs);
            StartWithoutBuffs();
        }

        [Inject]
        public void Construct(IGameController gameController, IPlayerController playerController, IStatController statController)
        {
            _gameController = gameController;
            _playerController = playerController;
            _statController = statController;
        }

        private void StartWithoutBuffs()
        {
            _gameController.SettingsModel.WithBuffs = false;
            StartGame(GetPlayerViewsFromScene());
        }

        private void StartWithBuffs()
        {
            _gameController.SettingsModel.WithBuffs = true;
            StartGame(GetPlayerViewsFromScene());
        }

        public void StartGame(List<IPlayerView> playerViews)
        {
            _statController.EndGame();
            _playerController.EndGame();
            _gameController.EndGame();

            var list = new List<Player>();
            int count = 0;
            foreach (var player in playerViews)
            {
                list.Add(new Player(player, new PlayerModel(), count++));
            }
            _playerController.InitPlayers(list);
            _gameController.InitPlayers(list);
            _statController.InitPlayers(list, _gameController.Stats);
        }

        private List<IPlayerView> GetPlayerViewsFromScene()
        {
            var list = Object.FindObjectsOfType<PlayerView>().ToList();
            return new List<IPlayerView>(list);
        }
    }
}