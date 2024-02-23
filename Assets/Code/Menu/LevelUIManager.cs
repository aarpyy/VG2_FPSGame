using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    public class LevelUIManager : MonoBehaviour
    {
        private PauseMenuManager _pauseMenuManager;
        public LevelUIManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _pauseMenuManager = GetComponentInChildren<PauseMenuManager>(true);
            DisableLevelMenu();
            
            SceneManager.activeSceneChanged += (_, curr) =>
            {
                if (curr.buildIndex != 0)
                {
                    EnableLevelMenu();
                }
                else
                {
                    DisableLevelMenu();
                }
            };
        }

        public void EnableLevelMenu()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            
            // Pause menu is default closed, it will be opened by the pause menu manager
            _pauseMenuManager.pauseMenuCanvas.SetActive(false);
        }
        
        public void DisableLevelMenu()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}