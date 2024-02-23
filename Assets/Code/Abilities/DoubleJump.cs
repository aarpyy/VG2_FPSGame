using UnityEngine;
using JUTPS.JUInputSystem;
using JUTPS;

namespace Code.Abilities
{
    [RequireComponent(typeof(JUCharacterController))]
    public class DoubleJump : MonoBehaviour
    {
        // Configuration
        public float jumpForce = 3f;
        public float cooldown = 5f;
        
        // State
        private bool _canDoubleJump;
        private bool _hasDoubleJumped;
        private float _timeSinceLastJump;
        
        // Outlets
        private JUCharacterController _characterController;
        private Rigidbody _rb;

        private void Awake()
        {
            _characterController = GetComponent<JUCharacterController>();
            _rb = GetComponent<Rigidbody>();
            _timeSinceLastJump = cooldown + 1;
        }

        //Called every frame
        private void Update()
        {
            _timeSinceLastJump += Time.deltaTime;
            
            // If on the ground, they can double jump
            if (_characterController.IsGrounded)
            {
                _hasDoubleJumped = false;
                _canDoubleJump = false;
                return;
            }

            // If they have already double jumped, they cannot double jump again
            if (_hasDoubleJumped)
            {
                return;
            }

            if (JUInput.GetButtonUp(JUInput.Buttons.JumpButton))
            {
                // If the character is in the air and has not double jumped, then they can double jump
                 _canDoubleJump = true;
            }
            else if (_canDoubleJump && JUInput.GetButtonDown(JUInput.Buttons.JumpButton) && _timeSinceLastJump > cooldown)
            {
                _hasDoubleJumped = true;
                _rb.AddForce(transform.up * (200 * jumpForce), ForceMode.Impulse);
                _timeSinceLastJump = 0;
            }
        }
    }
}