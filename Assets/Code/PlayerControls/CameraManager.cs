using System;
using JUTPS.CameraSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerControls
{
    public class CameraManager : MonoBehaviour
    {
        public enum CameraType
        {
            FirstPerson,
            ThirdPerson
        }

        public static CameraManager Instance { get; private set; }
        public CameraType cameraType;
        public JUCameraController firstPersonCamera;
        public JUCameraController thirdPersonCamera;

        private JUCameraController[] _cameras;
        private float _sensitivity;

        public JUCameraController ActiveCamera => cameraType switch
        {
            CameraType.FirstPerson => firstPersonCamera,
            CameraType.ThirdPerson => thirdPersonCamera,
            _ => throw new ArgumentOutOfRangeException()
        };

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(firstPersonCamera.gameObject);
            DontDestroyOnLoad(thirdPersonCamera.gameObject);

            _cameras = new[]
            {
                firstPersonCamera, thirdPersonCamera
            };
            _sensitivity = PlayerPrefs.GetFloat("CameraSensitivity");
            
            foreach (var e in _cameras)
            {
                e.gameObject.SetActive(false);
            }
            
            SceneManager.sceneLoaded += (scene, _) =>
            {
                if (scene.buildIndex != 0)
                {
                    EnableCamera();
                }
            };
        }

        private void Start()
        {
            _sensitivity = PlayerPrefs.GetFloat("CameraSensitivity");
            if (_sensitivity > 0)
            {
                SetSensitivity(_sensitivity);
            }
            else
            {
                _sensitivity = ActiveCamera.GeneralSensibility;
            }
        }

        public void EnableCamera()
        {
            ActiveCamera.gameObject.SetActive(true);
        }

        public void SetSensitivity(float sens)
        {
            _sensitivity = sens;
            ActiveCamera.GeneralSensibility = sens;
        }
    }
}