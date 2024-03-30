using System;
using JUTPS.AI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace AI
{
    [RequireComponent(typeof(JUCharacterArtificialInteligenceBrain))]
    public class AIRandomWander : MonoBehaviour
    {
        // Outlets
        private JUCharacterArtificialInteligenceBrain _brain;

        // Configuration
        // [Range(1, 100)] public float minWaitTime = 10;  // Minimum time to wait before moving to a new destination
        // [Range(1, 100)] public float maxWaitTime = 60;  // Maximum time to wait before moving to a new destination
        // [MinMaxSlider(1, 120)] public float[] waitTime;
        public float minWaitTime = 1;
        public float maxWaitTime = 120;
        public Transform[] waypoints;                   // Waypoints to wander around
        
        // State
        private float _currentWaitTime;

        private void Awake()
        {
            _brain = GetComponent<JUCharacterArtificialInteligenceBrain>();
            if (_brain == null)
            {
                throw new NullReferenceException("No brain found on AI character");
            }
        }
        
        private void Start()
        {
            GenerateNewRandomDestination();
        }
        
        private void Update()
        {
            _currentWaitTime -= Time.deltaTime;
            if (_currentWaitTime <= 0)
            {
                GenerateNewRandomDestination();
                _currentWaitTime = UnityEngine.Random.Range(minWaitTime, maxWaitTime);
            }
        }
        
        private void GenerateNewRandomDestination()
        {
            // Choose random waypoint
            var randomWaypoint = waypoints[UnityEngine.Random.Range(0, waypoints.Length)];
            _brain.Destination = randomWaypoint.position;
        }
    }
}