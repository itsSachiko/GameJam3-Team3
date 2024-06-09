using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPathrollingState : NPCBaseState
{

    public int i = 0;

    public override void EnterState(NPCStateManager NPC)
    {
        
    }

    public override void OnEnter(NPCStateManager NPC)
    {

    }

    public override void UpdateState(NPCStateManager NPC)
    {        
        if (Vector3.Distance(NPC.transform.position, NPC.transforms[i].position)>0.1f)
        {
            NPC.agent.SetDestination(NPC.transforms[i].position);
        }
        else if(i<NPC.transforms.Count-1)
        {
            i++;
            NPC.agent.SetDestination(NPC.transforms[i].position);
        }
        else
        {
            i = 0;
            NPC.agent.SetDestination(NPC.transforms[i].position);
        }
    }
}
