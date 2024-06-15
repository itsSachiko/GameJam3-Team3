using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class NPCPathrollingState : NPCBaseState
{

    public int i = 0;
    long timer;
    long currentTime;



    public long GetCurrentTime()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        long unixTimestamp = now.ToUnixTimeSeconds();
        return unixTimestamp;
    }
    public override void EnterState(NPCStateManager NPC)
    {
        currentTime = GetCurrentTime();
        timer = currentTime + (long)NPC.delay;
    }

    public override void OnEnter(NPCStateManager NPC)
    {

    }

    public override void UpdateState(NPCStateManager NPC)
    {
        if (GetCurrentTime() >= timer)
        {
            timer = GetCurrentTime() + (long)NPC.delay;
            if (Vector3.Distance(NPC.transform.position, NPC.transforms[i].position) > 0.1f)
            {
                NPC.agent.SetDestination(NPC.transforms[i].position);
            }
            else if (i < NPC.transforms.Count - 1)
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
}
