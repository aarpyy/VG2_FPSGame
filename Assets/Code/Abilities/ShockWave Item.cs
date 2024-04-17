using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JUTPS;


namespace JUTPS
{
    public class ShockWaveItem : MonoBehaviour
    {
       

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Rigidbody>() && other.CompareTag("Player").Equals(false))
            {

                if (other.gameObject.GetComponent<JUHealth>())
                {
                    other.gameObject.GetComponent<JUHealth>().Health -= 25;
                    other.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 100f, ForceMode.Force);
                    Destroy(this.gameObject, .5f);
                }


            }
            else {
                Destroy(this.gameObject, .5f);
            }
            
            
        }

        
    }
}
