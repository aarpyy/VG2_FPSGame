using Code.Character;
using UnityEngine;

namespace Code.MiniMap
{
    public class MiniMapPlayerController : MonoBehaviour
    {
        private void Update()
        {
            var character = CharacterClassController.Instance.ActiveClass.transform;
            var rotation = character.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, 0, -rotation);
        }
    }
}