using JUTPS;
using JUTPS.CameraSystems;
using UnityEngine;

namespace Code.Character
{
    public class CharacterClassController : MonoBehaviour
    {
        public JUCameraController cameraController;
        
        public static CharacterClassController Instance { get; private set; }
        public JUCharacterController ActiveController { get; private set; }
        public CharacterClass ActiveClass { get; private set; }
        public JUHealth ActiveHealth { get; private set; }
        
        private void Awake()
        {
            Instance = this;
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
        }
    }
}