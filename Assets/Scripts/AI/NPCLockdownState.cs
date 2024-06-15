using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLockdownState : NPCBaseState
{


    public override void EnterState(NPCStateManager NPC)
    {
    }

    public override void OnEnter(NPCStateManager NPC)
    {
    }

    public override void UpdateState(NPCStateManager NPC)
    {
        Debug.Log("locdown update ");
    }
}
