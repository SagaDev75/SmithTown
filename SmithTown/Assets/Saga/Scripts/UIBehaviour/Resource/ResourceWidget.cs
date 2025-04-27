using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Saga.UIBehaviour.Resource
{
    public class ResourceWidget : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        public Image Image => _image;
        public TextMeshProUGUI Text => _text;
    }
}

