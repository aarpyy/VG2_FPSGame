using JUTPS;
using Michsky.UI.Heat;
using UnityEngine;

namespace Code.Menu
{
    public class VolumeManager : MonoBehaviour
    {
        public SliderManager masterVolume;
        public SliderManager musicVolume;
        public SliderManager sfxVolume;
        
        private void Awake()
        {
            masterVolume.onValueChanged.AddListener(OnMasterVolumeChanged);
            musicVolume.onValueChanged.AddListener(OnMusicVolumeChanged);
            sfxVolume.onValueChanged.AddListener(OnSFXVolumeChanged);
        }
        
        private void OnMasterVolumeChanged(float value)
        {
            AudioListener.volume = value;
        }

        private void OnMusicVolumeChanged(float value)
        {
        }
        
        private void OnSFXVolumeChanged(float value)
        {
        }
    }
}