using System;
using JUTPS;
using Michsky.UI.Heat;
using UnityEngine;

namespace Code.Character
{
    public class CharacterClassController : MonoBehaviour
    {
        public static JUCharacterController ActiveController { get; private set; }
        public static CharacterClass ActiveClass { get; private set; }
        public static JUHealth ActiveHealth { get; private set; }

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
        }
    }
}