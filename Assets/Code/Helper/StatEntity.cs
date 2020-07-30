using Assets.Code.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Helper
{
    public class StatEntity : MonoBehaviour
    {
        public Image Image;
        public Text Text;
        public IBaseStat StatModel;
        public StatType StatType;
        public float Value;

        public void Init(IBaseStat baseStat, Sprite sprite)
        {
            StatModel = baseStat;

            Text.text = $"{StatModel.Title}";
            Image.sprite = sprite;

            if (baseStat is StatModel statModel)
            {
                UpdateValue(statModel.Value);
                StatType = statModel.StatType;

                statModel.OnValueChange += StatModel_OnValueChange;
            }
        }

        private void StatModel_OnValueChange(float newVal)
        {
            UpdateValue(newVal);
        }

        public void UpdateValue(float value)
        {
            Value = value;
            Text.text = $"{StatModel.Title} {Value}";
        }
    }
}