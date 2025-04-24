using Saga.GameSession.Settings;
using Saga.GameSession.Settings.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.SettingsMenu
{
    public class SettingsMenuLogic : MonoBehaviour
    {
        [SerializeField] private Slider masterVolume;
        [SerializeField] private Slider sfxVolume;
        [SerializeField] private Slider musicVolume;
        
        private AudioSettingsData _audioSettings;

        private bool _isClosed;
        
        private void Awake()
        {
            _audioSettings = UserSettingsKeeper.AudioSettings;

            masterVolume.value = _audioSettings.masterVolume;
            masterVolume.onValueChanged.AddListener((value) => _audioSettings.masterVolume = value);
            
            sfxVolume.value = _audioSettings.sfxVolume;
            sfxVolume.onValueChanged.AddListener((value) => _audioSettings.sfxVolume = value);
            
            musicVolume.value = _audioSettings.musicVolume;
            musicVolume.onValueChanged.AddListener((value) => _audioSettings.musicVolume = value);
        }
        
        public async void CloseMenu()
        {
            if (_isClosed) return;
            
            _isClosed = true;
            
            SettingsData settings = new()
            {
                audioSettingsData = _audioSettings
            };
            
            UserSettingsKeeper.SetSettings(settings);
            await UserSettingsLoader.Save();
            Destroy(gameObject);
        }
    }
}