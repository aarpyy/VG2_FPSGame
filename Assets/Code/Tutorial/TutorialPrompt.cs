using UnityEngine;

namespace Tutorial
{
    public class TutorialPrompt : MonoBehaviour
    {
        // State
        public bool IsComplete { get; protected set; }
        
        // Configuration
        [TextArea(1, 3)]
        public string promptText;
    }
}