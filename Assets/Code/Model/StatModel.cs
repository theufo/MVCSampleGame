using Assets.Code.Data;
using Assets.Code.Helper;

namespace Assets.Code.Model
{
    public class StatModel : BaseStat
    {
        public StatType StatType;

        public StatModel(Stat stat)
        {
            Id = stat.id;
            StatType = (StatType)stat.id;
            Value = stat.value;
            Icon = stat.icon;
            Title = stat.title;
        }

        private float _value;
        public float Value
        {
            get => _value;
            set
            {
                if (_value == value)
                    return;
                _value = value;
                OnValueChange?.Invoke(_value);
            }
        }
        public delegate void OnValueChangeDelegate(float newVal);
        public event OnValueChangeDelegate OnValueChange;
    }
}