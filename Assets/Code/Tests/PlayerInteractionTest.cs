using System.Collections;
using System.Collections.Generic;
using Assets.Code;
using Assets.Code.Controller;
using Assets.Code.Helper;
using Assets.Code.Model;
using Assets.Code.View;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerInteractionTest
    {
        [UnityTest]
        public IEnumerator AddPlayerGameObjects()
        {
            var playerPrefab = Resources.Load<GameObject>("Prefabs/Player_mock");
            GameObject.Instantiate(playerPrefab);
            var mainScript = new MainScript();
            var stubGameController = new StubGameController();
            var stubPlayerController = new StubPlayerController();
            var stubStatController = new StubStatController();
            mainScript.Construct(stubGameController, stubPlayerController, stubStatController);
            mainScript.StartGame(new List<IPlayerView>(){playerPrefab.GetComponent<StubPlayerView>()});

            Assert.IsTrue(stubGameController.Players.Count > 0 && stubPlayerController.Players.Count > 0);
            yield return null;
        }

        [Test]
        public void PlayerAttack()
        {
            var stubGameController = new StubGameController();
            var playerController = new PlayerController(stubGameController);

            var player1 = new Player(new StubPlayerView(), new PlayerModel(), 1);
            var player2 = new Player(new StubPlayerView(), new PlayerModel(), 2);
            playerController.InitPlayers(new List<Player>(){ player1, player2 });

            playerController.OnAttack(2, 50);

            Assert.True(player1.PlayerModel.Health < 100);
        }

        [Test]
        public void PlayerVampire()
        {
            var stubGameController = new StubGameController();
            var playerController = new PlayerController(stubGameController);

            var player1 = new Player(new StubPlayerView(), new PlayerModel(), 1);
            var player2 = new Player(new StubPlayerView(), new PlayerModel() { Vampire = 25 }, 2);
            playerController.InitPlayers(new List<Player>(){ player1, player2 });

            playerController.OnAttack(2, 50);

            Assert.True(player2.PlayerModel.Health > 100);
        }

        [TearDown]
        public void AfterTest()
        {
            foreach (var gameObject in Object.FindObjectsOfType<PlayerView>())
            {
                Object.Destroy(gameObject);
            }
        }
    }
}