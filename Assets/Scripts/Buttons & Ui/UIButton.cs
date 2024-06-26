using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField]Sprite enter;
    [SerializeField]Sprite exit;
    [SerializeField] Image image;
    public void OnEnter()
    {
        image.sprite=exit;
    }
    public void OnExit()
    {
        image.sprite = enter;
    }


}
