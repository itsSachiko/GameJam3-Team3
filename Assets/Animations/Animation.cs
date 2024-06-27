using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator anim;
    Vector3 lastPosition;



    void Start()
    {
        lastPosition = transform.position;
    }


    void Update()
    {
        if (transform.position.x != lastPosition.x || transform.position.z != lastPosition.z)
        {
            anim.SetBool("isMoving", true);

        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        lastPosition = transform.position;
    }
}