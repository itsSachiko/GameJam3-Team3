using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Image[] slotIMG;
    [SerializeField] Image[] selectedSlot;

    public delegate void GetImage(int index, out Sprite sprite);
    public static GetImage getImage;
    
    private void OnEnable()
    {
        SlotChange(0);
        Inventory.OnSlotChanged += SlotChange;
        Inventory.OnInventoryChanged += InventoryChange;
        getImage += OnGetImage;
    }
    private void OnDisable()
    {
        Inventory.OnSlotChanged -= SlotChange;
        Inventory.OnInventoryChanged -= InventoryChange;
        getImage -= OnGetImage;
    }

    private void OnGetImage(int index, out Sprite sprite)
    {
        sprite = slotIMG[index].sprite;
    }

    private void InventoryChange(IPickable interactable, int index)
    {
        if(interactable == null)
        {
            slotIMG[index].sprite = null;
            return;
        }
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
