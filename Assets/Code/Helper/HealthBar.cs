using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Helper
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _healthBar;

        [SerializeField]
        private GameObject _healthBarText;

        private float maxValue;
        private float previousValue;
        private float _updateSpeedSeconds = .3f;

        public void Init(Player player)
        {
            maxValue = player.PlayerModel.MaxHealth;
            player.PlayerModel.OnHealthChange += OnHealthChanged;
            player.PlayerModel.OnMaxHealthChange += OnMaxHealthChanged;
        }

        private void OnMaxHealthChanged(int arg1, float value)
        {
            maxValue = value;
            previousValue = value;
        }

        private void OnHealthChanged(int arg1, float value)
        {
            StartCoroutine(ChangeHealth(value / maxValue));
            StartCoroutine(ShowDamage(value - previousValue));
            previousValue = value;
        }

        private IEnumerator ShowDamage(float value)
        {
            if (Math.Abs(value) > 0.1f)
            {
                _healthBarText.GetComponent<Text>().text = value.ToString();
                _healthBarText.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                _healthBarText.gameObject.SetActive(false);
            }
        }

        private IEnumerator ChangeHealth(float health)
        {
            var preChangePercent = _healthBar.fillAmount;
            var elapsed = 0f;
            while (elapsed < _updateSpeedSeconds)
            {
                elapsed += Time.deltaTime;
                _healthBar.fillAmount = Mathf.Lerp(preChangePercent, health, elapsed / _updateSpeedSeconds);
                yield return null;
            }

            _healthBar.fillAmount = health;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
        }
    }
}
