using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    [RequireComponent(typeof(PauseMenuManager))]
    public class PauseMenuHelper : MonoBehaviour
    {
        private void Awake()
        {
            var pauseMenuManager = GetComponent<PauseMenuManager>();
            pauseMenuManager.onOpen.AddListener(OnOpen);
            pauseMenuManager.onClose.AddListener(OnClose);
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