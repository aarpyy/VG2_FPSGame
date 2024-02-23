using System;
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

        private void Start()
        {
            // If player does not have limited sprint, don't need the bar
            if (!CharacterClassController.Instance.ActiveClass.sprint || CharacterClassController.Instance.ActiveClass.unlimitedSprint)
            {
                _sprintBar.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            var characterClass = CharacterClassController.Instance.ActiveClass;
            if (!characterClass.sprint) return;
            _sprintBar.SetValue(characterClass.SprintPercentage * 100f);
        }
    }
}