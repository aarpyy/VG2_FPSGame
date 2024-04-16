using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JUTPS
{
    public class ShockWaveItem : MonoBehaviour
    {
        Rigidbody _rb;
        Transform _tr;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (CompareTag("Enemy"))
            {
                other.GetComponent<Rigidbody>().AddForce(-transform.forward * 100f * Time.deltaTime);
                other.GetComponent<JUHealth>().Health -= 20;
               
            }
        }
    }
}
