using System;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    public class LevelUIManager : MonoBehaviour
    {
        // Outlets
        public GameObject pauseMenuPrefab;
        private GameObject _pauseMenu;

        // State
        private static bool _isInScene;
        public UnityEvent onOpen;
        public UnityEvent onClose;
        
        private void Awake()
        {
            if (_isInScene)
            {
                Destroy(gameObject);
                return;
            }
            
            _isInScene = true;
            DontDestroyOnLoad(gameObject);
            
            SceneManager.sceneUnloaded += _ =>
            {
                DisableLevelMenu();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            };
            
            SceneManager.sceneLoaded += (scene, _) =>
            {
                if (scene.buildIndex != 0)
                {
                    EnableLevelMenu();
                }
            };
        }
        
        private void EnableLevelMenu()
        {
            _pauseMenu = Instantiate(pauseMenuPrefab);
            _pauseMenu.GetComponentInChildren<PauseMenuManager>().onOpen.AddListener(() =>
            {
                onOpen.Invoke();
            });
            _pauseMenu.GetComponentInChildren<PauseMenuManager>().onClose.AddListener(() =>
            {
                onClose.Invoke();
            });
        }
        
        private void DisableLevelMenu()
        {
            if (_pauseMenu == null) return;
            Destroy(_pauseMenu);
            _pauseMenu = null;
        }
        
        private void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}