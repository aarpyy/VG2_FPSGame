using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Tutorial
{
    public class TutorialDeltaPrompt : TutorialInputActionPrompt
    {
        // State
        private readonly Dictionary<DeltaControl, Dictionary<Vector2, float>> _controls = new();

        protected void Start()
        {
            var i = 1;
            foreach (var completionAction in completionActions)
            {
                foreach (var control in completionAction.action.controls)
                {
                    if (control is not DeltaControl deltaControl)
                    {
                        continue;
                    }
                    _controls.TryAdd(deltaControl, new Dictionary<Vector2, float>
                    {
                        {
                            Vector2.up, 0
                        },
                        {
                            Vector2.down, 0
                        },
                        {
                            Vector2.left, 0
                        },
                        {
                            Vector2.right, 0
                        }
                    });
                    
                    promptText = promptText.Replace($"${i++}", $"<b>{deltaControl.device.displayName}</b>");
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
            foreach (var axis in _controls.Keys.ToList().Where(key => key.value != Vector2.zero))
            {
                // For all directions this control is currently moving in, set the control to true
                foreach (var direction in _controls[axis].Keys.ToList())
                {
                    if (Vector2.Dot(axis.value, direction) > 0)
                    {
                        _controls[axis][direction] += Time.deltaTime;
                    }
                }
            }

            if (_controls.All(control => control.Value.All(direction => direction.Value > timeToComplete)))
            {
                IsComplete = true;
            }
        }
    }
}