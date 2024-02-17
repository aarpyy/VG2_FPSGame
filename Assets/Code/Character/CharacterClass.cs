using JUTPS;
using JUTPS.InventorySystem;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(JUInventory), typeof(JUHealth))]
    public class CharacterClass : MonoBehaviour
    {
        public string title;
        public bool dash;
        public bool doubleJump;
    }
}