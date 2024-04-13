using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Keyboard.current.fKey.isPressed)
            {
                SceneManager.LoadScene("Practice Range");
            }
        }
    }

    //public void onInteract(InputValue value)
    //{

    //}
}