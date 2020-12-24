using System;

namespace Assets.Code.Model
{
    public class PlayerModel
    {
        public int Id { get; set; }


        private float _health;
        public float Health
        {
            get => _health;
            set
            {
                if (_health == value)
                    return;
                _health = value;
                OnHealthChange?.Invoke(Id, _health);
            }
        }
        public Action<int, float> OnHealthChange;

        private float _maxHealth;
        public float MaxHealth
        {
            get => _maxHealth;
            set
            {
                if (_maxHealth == value)
                    return;
                _maxHealth = value;
                OnMaxHealthChange?.Invoke(Id, _maxHealth);
            }
        }
        public Action<int, float> OnMaxHealthChange;

        private float _attack;
        public float Attack
        {
            get => _attack;
            set
            {
                if (_attack == value)
                    return;
                _attack = value;
                OnAttackChange?.Invoke(Id, _attack);
            }
        }
        public Action<int, float> OnAttackChange;

        private float _defense;
        public float Defense
        {
            get => _defense;
            set
            {
                if (_defense == value)
                    return;
                _defense = value;
                OnDefenseChange?.Invoke(Id, _defense);
            }
        }
        public Action<int, float> OnDefenseChange;

        private float _vampire;
        public float Vampire
        {
            get => _vampire;
            set
            {
                if (_vampire == value)
                    return;
                _vampire = value;
                OnVampireChange?.Invoke(Id, _vampire);
            }
        }
        public Action<int, float> OnVampireChange;

        public bool CanAttack { get; set; }
    }
}