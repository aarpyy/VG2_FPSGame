using System;
using UnityEngine;

namespace Tutorial
{
    [RequireComponent(typeof(Collider))]
    public class TutorialLocationPrompt : TutorialPrompt
    {
        [Serializable]
        public struct PulsingLight
        {
            public Light light;
            public float minIntensity;
            public float maxIntensity;
            public float pulseSpeed;
        }
        
        // Outlets
        public PulsingLight[] lights;
        public GameObject[] indicators;
        
        // Configuration
        public float timeToComplete = 2f;

        private void Start()
        {
            Deactivate();
        }

        public override void Activate()
        {
            base.Activate();
            foreach (var l in lights)
            {
                l.light.enabled = true;
            }
            foreach (var i in indicators)
            {
                i.SetActive(true);
            }
        }
        
        public override void Deactivate()
        {
            foreach (var l in lights)
            {
                l.light.enabled = false;
            }
            foreach (var i in indicators)
            {
                i.SetActive(false);
            }
            base.Deactivate();
        }

        private void Update()
        {
            if (!isActivated || IsComplete)
            {
                return;
            }
            
            // Pulse the light between the min intensity and the initial intensity
            foreach (var l in lights)
            {
                l.light.intensity = Mathf.Lerp(l.minIntensity, l.maxIntensity, Mathf.PingPong(Time.time * l.pulseSpeed, 1));
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!isActivated)
            {
                return;
            }
            
            if (IsComplete)
            {
                enabled = false;
                return;
            }

            timeToComplete -= Time.deltaTime;
            if (timeToComplete <= 0)
            {
                Debug.Log($"Location {gameObject.name} tutorial completed");
                IsComplete = true;
            }
        }
    }
}