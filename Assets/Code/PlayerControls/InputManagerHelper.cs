using Code.Menu;
using JUTPS.JUInputSystem;
using Michsky.UI.Heat;
using UnityEngine;

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
        }
    }
}