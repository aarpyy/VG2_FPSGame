using System.Collections;
using JUTPS;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    public class DeathManager : MonoBehaviour
    {
        // Outlets
        // public GameObject deathScreen;
        private JUCharacterController _characterController;
        
        private void Start()
        {
            _characterController = FindObjectOfType<JUCharacterController>();
        }

        private void Update()
        {
            if (_characterController.IsDead)
            {
                // deathScreen.SetActive(true);
                StartCoroutine(DelayedRestart());
            }
        }
        
        private IEnumerator DelayedRestart()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(0);
        }
    }
}