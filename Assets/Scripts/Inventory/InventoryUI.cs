using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Image[] slotIMG;
    [SerializeField] Image[] selectedSlot;

    
    private void OnEnable()
    {
        SlotChange(0);
        Inventory.OnSlotChanged += SlotChange;
        Inventory.OnInventoryChanged += InventoryChange;
    }
    private void OnDisable()
    {
        Inventory.OnSlotChanged -= SlotChange;
        Inventory.OnInventoryChanged -= InventoryChange;
    }

    private void InventoryChange(IPickable interactable, int index)
    {
        slotIMG[index].sprite = interactable.slot.image;
    }

    private void SlotChange(int obj)
    {
        for (int i = 0; i < selectedSlot.Length; i++)
        {
            selectedSlot[i].enabled = false;
        }
        selectedSlot[obj].enabled = true;
    }
}
