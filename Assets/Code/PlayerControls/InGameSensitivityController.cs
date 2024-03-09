using Code.Character;
using Michsky.UI.Heat;
using UnityEngine;

namespace PlayerControls
{
    [RequireComponent(typeof(SliderManager))]
    public class InGameSensitivityController : MonoBehaviour
    {
        private CameraController _cameraController;
        
        private void Awake()
        {
            _cameraController = FindObjectOfType<CameraController>();
            if (!_cameraController) return;
            GetComponent<SliderManager>().onValueChanged.AddListener(_cameraController.SetSensitivity);
        }
    }
}