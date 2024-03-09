using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFireBall : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
