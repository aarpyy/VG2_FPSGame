using System;
using System.Collections.Generic;
using JUTPS.CameraSystems;
using UnityEngine;

namespace Code.Character
{
    public class CameraController : MonoBehaviour
    {
        public enum CameraPOV
        {
            FirstPerson,
            ThirdPerson
        }
        
        // Outlets
        public TPSCameraController tpsCamera;
        public FPSCameraController fpsCamera;
        public AudioListener audioListener;
        public CharacterClassController characterClassController;
        
        // Configuration
        public CameraPOV cameraType;
        
        // State
        private JUCameraController _camera;
        private Dictionary<CameraPOV, JUCameraController> _cameraMap;

        private void OnEnable()
        {
            _cameraMap = new Dictionary<CameraPOV, JUCameraController>
            {
                {CameraPOV.FirstPerson, fpsCamera},
                {CameraPOV.ThirdPerson, tpsCamera}
            };
            
            tpsCamera.gameObject.SetActive(false);
            fpsCamera.gameObject.SetActive(false);
            
            SetCamera(cameraType);
        }

        private void OnDestroy()
        {
            Destroy(tpsCamera.gameObject);
            Destroy(fpsCamera.gameObject);
        }

        public void SetCamera(CameraPOV pov)
        {
            cameraType = pov;
            if (_camera != null)
            {
                _camera.gameObject.SetActive(false);
            }
            _camera = _cameraMap[pov];
            _camera.gameObject.SetActive(true);

            var transform1 = audioListener.transform;
            transform1.parent = _camera.transform;
            transform1.localPosition = Vector3.zero;
            
            Camera.SetupCurrent(_camera.mCamera);
        }
        
        public void SetSensitivity(float value)
        {
            _camera.GeneralSensibility = value;
        }
    }
}