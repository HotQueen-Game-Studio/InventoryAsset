using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HotQueen.Inventory
{
    public abstract class InventoryUI<T> : MonoBehaviour where T : struct
    {
        [SerializeField] protected Transform SlotContentParent;
        [SerializeField] protected Slot slotUI;
        protected Dictionary<SlotData<T>, Button> buttonsInstance = new Dictionary<SlotData<T>, Button>();
        public virtual void Refresh(List<SlotData<T>> list)
        {
            Clear();
            foreach (var item in list)
            {
                Slot btnInstance = Instantiate<Slot>(slotUI, SlotContentParent);
                buttonsInstance.Add(item, btnInstance);
            }
        }

        public virtual void Clear()
        {
            foreach (var item in buttonsInstance)
            {
                Destroy(item.Value.gameObject);
            }
            buttonsInstance.Clear();
        }
    }
}