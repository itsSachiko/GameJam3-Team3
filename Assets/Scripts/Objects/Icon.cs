using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{

    [SerializeField] GameObject icon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractor>(out var x))
        {
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractor>(out var x))
        {
            icon.SetActive(false);
        }
    }
}
