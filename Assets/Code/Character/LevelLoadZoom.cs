using System;
using System.Collections;
using JUTPS.CameraSystems;
using UnityEngine;

namespace Code.Character
{
    [RequireComponent(typeof(JUCameraController))]
    public class LevelLoadZoom : MonoBehaviour
    {
        public Transform target;
        public float zoomDuration;
        
        private Camera _camera;
        private JUCameraController _cameraController;
        private float _zoomTime;
        private bool _zoomingIn;
        private float _baseFOV;
        
        private void Start()
        {
            _cameraController = GetComponent<JUCameraController>();
            _cameraController.enabled = false;
            
            _camera = _cameraController.mCamera;
            _baseFOV = _camera.fieldOfView;
            _zoomingIn = true;
            Time.timeScale = 0.1f;
        }

        private void RotateCamera()
        {
            // Point camera in direction of target
            var targetPosition = target.position;
            var cameraPosition = transform.position;
            var direction = targetPosition - cameraPosition;
            
            // Get rotation to look at target
            var rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
        }

        private void Update()
        {
            // Until zoom is complete, zoom in on target
            if (_zoomTime < zoomDuration)
            {
                RotateCamera();
                _zoomTime += Time.deltaTime * 10;
                var t = _zoomTime / zoomDuration;
                if (_zoomingIn)
                {
                    _camera.fieldOfView = Mathf.Lerp(_baseFOV, 5, t);
                }
                else
                {
                    _camera.fieldOfView = Mathf.Lerp(5, _baseFOV, t);
                }
            }
            else
            {
                if (_zoomingIn)
                {
                    _zoomingIn = false;
                    _zoomTime = 0;
                }
                else
                {
                    Time.timeScale = 1;
                    _cameraController.enabled = true;
                    Destroy(this);
                }
            }
        }
    }
}