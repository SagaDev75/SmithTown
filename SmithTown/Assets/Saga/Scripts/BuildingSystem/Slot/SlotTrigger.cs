using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SlotTrigger : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent onPointerClick;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        onPointerClick?.Invoke();
    }
}
