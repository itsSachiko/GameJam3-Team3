using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public IInteractable[] inventory = new IInteractable[2];
    int currentInvSlot;

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
        int value = context.ReadValue<int>();
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
    }

    public void Grab(IInteractable interactable)
    {
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
            }
        }
    }
}
