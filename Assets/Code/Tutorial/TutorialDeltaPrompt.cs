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
        private readonly Dictionary<DeltaControl, Dictionary<AxisControl, bool>> _controls = new();

        private void Awake()
        {
            var controlNames = new List<string>();
            completionAction.action.performed += OnAction;
            foreach (var control in completionAction.action.controls)
            {
                if (control is not DeltaControl deltaControl)
                {
                    continue;
                }
                _controls.TryAdd(deltaControl, new Dictionary<AxisControl, bool>
                {
                    {
                        deltaControl.up, false
                    },
                    {
                        deltaControl.left, false
                    },
                    {
                        deltaControl.down, false
                    },
                    {
                        deltaControl.right, false
                    }
                });

                controlNames.Add(deltaControl.device.displayName);
            }

            promptText = promptText.Replace("$1", $"<b>{string.Join('/', controlNames)}</b>");
        }

        private void Update()
        {
            if (IsComplete)
            {
                return;
            }

            if (_controls.Any(control => control.Value.All(direction => direction.Value)))
            {
                IsComplete = true;
            }
        }

        private void OnAction(InputAction.CallbackContext ctx)
        {
            if (!isActivated)
            {
                return;
            }

            if (ctx.control is not DeltaControl deltaControl)
            {
                return;
            }

            if (deltaControl.up.value > 0)
            {
                _controls[deltaControl][deltaControl.up] = true;
            }
            if (deltaControl.left.value > 0)
            {
                _controls[deltaControl][deltaControl.left] = true;
            }
            if (deltaControl.down.value > 0)
            {
                _controls[deltaControl][deltaControl.down] = true;
            }
            if (deltaControl.right.value > 0)
            {
                _controls[deltaControl][deltaControl.right] = true;
            }
        }
    }
}