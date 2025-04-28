using UnityEngine;
using UnityEngine.Events;

namespace Saga.UIBehaviour.ItemGroupBehaviour
{
    public class ItemUIGroup : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private ItemWidget itemWidget;
        public void ShowItems(params IItem[] items)
        {
            foreach (var item in items)
            {
                CreateWidget(item);
            }
        }
        public void ShowItems<T>(params T[] items) where T : IItem
        {
            foreach (var item in items)
            {
                CreateWidget(item);
            }
        }
        public void ShowItems<T>(UnityEvent<T> callback, params T[] items) where T : IItem
        {
            foreach (var item in items)
            {
                var widget = CreateWidget(item);
                widget.Button.enabled = true;
                widget.Button.onClick.AddListener(() => callback.Invoke(item));
            }
        }
        public void Clear()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private ItemWidget CreateWidget(IItem item)
        {
            var widget = Instantiate(itemWidget, container);
            widget.Image.sprite = item.Icon;
            widget.Text.text = item.Info;
            return widget;
        }
    }
}

