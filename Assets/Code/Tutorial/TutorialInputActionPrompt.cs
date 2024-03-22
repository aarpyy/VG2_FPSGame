using UnityEngine.InputSystem;

namespace Tutorial
{
    public class TutorialInputActionPrompt : TutorialPrompt
    {
        // Outlets

        // Action to complete in order to progress in this tutorial stage
        public InputActionReference[] completionActions;
    }
}