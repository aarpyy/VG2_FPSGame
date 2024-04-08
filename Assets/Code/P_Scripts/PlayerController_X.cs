using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_X : MonoBehaviour
{
    public static PlayerController_X instance;

    private void Awake()
    {
        instance = this;
    }


    public void onInput() {
        Mouse mouseInput = Mouse.current;

        Vector2 mousePosition = mouseInput.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        Debug.Log("hit");
        if (Physics.Raycast(ray, out hit, 2f))
        {
            ResetTargets button = hit.transform.GetComponent<ResetTargets>();

            if (button)
            {
                button.Interact();
            }
        }
    }
}
