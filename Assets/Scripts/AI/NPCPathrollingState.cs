using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class NPCPathrollingState : NPCBaseState
{

    protected int i = 0;
    protected float timer;



    public override void EnterState(NPCStateManager NPC)
    {
        timer = Time.time + NPC.stopTime;
    }

    public override void OnEnter(NPCStateManager NPC)
    {

    }

    public override void UpdateState(NPCStateManager NPC)
    {
        if (Time.time >= timer)
        {
            timer = Time.time + NPC.stopTime;
            if (Vector3.Distance(NPC.transform.position, NPC.checkpoints[i].position) > 0.1f)
            {
                NPC.agent.SetDestination(NPC.checkpoints[i].position);
            }
            else if (i < NPC.checkpoints.Count - 1)
            {
                i++;
                NPC.agent.SetDestination(NPC.checkpoints[i].position);
            }
            else
            {
                i = 0;
                NPC.agent.SetDestination(NPC.checkpoints[i].position);
            }
        }
    }
}
