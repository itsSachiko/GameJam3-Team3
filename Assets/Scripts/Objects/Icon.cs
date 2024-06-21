using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{

    [SerializeField] Image icon;
    [SerializeField] Sprite defaultIcon;
    IInteractor interactor;

    public static Action OnIconDisabled;

    public Action<Sprite> OnIconChest;

    private void OnEnable()
    {
        OnIconDisabled += IconDisabled;
        OnIconChest += IconChestChange;
    }

    private void OnDisable()
    {
        OnIconDisabled -= IconDisabled;
        OnIconChest -= IconChestChange;
    }

    private void IconChestChange(Sprite sprite)
    {
        if ( sprite == null)
        {
            icon.sprite = defaultIcon;
            return;
        }
        icon.sprite = sprite; 
    }

    private void IconDisabled()
    {
        icon.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractor>(out interactor))
        {
            icon.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactor != null)
        {
            interactor = null;
            icon.gameObject.SetActive(false);
        }
    }
}
