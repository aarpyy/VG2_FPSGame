using System;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Character
{
    [RequireComponent(typeof(HorizontalSelector))]
    public class CharacterClassSelector : MonoBehaviour
    {
        [Serializable]
        public struct SelectableCharacterClass
        {
            public CharacterClass characterClass;
            public RenderTexture characterPreview;
        }
        
        // The currently selected character class
        public static int SelectedCharacterClass { get; private set; }
        
        // The character classes to choose from
        public SelectableCharacterClass[] characterClassPrefabs;
        
        public RawImage previewImage;
        
        // The horizontal selector to use for choosing the character class
        private HorizontalSelector _horizontalSelector;
        
        private void Awake()
        {
            _horizontalSelector = GetComponent<HorizontalSelector>();
            UpdateCharacterClassSelector();
            
            _horizontalSelector.onValueChanged.AddListener(OnCharacterClassSelected);
        }
        
        // Update the character class selector with the class names
        private void UpdateCharacterClassSelector()
        {
            _horizontalSelector.items.Clear();
            foreach (var characterClass in characterClassPrefabs)
            {
                _horizontalSelector.CreateNewItem(characterClass.characterClass.title);
            }
            _horizontalSelector.InitializeSelector();
            
            // Select the first character class by default
            OnCharacterClassSelected(_horizontalSelector.defaultIndex);
        }

        private void OnCharacterClassSelected(int index)
        {
            if (index < 0 || index >= characterClassPrefabs.Length)
            {
                Debug.LogError("Invalid character class index: " + index);
                return;
            }

            SelectedCharacterClass = characterClassPrefabs[index].characterClass.classID;
            previewImage.texture = characterClassPrefabs[index].characterPreview;
        }

        private void OnDestroy()
        {
            previewImage.texture = null;
        }
    }
}
