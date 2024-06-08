using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : NPCBaseState
{
    public override void EnterState(NPCStateManager NPC)
    {
        NPC.SwitchState(NPC.pathState);
    }

    public override void OnEnter(NPCStateManager NPC)
    {
        
    }

    public override void UpdateState(NPCStateManager NPC)
    {
        
    }
}
