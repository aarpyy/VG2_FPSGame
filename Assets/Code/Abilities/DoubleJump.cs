using UnityEngine;
using JUTPS.JUInputSystem;
using JUTPS;
using UnityEngine.InputSystem;

namespace Code.Abilities
{
    [RequireComponent(typeof(JUCharacterController))]
    public class DoubleJump : MonoBehaviour
    {
        // Configuration
        public float jumpForce = 3f;
        public float cooldown = 5f;
        
        // State
        private bool _hasDoubleJumped;
        private float _timeSinceLastJump;
        
        // Outlets
        private JUCharacterController _characterController;
        private Rigidbody _rb;
        [Header("Input")] 
        public InputActionReference jumpInput;

        private void Awake()
        {
            _characterController = GetComponent<JUCharacterController>();
            _rb = GetComponent<Rigidbody>();
            _timeSinceLastJump = cooldown + 1;
            jumpInput.action.performed += OnJump;
        }

        private void Update()
        {
            _timeSinceLastJump += Time.deltaTime;
            
            // If on the ground, they can double jump
            if (_characterController.IsGrounded)
            {
                _hasDoubleJumped = false;
            }
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            if (_hasDoubleJumped)
            {
                return;
            }
            
            if (!_characterController.IsGrounded && _timeSinceLastJump > cooldown)
            {
                _hasDoubleJumped = true;
                _rb.AddForce(transform.up * (200 * jumpForce), ForceMode.Impulse);
                _timeSinceLastJump = 0;
            }
        }
    }
}