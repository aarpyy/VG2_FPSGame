using System;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    [RequireComponent(typeof(PauseMenuManager))]
    public class PauseMenuHelper : MonoBehaviour
    {
        // Outlets
        private PauseMenuManager _pauseMenuManager;
        
        // State
        private bool _canOpenMenu = true;
        
        private void Awake()
        {
            _pauseMenuManager = GetComponent<PauseMenuManager>();
            _pauseMenuManager.onOpen.AddListener(OnOpen);
            _pauseMenuManager.onClose.AddListener(OnClose);
        }

        private void Update()
        {
            if (DeathManager.Instance != null && DeathManager.Instance.IsOpen)
            {
                _pauseMenuManager.gameObject.SetActive(false);
                _canOpenMenu = false;
            }
            else if (!_canOpenMenu)
            {
                _pauseMenuManager.gameObject.SetActive(true);
                _canOpenMenu = true;
            }
        }

        private static void OnOpen()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        private static void OnClose()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void OnExit()
        {
            SceneManager.LoadScene(0);
        }
    }
}