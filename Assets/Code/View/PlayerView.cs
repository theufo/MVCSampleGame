using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Controller;
using Assets.Code.Helper;
using Assets.Code.Model;
using UnityEngine;
using Zenject;

namespace Assets.Code.View
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private GameObject statPrefab;
        public int Id { get; set; }
        public PlayerPanelHierarchy PlayerPanelHierarchy;

        private IPlayerController _playerController;
        private List<StatEntity> stats;

        private bool isDead;
        private float _health;
        public float Health
        {
            get => _health;
            set
            {
                if (isDead)
                    return;

                _health = value;
                UpdateStat(StatType.Health, _health);
            }
        }

        private float _attack;
        public float Attack
        {
            get => GetStat(StatType.Attack);
            set => _attack = value;
        }

        private float _defence;
        public float Defence
        {
            get => GetStat(StatType.Defence);
            set => _defence = value;
        }

        private float _vampire;
        public float Vampire
        {
            get => GetStat(StatType.Vampire);
            set => _vampire = value;
        }

        [Inject]
        public void Construct(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Awake()
        {
            PlayerPanelHierarchy.attackButton.onClick.AddListener(OnAttackButtonClicked);
        }

        public void InitStats(List<StatModel> statModels, List<BuffModel> buffModels = null)
        {
            isDead = false;
            PlayerPanelHierarchy.character.SetInteger("Health", 100);

            if(stats == null)
                stats = new List<StatEntity>();

            foreach (var stat in stats)
                Destroy(stat.gameObject);

            stats.Clear();
            statPrefab = Resources.Load<GameObject>("Prefabs/Stat");
            foreach (var statModel in statModels)
            {
                var stat = Instantiate(statPrefab, PlayerPanelHierarchy.statsPanel.transform).GetComponent<StatEntity>();
                var image = StatImageLoader.LoadStatImage(statModel);
                stat.Init(statModel, image);
                stats.Add(stat);

                switch (stat.StatModel.StatType)
                {
                    case StatType.Health: Health = stat.Value;
                        break;
                    case StatType.Defence: Defence = stat.Value;
                        break;
                    case StatType.Attack: Attack = stat.Value;
                        break;
                    case StatType.Vampire: Vampire = stat.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if(buffModels != null)
                foreach (var buffModel in buffModels)
                {
                    var buff = Instantiate(statPrefab, PlayerPanelHierarchy.statsPanel.transform).GetComponent<StatEntity>();
                    var image = StatImageLoader.LoadStatImage(buffModel);
                    buff.Image.sprite = image;
                    buff.Text.text = buffModel.Title;
                    stats.Add(buff);
                }
        }

        public void UpdateStat(StatType statType, float value)
        {
            var stat = stats.FirstOrDefault(x => x.StatModel.StatType == statType);
            if (stat != null)
                stat.UpdateValue(value);
        }

        public float GetStat(StatType statType)
        {
            var stat = stats.FirstOrDefault(x => x.StatModel.StatType == statType);
            if (stat != null)
                return stat.Value;

            return 0;
        }

        public void Die()
        {
            isDead = true;

            PlayerPanelHierarchy.character.SetInteger("Health", 0);
        }

        private void OnAttackButtonClicked()
        {
            if (isDead)
                return;

            _playerController.OnAttack(Id, Attack);
            PlayerPanelHierarchy.character.SetTrigger("Attack");
        }
    }
}