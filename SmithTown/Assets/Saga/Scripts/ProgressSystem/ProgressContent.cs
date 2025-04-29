using Saga.UIBehaviour.ItemGroupBehaviour;
using UnityEngine;

namespace Saga.ProgressSystem
{
    public class ProgressContent : ScriptableObject, IItem
    {
        public bool Unbloked { get; set; }
        public virtual Sprite Icon { get; }
        public virtual string Info { get; }
    }
}

