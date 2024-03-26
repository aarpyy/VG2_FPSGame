using System;
using JUTPS.DestructibleSystem;
using UnityEngine;

namespace Tutorial
{
    [RequireComponent(typeof(DestructibleObject))]
    public class TutorialEnd : MonoBehaviour
    {
        private DestructibleObject _destructibleObject;
        
        private void Awake()
        {
            _destructibleObject = GetComponent<DestructibleObject>();
        }

        private void Update()
        {
            if (_destructibleObject.IsFractured)
            {
                Debug.Log("Tutorial complete!");
                Destroy(this);
            }
        }
    }
}