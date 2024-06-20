using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public IPickable[] inventory = new IPickable[2];
    int currentInvSlot;

    public static Action<IPickable, int> OnInventoryChanged;
    public static Action<int> OnSlotChanged;

    [Header("inserite le due mani")]
    [SerializeField] Transform[] hands;

    private void OnEnable()
    {
        InputManager.ActionMap.Player.Inventory.performed += ChangeSlot;
        InteractionTrigger.Interacted += Grab;
    }

    private void OnDisable()
    {
        InputManager.ActionMap.Player.Inventory.performed -= ChangeSlot;
        InteractionTrigger.Interacted -= Grab;
    }

    private void ChangeSlot(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        if(value == 1)
        {
            currentInvSlot++;
            if (currentInvSlot >= inventory.Length)
            {
                currentInvSlot = 0;
            }
        }

        else
        {
            currentInvSlot--;
            if (currentInvSlot < 0)
            {
                currentInvSlot = inventory.Length - 1;
            }
        }
        OnSlotChanged?.Invoke(currentInvSlot);
    }

    public void Grab(IPickable interactable)
    {
        if (inventory[currentInvSlot] == null)
        {
            inventory[currentInvSlot] = interactable;
            interactable.myTransform.TryGetComponent(out Collider coll);
            coll.enabled = false;
            
            interactable.myTransform.parent = hands[currentInvSlot].transform;
            interactable.myTransform.position = hands[currentInvSlot].position;

            OnInventoryChanged?.Invoke(interactable,currentInvSlot);
            return;
        }
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = interactable;
                interactable.myTransform.TryGetComponent(out Collider coll);
                coll.enabled = false;
                //interactable.myTransform.position = Vector3.up * 1000;
                interactable.myTransform.parent = hands[i].transform;
                interactable.myTransform.position = hands[i].position;
                OnInventoryChanged?.Invoke(interactable, i);
            }
        }
    }
}
