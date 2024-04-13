using System;
using Code.Character;
using Michsky.UI.Heat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Menu
{
    public class CharacterPreview : MonoBehaviour
    {
        public enum QuestTextState
        {
            Idle,
            Expanding,
            Minimizing
        }
        
        // Outlets
        public Camera overlayCamera;
        public CharacterClass[] classes;
        public HorizontalSelector classSelector;
        public PanelManager panelManager;
        public LongPressButton rotateRight;
        public LongPressButton rotateLeft;
        public QuestItem descriptionText;
        
        // Configuration
        public Vector3 offset;
        public int panelIndex;
        public float rotationSpeed = 75;
        
        // State
        private int _classIndex;
        private int _rotateDirection;
        private QuestTextState _state = QuestTextState.Idle;

        private const string SaveKey = "SelectedCharacterClass";
        
        private void Awake()
        {
            classSelector.onValueChanged.AddListener(OnCharacterClassSelected);
            
            // Update the character class selector with the class names
            classSelector.items.Clear();
            foreach (var characterClass in classes)
            {
                classSelector.CreateNewItem(characterClass.title);
            }
            classSelector.InitializeSelector();
            
            // Select the first character class by default
            OnCharacterClassSelected(classSelector.defaultIndex);
            
            panelManager.onPanelChanged.AddListener(panel =>
            {
                overlayCamera.enabled = panel == panelIndex;
            });
        }
        
        private void OnCharacterClassSelected(int index)
        {
            if (index < 0 || index >= classes.Length)
            {
                Debug.LogError("Invalid character class index: " + index);
                return;
            }
            
            _classIndex = index;
            
            // Set up camera to the proper transform
            overlayCamera.transform.position = classes[_classIndex].transform.position + offset;
            PlayerPrefs.SetInt(SaveKey, classes[_classIndex].classID);
            
            // Minimize previous quest (if there was one)
            // descriptionText.MinimizeQuest();
            if (enabled)
            {
                descriptionText.MinimizeQuest();
            }
            
            _state = QuestTextState.Expanding;
        }

        private void Update()
        {
            if (rotateRight.IsPressing)
            {
                classes[_classIndex].transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            else if (rotateLeft.IsPressing)
            {
                classes[_classIndex].transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            
            switch (_state)
            {
                case QuestTextState.Idle:
                    break;
                case QuestTextState.Expanding:
                    // Wait until gameObject is disabled, then call expand
                    if (!descriptionText.gameObject.activeSelf)
                    {
                        _state = QuestTextState.Idle;
                        // Set the description text
                        descriptionText.questText = classes[_classIndex].description;
                        descriptionText.UpdateUI();
                        descriptionText.ExpandQuest();
                    }
                    break;
                case QuestTextState.Minimizing:
                    if (descriptionText.gameObject.activeSelf)
                    {
                        _state = QuestTextState.Idle;
                        descriptionText.MinimizeQuest();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnEnable()
        {
            overlayCamera.enabled = true;
        }
        
        private void OnDisable()
        {
            if (!overlayCamera) return;
            overlayCamera.enabled = false;
        }
    }
}