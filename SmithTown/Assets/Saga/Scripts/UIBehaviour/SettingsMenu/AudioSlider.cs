using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Saga.UIBehaviour.SettingsMenu
{
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider slider;
        [SerializeField] private string parameterName;
        

        private void Awake()
        {
            mixer.GetFloat(parameterName, out var value);
            slider.value = Mathf.InverseLerp(-80f, 20f, value);

            slider.onValueChanged.AddListener(SetVolume);
        }

        public void SetVolume(float value)
        {
            var db = Mathf.Lerp(-80f, 20f, value);
            mixer.SetFloat(parameterName, db);
        }
    }
}