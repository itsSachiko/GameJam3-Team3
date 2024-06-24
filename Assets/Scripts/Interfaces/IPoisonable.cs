using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoisonable
{
    public bool isPoisoned {  get; set; }
    public Transform poisonedTransform { get; }
}
