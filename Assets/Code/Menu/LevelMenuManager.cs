using Michsky.UI.Heat;
using UnityEngine;

namespace Code.Menu
{
    public class LevelMenuManager : MonoBehaviour
    {
        private PauseMenuManager _pauseMenuManager;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _pauseMenuManager = GetComponentInChildren<PauseMenuManager>();
            DisableLevelMenu();
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