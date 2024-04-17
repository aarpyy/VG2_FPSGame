using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    [RequireComponent(typeof(Image))]
    public class FadeIn : MonoBehaviour
    {
        // Outlets
        private Image _image;
        
        // Configuration
        public float fadeDuration = 1f;
        
        // State
        private Color _color;
        private float _alpha;
        private float _fadeTime;
        
        private void Start()
        {
            _image = GetComponent<Image>();
            _color = _image.color;
            _color.a = 0;
            _fadeTime = 0f;
        }

        private void Update()
        {
            if (_fadeTime > fadeDuration)
            {
                return;
            }
            _fadeTime += Time.deltaTime;
            _alpha = Mathf.Lerp(0, 1, _fadeTime / fadeDuration);
            _color.a = _alpha;
            _image.color = _color;
        }
    }
}