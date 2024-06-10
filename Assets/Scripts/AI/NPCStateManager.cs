using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{

    public List<Transform> transforms = new List<Transform>();
    public NavMeshAgent agent;
    NPCBaseState currentState;
    public NPCIdleState idleState=new NPCIdleState();
    public NPCPathrollingState pathState = new NPCPathrollingState();


    private void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        currentState=idleState;
        currentState.EnterState(this);
    }
    public void SwitchState(NPCBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, transforms[pathState.i].position));
        currentState.UpdateState(this);


    }




}
