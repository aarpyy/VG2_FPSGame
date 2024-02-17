using System.Collections;
using System.Collections.Generic;
using Michsky.UI.Heat;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(HorizontalSelector))]
    public class CharacterClassSelector : MonoBehaviour
    {
        // The currently selected character class
        public static CharacterClass SelectedCharacterClass { get; private set; }
        
        // The character classes to choose from
        public CharacterClass[] characterClassPrefabs;
        
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
                _horizontalSelector.CreateNewItem(characterClass.title);
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
            
            SelectedCharacterClass = characterClassPrefabs[index];
        }
    }
}
