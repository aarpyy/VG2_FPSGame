using System;
using UnityEngine;

namespace Code.Character
{
    public class CharacterClassController : MonoBehaviour
    {
        public CharacterClass characterClassPrefab;

        private void Awake()
        {
            if (characterClassPrefab == null)
            {
                throw new NullReferenceException("Character class prefab is not set.");
            }
            LoadCharacterClass();
        }
        
        public void LoadCharacterClass()
        {
            // Clear the current character class
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            Instantiate(characterClassPrefab, transform, true);
        }
    }
}