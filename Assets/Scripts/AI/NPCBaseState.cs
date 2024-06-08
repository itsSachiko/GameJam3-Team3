using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBaseState
{
    public abstract void EnterState(NPCStateManager NPC);
    public abstract void UpdateState(NPCStateManager NPC);
    public abstract void OnCollisionEnter(NPCStateManager NPC);

}
