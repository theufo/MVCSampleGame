﻿using System;
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
        private GameObject _statPrefab;

        public int Id { get; set; }
        public PlayerPanelHierarchy PlayerPanelHierarchy;

        [SerializeField]
        private HealthBar _healthBar;

        public HealthBar HealthBar
        {
            get => _healthBar;
            set => _healthBar = value;
        }

        private IPlayerController _playerController;
        private IStatController _statController;
        private List<StatEntity> stats;

        private bool _isDead;
        private float _health;
        public float Health
        {
            get => stats.FirstOrDefault(x => x.StatType == StatType.Health).Value;
            set
            {
                if (_isDead)
                    return;
                _health = value;
                _statController.UpdateStat(Id, StatType.Health, _health);
            }
        }

        private float _attack;
        public float Attack
        {
            get => _statController.GetStat(Id, StatType.Attack);
            set => _statController.UpdateStat(Id, StatType.Attack, value);
        }

        private float _defense;
        public float Defense
        {
            get => _statController.GetStat(Id, StatType.Defense);
            set => _defense = value;
        }

        private float _vampire;
        public float Vampire
        {
            get => _statController.GetStat(Id, StatType.Vampire);
            set => _vampire = value;
        }

        [Inject]
        public void Construct(IPlayerController playerController, IStatController statController)
        {
            _playerController = playerController;
            _statController = statController;
        }

        public void Awake()
        {
            PlayerPanelHierarchy.attackButton.onClick.AddListener(OnAttackButtonClicked);
            _statPrefab = Resources.Load<GameObject>("Prefabs/Stat");
            stats = new List<StatEntity>();
        }

        public void Die()
        {
            _isDead = true;

            PlayerPanelHierarchy.character.SetInteger("Health", 0);
        }

        public void AddStat(IBaseStat baseStat)
        {
            var stat = Instantiate(_statPrefab, PlayerPanelHierarchy.statsPanel.transform).GetComponent<StatEntity>();
            var image = StatImageLoader.LoadStatImage(baseStat);
            stat.Init(baseStat, image);
            stats.Add(stat);

            if (baseStat is StatModel statModel)
            {
                switch (statModel.StatType)
                {
                    case StatType.Health:
                        Health = stat.Value;
                        _playerController.SetMaxHealth(Id, stat.Value);
                        _playerController.SetHealth(Id, stat.Value);
                        break;
                    case StatType.Defense:
                        Defense = stat.Value;
                        _playerController.SetDefense(Id, stat.Value);
                        break;
                    case StatType.Attack:
                        Attack = stat.Value;
                        _playerController.SetAttack(Id, stat.Value);
                        break;
                    case StatType.Vampire:
                        Vampire = stat.Value;
                        _playerController.SetVampire(Id, stat.Value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void ClearStats()
        {
            if (stats == null)
                stats = new List<StatEntity>();

            foreach (var stat in stats)
                Destroy(stat.gameObject);

            stats.Clear();

            _isDead = false;
            PlayerPanelHierarchy.character.SetInteger("Health", 100);
        }

        private void OnAttackButtonClicked()
        {
            if (_isDead)
                return;

            if (_playerController.CanAttack(Id))
            {
                _playerController.OnAttack(Id, Attack);
                PlayerPanelHierarchy.character.SetTrigger("Attack");
            }
        }
    }
}