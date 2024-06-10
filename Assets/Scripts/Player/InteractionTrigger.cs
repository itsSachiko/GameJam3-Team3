using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour, IInteractor
{
    bool isInteracting;
    public Action Interacted;


    private void OnEnable()
    {
        InputManager.ActionMap.Player.Interaction.performed += Interaction;
    }

    private void OnDisable()
    {
        InputManager.ActionMap.Player.Interaction.performed -= Interaction;
    }
    private void Interaction(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isInteracting)
        {
            Debug.Log("inserito nell'inventario");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var x))
        {
            isInteracting = true; 

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var x))
        {
            isInteracting = false;

        }
    }


}
