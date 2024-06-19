using UnityEngine;
using System;

public class NPCAlarmedState : NPCBaseState
{

    float stopTimer;
    float alarmTime;




    public override void EnterState(NPCStateManager NPC)
    {
        alarmTime = Time.time+NPC.alarmedTime;
        stopTimer = Time.time + NPC.stopTime;
    }

    public override void OnEnter(NPCStateManager NPC)
    {
    }

    public override void UpdateState(NPCStateManager NPC)
    {
        Debug.Log(alarmTime-Time.time);
        if(Time.time>=alarmTime)
        {
            NPC.SwitchState(NPC.lockdownState);
            NPCStateManager.OnBodyFound();
        }
        Debug.Log("alarmedstate");
        if (Time.time >= stopTimer)
        {
            stopTimer =Time.time+ NPC.stopTime;
            if (Vector3.Distance(NPC.transform.position, NPC.spottedPos) > 0.1f)
            {
                float x = UnityEngine.Random.Range(0 - NPC.alarmedRange, NPC.alarmedRange);
                float z = UnityEngine.Random.Range(0 - NPC.alarmedRange, NPC.alarmedRange);
                NPC.agent.SetDestination(new Vector3(NPC.spottedPos.x+x, 0, NPC.spottedPos.z+z));
            }
        }

    }
}
