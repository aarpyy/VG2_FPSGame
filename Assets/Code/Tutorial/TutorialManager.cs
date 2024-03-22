using System;
using System.Linq;
using JUTPS.JUInputSystem;
using Michsky.UI.Heat;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        // Outlets
        public TutorialPrompt[] prompts;
        private JUInputManager _inputManager;
        public TMP_Text text;

        // State
        private int _promptIndex;
        private bool _started;

        private void Awake()
        {
            // Disable everything to prevent bug that occurs when user inputs an action before the tutorial starts
            InputSystem.DisableAllEnabledActions();
            
            _inputManager = FindObjectOfType<JUInputManager>();
            if (_inputManager == null)
            {
                Debug.LogError("No input manager found in scene");
            }
        }

        private void Update()
        {
            if (_promptIndex >= prompts.Length)
            {
                return;
            }

            if (!_started)
            {
                // Once the input manager loads the InputActions property, we can start the tutorial
                if (_inputManager.InputActions == null)
                {
                    return;
                }

                // Disable all prompt actions so they can't skip ahead in the tutorial
                foreach (var prompt in prompts)
                {
                    prompt.enabled = false;
                }

                _started = true;

                // Enable the first prompt
                prompts[0].enabled = true;
                text.SetText(prompts[0].promptText);
            }

            if (prompts[_promptIndex].IsComplete)
            {
                Debug.Log($"{prompts[_promptIndex].gameObject.name} tutorial completed");
                _promptIndex++;
                if (_promptIndex < prompts.Length)
                {
                    prompts[_promptIndex].enabled = true;
                    text.SetText(prompts[_promptIndex].promptText);
                }
                else
                {
                    text.gameObject.GetComponentInParent<RectTransform>().gameObject.SetActive(false);
                }
            }
        }
    }
}