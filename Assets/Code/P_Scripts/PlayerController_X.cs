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


  
}
