using System;
using UnityEngine;

namespace Tutorial
{
    [RequireComponent(typeof(Collider))]
    public class TutorialLocationPrompt : TutorialPrompt
    {
        public float timeToComplete = 2f;

        private void OnTriggerStay(Collider other)
        {
            if (IsComplete)
            {
                return;
            }

            timeToComplete -= Time.deltaTime;
            if (timeToComplete <= 0)
            {
                Debug.Log($"Location {gameObject.name} tutorial completed");
                IsComplete = true;
            }
        }
    }
}