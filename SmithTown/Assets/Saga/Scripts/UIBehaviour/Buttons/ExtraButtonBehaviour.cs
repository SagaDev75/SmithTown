using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Saga.UIBehaviour.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ExtraButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private UnityEvent onButtonNormal;
        [SerializeField] private UnityEvent onButtonHighlighted;
        [SerializeField] private UnityEvent onButtonReleased;

        [field: SerializeField, HideInInspector] public Button Button { get; private set; }
        
        public void OnButtonNormalInvoke()
        {
            onButtonNormal.Invoke();
        }
        public void OnButtonHighlightedInvoke()
        {
            onButtonHighlighted.Invoke();
        }
        public void OnButtonReleasedInvoke()
        {
            onButtonReleased.Invoke();
        }

        private void OnValidate()
        {
            Button = GetComponent<Button>();
        }
    }
}

