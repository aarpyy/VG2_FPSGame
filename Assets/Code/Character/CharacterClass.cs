using Code.Attributes;
using Code.Utils;
using JUTPS;
using JUTPS.InventorySystem;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(JUInventory), typeof(JUHealth), typeof(JUCharacterController))]
    public class CharacterClass : MonoBehaviour
    {
        // Configuration
        public string title;
        public int classID;
        
        // State
        [Header("Sprint Settings")]
        public bool sprint;
        
        [ConditionalField("sprint", true, ComparisonType.Equals)]
        public bool unlimitedSprint;
        
        [ConditionalField("unlimitedSprint", false, ComparisonType.Equals)]
        public float sprintBarDecreaseRate = 0.1f;
        [ConditionalField("unlimitedSprint", false, ComparisonType.Equals)]
        public float sprintBarIncreaseRate = 0.2f;
        
        // Outlets
        private JUCharacterController _characterController;
        
        public float SprintPercentage { get; private set; }
        
        private void Awake()
        {
            _characterController = GetComponent<JUCharacterController>();
            _characterController.SprintingSkill = sprint;
            SprintPercentage = 1.0f;
        }

        private void Update()
        {
            if (!sprint || unlimitedSprint) return;
            
            if (_characterController.IsSprinting)
            {
                SprintPercentage -= sprintBarDecreaseRate * Time.deltaTime;
            }
            else
            {
                SprintPercentage += sprintBarIncreaseRate * Time.deltaTime;
            }
            
            SprintPercentage = Mathf.Clamp(SprintPercentage, 0.0f, 1.0f);
    
            // Update the character controller to reflect is player is allowed to sprint
            _characterController.SprintingSkill = SprintPercentage > 0.0001f;
        }
    }
}