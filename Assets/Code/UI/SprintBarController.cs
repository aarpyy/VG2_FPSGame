using Michsky.UI.Heat;
using UnityEngine;
using Code.Character;

namespace Code.UI
{
    [RequireComponent(typeof(ProgressBar))]
    public class SprintBarController : MonoBehaviour
    {
        private ProgressBar _sprintBar;

        private void Awake()
        {
            _sprintBar = GetComponent<ProgressBar>();
        }

        private void Update()
        {
            var characterClass = CharacterClassController.ActiveClass;
            _sprintBar.SetValue(characterClass.SprintPercentage * 100f);
        }
    }
}