using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{

    [SerializeField] GameObject icon;
    IInteractor interactor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractor>(out interactor))
        {
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactor != null)
        {
            interactor = null;
            icon.SetActive(false);
        }
    }
}
