using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.SceneLoadScreen
{
    public class LoadingSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public void SetProgress(float progress)
        {
            slider.value = progress;
        }
    }
}

