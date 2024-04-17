using Code.Character;
using UnityEngine;

namespace Code.MiniMap
{
    public class MiniMapPlayerController : MonoBehaviour
    {
        private void Update()
        {
            var characterClass = CharacterClassController.Instance;
            if (!characterClass) return;
            
            var character = characterClass.ActiveClass;
            if (!character) return;
            
            var characterTransform = character.transform;
            var rotation = characterTransform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, 0, -rotation);
        }
    }
}