using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateManager : MonoBehaviour
{
    NPCBaseState currentState;
    NPCIdleState idleState=new NPCIdleState();

    private void Start()
    {
        currentState=idleState;

        currentState.EnterState(this);
    }


}
