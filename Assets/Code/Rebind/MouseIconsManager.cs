using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.UI
{
    public class MouseIconsManager : MonoBehaviour
    {
        [Serializable]
        public struct MouseIcons
        {
            public Sprite leftButton;
            public Sprite rightButton;
            public Sprite middleButton;
            public Sprite scrollWheel;
            
            public Sprite GetSprite(string controlPath)
            {
                return controlPath switch
                {
                    "leftButton" => leftButton,
                    "rightButton" => rightButton,
                    "middleButton" => middleButton,
                    "scrollWheel" => scrollWheel,
                    _ => null
                };
            }
        }
        
        public MouseIcons mouseIcons;

        public void OnUpdateBindingDisplay(RebindActionUI component, string bindingDisplayString, string deviceLayoutName, string controlPath)
        {
            if (string.IsNullOrEmpty(deviceLayoutName) || string.IsNullOrEmpty(controlPath))
                return;

            var isMouse = InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Mouse");
            
            var icon = isMouse ? mouseIcons.GetSprite(controlPath) : null;
            var buttonManager = component.buttonManager;
            
            if (icon != null)
            {
                buttonManager.enableIcon = true;
                buttonManager.enableText = false;
                buttonManager.SetIcon(icon);
            }
            else if (buttonManager.enableIcon)
            {
                buttonManager.enableIcon = false;
                buttonManager.enableText = true;
                buttonManager.UpdateUI();
            }
        }
        
        protected void OnEnable()
        {
            // Hook into all updateBindingUIEvents on all RebindActionUI components in our hierarchy.
            var rebindUIComponents = transform.GetComponentsInChildren<RebindActionUI>();
            foreach (var component in rebindUIComponents)
            {
                component.updateBindingUIEvent.AddListener(OnUpdateBindingDisplay);
                component.UpdateBindingDisplay();
            }
        }

    }
}