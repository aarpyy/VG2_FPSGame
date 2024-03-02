using System;
using System.Linq;
using JUTPS;
using UnityEngine;

namespace Code.Character
{
    public class CharacterClassController : MonoBehaviour
    {
        // Configuration
        public int classID;
        public CharacterClass[] characterClasses;

        // State
        public static CharacterClassController Instance { get; private set; }
        public JUCharacterController ActiveController { get; private set; }
        public CharacterClass ActiveClass { get; private set; }
        public JUHealth ActiveHealth { get; private set; }
        private Action<CharacterClass> _onCharacterClassChanged;
        
        private void Start()
        {
            if (characterClasses.Length == 0)
            {
                Debug.LogError("No character classes are defined");
                return;
            }
            
            if (Instance != null)
            {
                Debug.LogError("There is more than one CharacterClassController in the scene");
                return;
            }
            
            Instance = this;
            var characterClass = characterClasses.FirstOrDefault(cls => cls.classID == classID);
            if (characterClass == default(CharacterClass))
            {
                characterClass = characterClasses[0];
            }
            
            LoadCharacterClass(characterClass);
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
            instantiated.transform.localPosition = Vector3.zero;
            ActiveClass = instantiated.GetComponent<CharacterClass>();

            ActiveHealth = instantiated.GetComponent<JUHealth>();
            if (ActiveHealth == null)
            {
                Debug.LogError("Character class does not have a health component");
                return;
            }

            ActiveController = instantiated.GetComponent<JUCharacterController>();
            if (ActiveController == null)
            {
                Debug.LogError("Character class does not have a character controller component");
            }
            
            _onCharacterClassChanged?.Invoke(characterClass);
        }
        
        public void AddCharacterClassChangedListener(Action<CharacterClass> listener)
        {
            _onCharacterClassChanged += listener;
        }
    }
}