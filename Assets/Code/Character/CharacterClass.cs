using System;
using JUTPS;
using JUTPS.InventorySystem;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(JUInventory), typeof(JUHealth), typeof(JUCharacterController))]
    public class CharacterClass : MonoBehaviour
    {
        // State
        public string title;
        public bool dash;
        public bool doubleJump;
        
        [Header("Sprint")]
        public float sprintBarDecreaseRate = 0.1f;
        public float sprintBarIncreaseRate = 0.2f;
        
        private JUCharacterController _characterController;
        private float _playerSpeed;
        
        public float SprintPercentage { get; private set; }
        
        private void Awake()
        {
            _characterController = GetComponent<JUCharacterController>();
            _playerSpeed = _characterController.Speed;
            SprintPercentage = 1.0f;
        }

        private void Update()
        {
            if (_characterController.IsRunning)
            {
                SprintPercentage -= sprintBarDecreaseRate * Time.deltaTime;
            }
            else
            {
                SprintPercentage += sprintBarIncreaseRate * Time.deltaTime;
            }
            
            SprintPercentage = Mathf.Clamp(SprintPercentage, 0.0f, 1.0f);
            
            // If they have no sprint left, halve their speed
            if (SprintPercentage <= 0.0001f)
            {
                _characterController.Speed = _playerSpeed / 2.0f;
            }
            // Otherwise if they either have sprint or are regenerating it, set their speed back to normal (if changed)
            else if (Math.Abs(_characterController.Speed - _playerSpeed) > 0.0001f)
            {
                _characterController.Speed = _playerSpeed;
            }
        }
    }
}