using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HotQueen.Inventory
{
    public class InventoryUIDemo : InventoryUI<DemoData>
    {
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemDescription;
        public override void Refresh(List<SlotData<DemoData>> list)
        {
            Clear();
            foreach (var item in list)
            {
                Slot btnInstance = Instantiate<Slot>(slotUI, SlotContentParent);

                btnInstance.onClick.AddListener(() =>
                {
                    Debug.Log("Hello world");
                });

                btnInstance.OnHover.AddListener(() =>
                {
                    itemName.text = item.data.name;
                    itemDescription.text = item.data.description;
                });

                btnInstance.OnStopHover.AddListener(() =>
                {
                    itemName.text = "";
                    itemDescription.text = "";
                });

                if (btnInstance.TryGetComponent<Slot>(out Slot s))
                {
                    s.name.text = item.data.name;
                    s.count.text = item.count.ToString();
                }
                buttonsInstance.Add(item, btnInstance);

            }
        }
    }
}