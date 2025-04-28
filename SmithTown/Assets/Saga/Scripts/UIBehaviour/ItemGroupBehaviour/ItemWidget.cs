using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.ItemGroupBehaviour
{
    public class ItemWidget : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button button;

        public Image Image => image;
        public TextMeshProUGUI Text => text;
        public Button Button => button;
    }
}

