using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetTargets : MonoBehaviour
{

    public GameObject targets;
    public Transform[] positions;
    public GameObject zone;
    DestroyInBox box;

    private void Update()
    {
        box = zone.GetComponent<DestroyInBox>();
        
    }





    public void Interact() {
        //if (box.Living == true) {
         //   box.destroyAll();
       // }
        for (int i = 0; i < positions.Length; i++) {
            Instantiate(targets, positions[i]);
        }



    }

     

}
