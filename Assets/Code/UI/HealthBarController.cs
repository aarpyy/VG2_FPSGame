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

        private void Update()
        {
            var health = CharacterClassController.ActiveHealth;
            _healthBar.SetValue(health.Health);
        }
    }
}