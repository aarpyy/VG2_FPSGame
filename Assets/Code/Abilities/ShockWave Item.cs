using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JUTPS
{
    public class ShockWaveItem : MonoBehaviour
    {
       

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Rigidbody>() && CompareTag("Player") != true)
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
