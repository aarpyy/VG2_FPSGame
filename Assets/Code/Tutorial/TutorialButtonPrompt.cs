using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Tutorial
{
    public class TutorialButtonPrompt : TutorialInputActionPrompt
    {
        // State
        private readonly Dictionary<ButtonControl, bool> _keyControls = new();

        private void Start()
        {
            var i = 1;
            foreach (var completionAction in completionActions)
            {
                completionAction.action.performed += OnAction;
                foreach (var control in completionAction.action.controls)
                {
                    if (control is not ButtonControl keyControl)
                    {
                        continue;
                    }
                    _keyControls.TryAdd(keyControl, false);
                    
                    promptText = promptText.Replace($"${i++}", $"<b>{keyControl.displayName}</b>");
                }
            }
        }

        private void Update()
        {
            if (IsComplete)
            {
                return;
            }
            
            // If the action has been triggered, set complete. If there are multiple actions (i.e. wasd),
            // then all of them must be triggered to complete the prompt
            // foreach (var keyControl in _keyControls.Keys.ToList().Where(key => key.isPressed))
            // {
            //     _keyControls[keyControl] += Time.deltaTime;
            // }
            
            if (_keyControls.All(control => control.Value))
            {
                IsComplete = true;
            }
        }

        private void OnAction(InputAction.CallbackContext ctx)
        {
            // Get the control that was used
            var control = ctx.control;
            if (control is not ButtonControl keyControl)
            {
                return;
            }
            
            // If the control is in the list of controls, then set the time to complete to the time to complete
            if (_keyControls.ContainsKey(keyControl))
            {
                _keyControls[keyControl] = true;
            }
        }
    }
}