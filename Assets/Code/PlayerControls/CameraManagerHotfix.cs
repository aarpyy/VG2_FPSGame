using JUTPS.CameraSystems;
using UnityEngine;

namespace PlayerControls
{
    [RequireComponent(typeof(JUCameraController))]
    public class CameraManagerHotfix : MonoBehaviour
    {
        private JUCameraController _cameraController;
        
        private void Awake()
        {
            _cameraController = GetComponent<JUCameraController>();
            var savedSens = PlayerPrefs.GetFloat("Slider_CameraSensitivity");
            if (savedSens > 0)
            {
                _cameraController.GeneralSensibility = savedSens;
            }
        }
    }
}