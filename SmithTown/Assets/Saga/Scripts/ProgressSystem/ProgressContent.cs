using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.ProgressSystem
{
    public class ProgressContent : ScriptableObject, IItem
    {
        public bool Unbloked { get; set; } = true;
        public virtual Sprite Icon { get; }
        public virtual string Info { get; }
    }
}

