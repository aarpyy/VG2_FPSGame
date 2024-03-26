using System.Collections;
using JUTPS.DestructibleSystem;
using JUTPS.JUInputSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        // Outlets
        public TutorialPrompt[] prompts;
        private JUInputManager _inputManager;
        public TMP_Text text;
        public GameObject textParent;
        public DestructibleObject toDestroy;

        // State
        private int _promptIndex;

        // Configuration
        public float minPromptTime = 3f;
        public float promptSeparationTime = 1f;
        public float promptHangTime = 0.5f;
        private float _timer;

        private void Awake()
        {
            _inputManager = FindObjectOfType<JUInputManager>();
            if (_inputManager == null)
            {
                Debug.LogError("No input manager found in scene");
            }
        }

        private void Start()
        {
            StartCoroutine(StartPrompt());
        }

        private IEnumerator StartPrompt()
        {
            if (_promptIndex > 0)
            {
                // Let last prompt hang for a bit - only if it's not the first prompt
                yield return new WaitForSeconds(promptHangTime);
            }
            
            // Disable previous prompt
            textParent.SetActive(false);
            
            // Allow for separation time between prompts
            yield return new WaitForSeconds(promptSeparationTime);
            
            // Enable prompt and display text
            textParent.SetActive(true);
            prompts[_promptIndex].Activate();
            text.SetText(prompts[_promptIndex].promptText);
            
            // Start timer for minimum prompt display time
            _timer = minPromptTime;
        }

        private static IEnumerator OnComplete()
        {
            yield return new WaitForSeconds(3);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }

        private void Update()
        {
            if (toDestroy.IsFractured)
            {
                textParent.SetActive(true);
                text.SetText("Tutorial complete!\nReturning to main menu...");
                StartCoroutine(OnComplete());
            }
            
            if (_promptIndex >= prompts.Length)
            {
                return;
            }

            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                return;
            }

            if (prompts[_promptIndex].IsComplete)
            {
                prompts[_promptIndex].Deactivate();
                Debug.Log($"{prompts[_promptIndex].gameObject.name} tutorial completed");
                _promptIndex++;
                if (_promptIndex < prompts.Length)
                {
                    StartCoroutine(StartPrompt());
                }
                else
                {
                    textParent.SetActive(false);
                }
            }
        }
    }
}