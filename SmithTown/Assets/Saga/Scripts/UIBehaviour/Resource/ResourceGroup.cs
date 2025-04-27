using Saga.Items.Presets;
using Saga.ResourceSystem;
using UnityEngine;

namespace Saga.UIBehaviour.Resource
{
    public class ResourceGroup : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private ResourceWidget resourceWidget;

        public void Show(params ResourceInfo[] resources)
        {
            foreach (var resource in resources)
            {
                CreateWidget(resource);
            }
        }
        public void Show(params ResourceData[] resources)
        {
            foreach (var resource in resources)
            {
                CreateWidget(resource);
            }
        }
        public void Clear()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void CreateWidget(ResourceInfo info)
        {
            var widget = Instantiate(resourceWidget, container);
            widget.Image.sprite = info.Preset.Icon;
            widget.Text.text = info.Amount.ToString();
        }
    }
}

