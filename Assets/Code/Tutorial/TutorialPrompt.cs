using UnityEngine;

namespace Tutorial
{
    public class TutorialPrompt : MonoBehaviour
    {
        // State
        public bool IsComplete { get; protected set; }
        protected bool isActivated;
        
        // Configuration
        [TextArea(1, 3)]
        public string promptText;

        public virtual void Activate()
        {
            if (!IsComplete)
            {
                isActivated = true;
            }
        }

        public virtual void Deactivate()
        {
            
        }
    }
}