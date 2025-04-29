using Saga.ProgressSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.Progress
{
    public class ProgressWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private Slider progressSlider;

        private void Awake()
        {
            ProgressManager.OnProgress += ProgressManagerOnOnProgress;
            ProgressManagerOnOnProgress(ProgressManager.CurrentLevelInfo);
        }

        private void OnDestroy()
        {
            ProgressManager.OnProgress -= ProgressManagerOnOnProgress;
        }

        private void ProgressManagerOnOnProgress(ProgressLevelInfo obj)
        {
            levelText.text = (ProgressManager.Level+1).ToString();
            progressText.text = $"{ProgressManager.Progress}/{obj.ordersToUp}";
            progressSlider.value = (float)ProgressManager.Progress/obj.ordersToUp;
        }
    }
}

