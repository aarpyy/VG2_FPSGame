using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUTPS.JUInputSystem;
using JUTPS;
using UnityEngine.InputSystem;

namespace Code.Abilities
{
    [RequireComponent(typeof(JUCharacterController))]
    public class ActivateShockwave : MonoBehaviour
    {

        public float cooldown = 10f;
        public Transform spawn;
        public float activation = 1f;
        // State
        private bool _hasShockwave;
        private float _timeSinceLastWave;
     


        // Outlets
        private JUCharacterController _characterController;
        private Rigidbody _rb;
        [Header("Input")]
        public InputActionReference abilityInput;
        public GameObject shockWave;
        

        private void Awake()
        {
            _characterController = GetComponent<JUCharacterController>();
            _rb = GetComponent<Rigidbody>();
            _timeSinceLastWave = cooldown + 1;
            abilityInput.action.performed += OnDash;

        }

        private void Update()
        {
            _timeSinceLastWave += Time.deltaTime;
          

        }

        private void OnDash(InputAction.CallbackContext ctx)
        {

            if (_timeSinceLastWave > cooldown)
            {
                _hasShockwave = true;

                _timeSinceLastWave = 0;
            }
            else {
                _hasShockwave = false;
            }
            if (_hasShockwave)
            {
                Debug.Log("SHOCK");
                GameObject currentWave = Instantiate(shockWave, spawn.position, spawn.rotation);
         
               
               
            }
        }
    }
}
