using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}