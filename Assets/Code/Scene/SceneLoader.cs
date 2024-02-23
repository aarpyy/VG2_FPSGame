using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        private int _sceneIndex = -1;
        private string _sceneName;
        
        public void LoadScene()
        {
            if (_sceneIndex == -1)
            {
                SceneManager.LoadScene(_sceneName);
            }
            else
            {
                SceneManager.LoadScene(_sceneIndex);
            }
        }
        
        public static void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        
        public void SetScene(string sceneName)
        {
            _sceneName = sceneName;
        }
        
        public void SetScene(int sceneIndex)
        {
            _sceneIndex = sceneIndex;
        }
    }
}