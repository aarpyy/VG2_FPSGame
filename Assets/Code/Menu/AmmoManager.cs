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
        
        private bool _isDisplaying;
        
        /*
         * Hierarchical structure of this component needs to be that the components that make
         * up the actual ammo display are children of this game objects sole child. This
         * enables the AmmoManager to enable/disable the entire ammo display through
         * controlling its only child.
         */
        private GameObject _child;
        
        private void Start()
        {
            _child = transform.GetChild(0).gameObject;
            if (transform.childCount != 1)
            {
                Debug.LogError("AmmoManager must have exactly one child");
            }
            _child.SetActive(false);
            _isDisplaying = false;
        }
        
        private void Update()
        {
            var characterController = CharacterClassController.Instance.ActiveController;

            var leftWeapon = characterController.WeaponInUseLeftHand;
            var rightWeapon = characterController.WeaponInUseRightHand;

            if (leftWeapon == null && rightWeapon == null)
            {
                DisableDisplay();
                return;
            }

            var weapon = rightWeapon != null ? rightWeapon : leftWeapon;
            text.text = $"{weapon.BulletsAmounts}/{weapon.BulletsPerMagazine}";
            EnableDisplay();
        }
        
        private void EnableDisplay()
        {
            if (_isDisplaying) return;
            _child.SetActive(true);
            _isDisplaying = true;
        }
        
        private void DisableDisplay()
        {
            if (!_isDisplaying) return;
            _child.SetActive(false);
            _isDisplaying = false;
        }
    }
}