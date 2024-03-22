using System;
using Code.Attributes;
using Code.Utils;
using UnityEngine.InputSystem;

namespace Tutorial
{
    public class TutorialInputActionPrompt : TutorialPrompt
    {
        // Outlets

        // Action to complete in order to progress in this tutorial stage
        public InputActionReference[] completionActions;
        
        // Configuration
        public bool requiresDuration;
        
        [ConditionalField("requiresDuration", true, ComparisonType.Equals)]
        public float timeToComplete = 1f;

        protected void Awake()
        {
            if (!requiresDuration)
            {
                timeToComplete = 0;
            }
        }

        protected void OnEnable()
        {
            foreach (var completionAction in completionActions) 
            {
                completionAction.action.Enable();
            }
        }
        
        protected void OnDisable()
        {
            foreach (var completionAction in completionActions) 
            {
                completionAction.action.Disable();
            }
        }
    }
}