using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : NPCBaseState
{
    public override void EnterState(NPCStateManager NPC)
    {
        Debug.Log("npc is idling");
    }

    public override void OnCollisionEnter(NPCStateManager NPC)
    {
    }

    public override void UpdateState(NPCStateManager NPC)
    {
    }
}
