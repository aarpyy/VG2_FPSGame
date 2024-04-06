using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu
{
    [RequireComponent(typeof(Collider))]
    public class LevelCompleteManager : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // If not player, ignore
            if (!other.CompareTag("Player"))
            {
                return;
            }
            
            var scene = SceneManager.GetActiveScene();
            ChapterManager.SetCompleted(scene.name);
            if (scene.buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                var floorNumber = int.Parse(scene.name[5..]);
                ChapterManager.SetUnlocked($"floor {floorNumber + 1}");
                SceneManager.LoadScene(scene.buildIndex + 1);
            }
        }
    }
}