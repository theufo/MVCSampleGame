using Assets.Code.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Helper
{
    public class StatEntity : MonoBehaviour
    {
        public Image Image;
        public Text Text;
        public StatModel StatModel;
        public StatType StatType;
        public float Value;

        public void Init(StatModel statModel, Sprite sprite)
        {
            StatModel = statModel;
            Value = statModel.Value;
            StatType = statModel.StatType;

            Text.text = $"{StatModel.Title} {Value}";
            Image.sprite = sprite;
        }

        public void UpdateValue(float value)
        {
            Value = value;
            Text.text = $"{StatModel.Title} {Value}";
        }
    }
}