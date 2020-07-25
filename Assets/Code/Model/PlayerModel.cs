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
                OnHealthChange?.Invoke(Id,_health);
            }
        }
        public delegate void OnHealthChangeDelegate(int playerId, float newVal);
        public event OnHealthChangeDelegate OnHealthChange;

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
        public delegate void OnAttackChangeDelegate(int playerId, float newVal);
        public event OnAttackChangeDelegate OnAttackChange;

        private float _defence;
        public float Defence
        {
            get => _defence;
            set
            {
                if (_defence == value) 
                    return;
                _defence = value;
                OnDefenceChange?.Invoke(Id, _defence);
            }
        }
        public delegate void OnDefenceChangeDelegate(int playerId, float newVal);
        public event OnDefenceChangeDelegate OnDefenceChange;

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
        public delegate void OnVampireChangeDelegate(int playerId, float newVal);
        public event OnVampireChangeDelegate OnVampireChange;
    }
}