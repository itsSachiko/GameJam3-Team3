using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public Transform myTransform { get; set; }
    public Item slot { get; set; }


}
