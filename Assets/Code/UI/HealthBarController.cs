using System;
using Code.Character;
using Michsky.UI.Heat;
using UnityEngine;

namespace Code.UI
{
    [RequireComponent(typeof(ProgressBar))]
    public class HealthBarController : MonoBehaviour
    {
        private ProgressBar _healthBar;

        private void Awake()
        {
            _healthBar = GetComponent<ProgressBar>();
        }

        private void Start()
        {
            _healthBar.maxValue = CharacterClassController.Instance.ActiveHealth.MaxHealth;
            _healthBar.SetValue(CharacterClassController.Instance.ActiveHealth.Health);
        }

        private void Update()
        {
            var health = CharacterClassController.Instance.ActiveHealth;
            _healthBar.SetValue(health.Health);
        }
    }
}