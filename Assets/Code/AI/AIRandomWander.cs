using System;
using JUTPS.AI;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(JUCharacterArtificialInteligenceBrain))]
    public class AIRandomWander : MonoBehaviour
    {
        // Outlets
        private JUCharacterArtificialInteligenceBrain _brain;

        // Configuration
        [Range(1, 100)] public float minWaitTime = 1;   // Minimum time to wait before moving to a new destination
        [Range(1, 100)] public float maxWaitTime = 5;   // Maximum time to wait before moving to a new destination
        [Range(1, 100)] public float area = 100;        // Area to wander around
        
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
            }
        }
        
        private void GenerateNewRandomDestination()
        {
            var randomPosition = transform.position;
            randomPosition.z += UnityEngine.Random.Range(-area, area);
            randomPosition.x += UnityEngine.Random.Range(-area, area);
            _brain.Destination = randomPosition;
            _currentWaitTime = UnityEngine.Random.Range(minWaitTime, maxWaitTime);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(area, 0, area));
        }
    }
}