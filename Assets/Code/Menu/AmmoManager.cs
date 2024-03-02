using System;
using Code.Character;
using Michsky.UI.Heat;
using TMPro;
using UnityEngine;

namespace Code.Menu
{
    public class AmmoManager : MonoBehaviour
    {
        public TMP_Text text;
        
        private void Update()
        {
            var characterController = CharacterClassController.Instance.ActiveController;

            var leftWeapon = characterController.WeaponInUseLeftHand;
            var rightWeapon = characterController.WeaponInUseRightHand;

            if (leftWeapon == null && rightWeapon == null) return;

            var weapon = rightWeapon != null ? rightWeapon : leftWeapon;
            text.text = $"{weapon.BulletsAmounts}/{weapon.BulletsPerMagazine}";
        }
    }
}