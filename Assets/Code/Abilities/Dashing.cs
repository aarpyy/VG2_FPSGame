using JUTPS;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Code.Abilities
{
    [RequireComponent(typeof(JUCharacterController))]
    public class Dashing : MonoBehaviour
    {
        private Rigidbody rb;
        private JUCharacterController _characterController;

        [Header("Dashing")] 
        public float dashDuration = 0.15f;
        private float _speed;

        [Header("Cooldown")] 
        public float dashCD = 1.0f;
        private float dashCDTimer;

        [Header("Input")] 
        public InputActionReference dashInput;

        private void Start()
        {
            _characterController = GetComponent<JUCharacterController>();
            dashInput.action.performed += Dash;
            dashInput.action.Enable();

            if (dashCD < dashDuration - 1)
            {
                dashCD = dashDuration + 1;
            }
        }

        private void Update()
        {
            if (dashCDTimer > 0)
            {
                dashCDTimer -= Time.deltaTime;
            }

        }

        private void Dash(InputAction.CallbackContext context)
        {
            if (dashCDTimer > 0) return;
            dashCDTimer = dashCD;

            StartDash();
            Invoke(nameof(ResetDash), dashDuration);
        }

        private void StartDash()
        {
            _speed = _characterController.Speed;
            _characterController.Speed *= 8;
        }

        private void ResetDash()
        {
            _characterController.Speed = _speed;
        }
        

    }
}