using System;
using Code.Character;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Menu
{
    public class CharacterPreview : MonoBehaviour
    {
        // Outlets
        public Camera overlayCamera;
        public CharacterClass[] classes;
        public HorizontalSelector classSelector;
        public PanelManager panelManager;
        public LongPressButton rotateRight;
        public LongPressButton rotateLeft;
        
        // Configuration
        public Vector3 offset;
        public int panelIndex;
        public float rotationSpeed = 75;
        
        // State
        private int _classIndex;
        private int _rotateDirection;

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