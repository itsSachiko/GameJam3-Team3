using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAlarmedState : NPCBaseState
{


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
        timer = GetCurrentTime() + (long)NPC.delay;
    }
}
