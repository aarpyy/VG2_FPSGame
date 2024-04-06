using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInBox : MonoBehaviour
{
    public bool Living;
    public GameObject[] current;
    int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skin"))
        {
            Living = true;
            current[0] = other.gameObject;
            count++;
        }
        else if (other.CompareTag("Enemy"))
        {
            Living = true;
            current[0] = other.gameObject;
            count++;

        }
    }

    public void destroyAll()
    {
        for (int i = 0; i < current.Length; i++) {
            Destroy(current[i]);
        }
        count = 0;
    }
}
