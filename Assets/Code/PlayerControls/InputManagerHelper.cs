using System;
using Code.Menu;
using JUTPS.JUInputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerControls
{
    [RequireComponent(typeof(JUInputManager))]
    public class InputManagerHelper : MonoBehaviour
    {
        private JUInputManager _inputManager;
        public LevelUIManager levelUIManager;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _inputManager = GetComponent<JUInputManager>();
            if (!levelUIManager || !_inputManager) return;

            levelUIManager.onOpen.AddListener(() =>
            {
                _inputManager.InputActions.Disable();
            });

            levelUIManager.onClose.AddListener(() =>
            {
                _inputManager.InputActions.Enable();
            });

            SceneManager.sceneLoaded += (scene, _) =>
            {
                _inputManager.enabled = scene.buildIndex != 0;
            };
        }

        private void Start()
        {
            _inputManager.enabled = false;
        }
    }
}