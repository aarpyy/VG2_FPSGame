using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    public class LevelUIManager : MonoBehaviour
    {
        // Outlets
        public GameObject pauseMenuPrefab;
        private GameObject _pauseMenu;

        // State
        private static bool _isInScene = false;
        
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
        }
        
        private void DisableLevelMenu()
        {
            if (_pauseMenu == null) return;
            Destroy(_pauseMenu);
            _pauseMenu = null;
        }

        // public void EnableLevelMenu()
        // {
        //     foreach (Transform child in transform)
        //     {
        //         child.gameObject.SetActive(true);
        //     }
        //     
        //     // Pause menu is default closed, it will be opened by the pause menu manager
        //     _pauseMenuManager.pauseMenuCanvas.SetActive(false);
        // }
        
        private void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}