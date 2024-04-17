using System;
using JUTPS.CameraSystems;
using JUTPS.FX;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(Collider))]
    public class MoveWayPoints : MonoBehaviour
    {
        // Outlets
        public Transform[] waypoints;
        public Transform cameraPos;
        public JUCameraController mainCamera;
        private Camera _realCamera;
        public Transform helicopter;
        public GameObject canvas;
        
        // Configuration
        public float speed = 5f;
        public float canvasDelay = 2f;
        public float mainMenuDelay = 5f;

        // State
        private int _currentWaypointIndex;
        private bool _isMoving;
        private float _delayTime;

        private void Update()
        {
            if (!_isMoving) return;
            
            _delayTime += Time.deltaTime;
            if (_delayTime >= canvasDelay)
            {
                canvas.SetActive(true);
            }
            
            if (_delayTime >= mainMenuDelay)
            {
                // Load main menu
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
            if (Vector3.Distance(helicopter.position, waypoints[_currentWaypointIndex].position) < 0.1f)
            {
                // move to the next waypoint
                _currentWaypointIndex++;
                // if the current waypoint index exceeds the number of waypoints, reset it to 0
                if (_currentWaypointIndex >= waypoints.Length)
                {
                    _currentWaypointIndex = 0;
                }
            }
            var position = helicopter.position;
            position = Vector3.MoveTowards(position, waypoints[_currentWaypointIndex].position, speed * Time.deltaTime);
            helicopter.position = position;
            
            // Camera look at helicopter
            _realCamera.transform.LookAt(position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _isMoving = true;
                _delayTime = 0f;

                _realCamera = mainCamera.mCamera;
                var animator = _realCamera.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.enabled = false;
                }

                var shaker = _realCamera.GetComponent<Shaker>();
                if (shaker != null)
                {
                    shaker.enabled = false;
                }
                
                var camTransform = _realCamera.transform;
                
                // Set up camera
                camTransform.parent = cameraPos;
                camTransform.localPosition = Vector3.zero;
                
                // Destroy camera parent
                Destroy(mainCamera.gameObject);
                
                // Destroy player
                Destroy(other.gameObject);
            }
        }
    }

}