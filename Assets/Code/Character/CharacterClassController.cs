using System;
using JUTPS;
using Michsky.UI.Heat;
using UnityEngine;

namespace Code.Character
{
    public class CharacterClassController : MonoBehaviour
    {
        public ProgressBar healthBar;
        public ProgressBar sprintBar;
        public float sprintBarDecreaseRate = 0.1f;
        public float sprintBarIncreaseRate = 0.2f;

        private JUHealth _health;
        private JUCharacterController _characterController;
        private float _sprintBarValue;
        private float _playerSpeed;

        private void Awake()
        {
            LoadCharacterClass(CharacterClassSelector.SelectedCharacterClass);
        }

        public void LoadCharacterClass(CharacterClass characterClass)
        {
            if (characterClass == null)
            {
                Debug.LogError("Character class is null");
                return;
            }

            // Clear the current character class
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            var instantiated = Instantiate(characterClass, transform, true);

            _health = instantiated.GetComponent<JUHealth>();
            if (_health == null)
            {
                Debug.LogError("Character class does not have a health component");
                return;
            }

            _characterController = instantiated.GetComponent<JUCharacterController>();
            if (_characterController == null)
            {
                Debug.LogError("Character class does not have a character controller component");
                return;
            }
            _playerSpeed = _characterController.Speed;

            healthBar.maxValue = _health.MaxHealth;
            healthBar.currentValue = _health.Health;
            healthBar.minValue = 0;

            _sprintBarValue = 1.0f;
            sprintBar.SetValue(100);
        }

        private void Update()
        {
            if (_health == null)
            {
                return;
            }

            healthBar.SetValue(_health.Health);

            if (_characterController == null)
            {
                return;
            }

            if (_characterController.IsRunning)
            {
                _sprintBarValue -= sprintBarDecreaseRate * Time.deltaTime;
            }
            else
            {
                _sprintBarValue += sprintBarIncreaseRate * Time.deltaTime;
            }
            
            _sprintBarValue = Mathf.Clamp(_sprintBarValue, 0.0f, 1.0f);
            sprintBar.SetValue(_sprintBarValue * 100f);
            
            if (_sprintBarValue <= 0.0f)
            {
                _characterController.Speed = _playerSpeed / 2.0f;
            }
            else if (Math.Abs(_characterController.Speed - _playerSpeed) > 0.001f)
            {
                _characterController.Speed = _playerSpeed;
            }
        }
    }
}