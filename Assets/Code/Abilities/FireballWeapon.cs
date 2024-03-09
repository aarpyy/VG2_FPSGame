using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : MonoBehaviour
{
    public Rigidbody bullet;
    public float FireballCD;
    public float FireballTimer;

    // Start is called before the first frame update
    void Start()
    {
        FireballTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && FireballTimer <=0 )
        {
            Rigidbody instantiatedBullet = Instantiate(bullet, transform.position + (transform.forward * 2), transform.rotation);
            FireballTimer = FireballCD;
        }

        FireballTimer -= Time.deltaTime;
    }
}
