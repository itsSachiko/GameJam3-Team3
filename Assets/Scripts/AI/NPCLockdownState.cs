using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLockdownState : NPCPathrollingState
{


    public override void EnterState(NPCStateManager NPC)
    {
    }

    public override void OnEnter(NPCStateManager NPC)
    {
    }

    public override void UpdateState(NPCStateManager NPC)
    {
        NPC.agent.speed = NPC.lockSpeed;
        NPC.agent.isStopped = false;
        base.UpdateState(NPC);


    }
}
