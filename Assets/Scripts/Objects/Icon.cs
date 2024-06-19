using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{

    [SerializeField] GameObject icon;
    IInteractor interactor;

    public static Action OnIconDisabled;

    private void OnEnable()
    {
        OnIconDisabled += IconDisabled;
    }

    private void IconDisabled()
    {
        icon.SetActive(false);
    }

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
