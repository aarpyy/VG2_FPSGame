using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Capture
{
    public class CameraCapture : MonoBehaviour
    {
        public int fileCounter;
        public InputAction screenshotAction;
        private Camera Camera
        {
            get
            {
                if (!_camera)
                {
                    _camera = Camera.main;
                }
                return _camera;
            }
        }
        private Camera _camera;

        private void Awake()
        {
            screenshotAction.Enable();
            screenshotAction.performed += _ => Capture();
        }
 
        public void Capture()
        {
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/Captures/" + fileCounter + ".png");
            // var activeRenderTexture = RenderTexture.active;
            // RenderTexture.active = Camera.targetTexture;
            //
            // Camera.Render();
            //
            // var targetTexture = Camera.targetTexture;
            // var image = new Texture2D(targetTexture.width, targetTexture.height);
            // image.ReadPixels(new Rect(0, 0, targetTexture.width, targetTexture.height), 0, 0);
            // image.Apply();
            // RenderTexture.active = activeRenderTexture;
            //
            // var bytes = image.EncodeToPNG();
            // Destroy(image);
            //
            // File.WriteAllBytes(Application.dataPath + "/Captures/" + fileCounter + ".png", bytes);
            // fileCounter++;
        }
    }
}