using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using JUTPS.JUInputSystem;
using JUTPS;

public class ResetButton : MonoBehaviour
{
    bool touch = false;
    [Header("Input")]
    public InputActionReference InteractInput;

    private void Awake()
    {
        InteractInput.action.performed += OnInteract;
    }
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        touch = false;
    }

    private void OnInteract(InputAction.CallbackContext ctx) {

        if (touch == true) {

            SceneManager.LoadScene("Practice Range");
        }
    }


}