using System;
using System.Collections;
using System.Linq;
using Code.Character;
using JUTPS;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Code.Menu
{
    public class DeathManager : MonoBehaviour
    {
        // Outlets
        private JUCharacterController _characterController;
        public GameObject deathScreen;
        public ButtonManager restart;
        public ButtonManager mainMenu;
        public AudioClip deathSound;
        
        // State
        private bool _canOpenMenu = true;
        private CursorLockMode _previousLockMode;
        private bool _previousCursorVisibility;
        
        public static DeathManager Instance { get; private set; }

        public bool IsOpen => !_canOpenMenu;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            restart.onClick.AddListener(() =>
            {
                DisableMenu();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
            mainMenu.onClick.AddListener(() =>
            {
                DisableMenu();
                SceneManager.LoadScene(0);
            });

            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(deathScreen);

            // Everytime a scene loads, look for the character controller after 1 second
            SceneManager.sceneLoaded += (scene, mode) =>
            {
                if (deathScreen.activeSelf)
                {
                    deathScreen.SetActive(false);
                }
                
                var controller = CharacterClassController.Instance;
                if (controller)
                {
                    // Listen for changes in the character class
                    controller.AddCharacterClassChangedListener(cls =>
                    {
                        _characterController = cls.GetComponent<JUCharacterController>();
                    });

                    // If there is already one loaded, grab that
                    if (CharacterClassController.Instance.ActiveController)
                    {
                        _characterController = CharacterClassController.Instance.ActiveController;
                    }
                }
                _canOpenMenu = true;
            };
        }

        private void Update()
        {
            if (!_characterController) return;
            if (_characterController.IsDead && _canOpenMenu)
            {
                _canOpenMenu = false;
                if (deathSound)
                {
                    AudioSource.PlayClipAtPoint(deathSound, _characterController.transform.position);
                }
                StartCoroutine(DelayedMenuOpen());
            }
        }

        private void DisableMenu()
        {
            deathScreen.SetActive(false);
            Cursor.lockState = _previousLockMode;
            Cursor.visible = _previousCursorVisibility;
        }

        private void EnableMenu()
        {
            deathScreen.SetActive(true);
            
            _previousCursorVisibility = Cursor.visible;
            _previousLockMode = Cursor.lockState;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private IEnumerator DelayedMenuOpen()
        {
            yield return new WaitForSeconds(3f);
            EnableMenu();
        }
    }
}