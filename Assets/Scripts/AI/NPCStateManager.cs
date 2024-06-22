using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{
    [Header("Game Design")]
    [SerializeField,Range(-1,1)] float fieldOfView;
    [SerializeField]float closeRange;
    [SerializeField] public float stopTime;
    public List<Transform> checkpoints = new List<Transform>();
    public float lockSpeed;
    public float alarmedRange;
    public float alarmedTime;
    public float lockdownTime;
    public bool isGuard;

    [Header("Ignore this")]
    public Vector3 spottedPos;
    NPCBaseState currentState;
    public NPCIdleState idleState=new NPCIdleState();
    public NPCPathrollingState pathState = new NPCPathrollingState();
    public NPCAlarmedState alarmedState = new NPCAlarmedState();
    public NPCLockdownState lockdownState = new NPCLockdownState();
    public delegate void NPCSDelegate();
    public static NPCSDelegate OnBodyFound;

    public NavMeshAgent agent;
    public LayerMask mask;
    bool isPanic=false;
    bool isLockDown=false;

    private void OnEnable()
    {
        NPCStateManager.OnBodyFound += EveryoneLock;
    }
    private void OnDisable()
    {
        NPCStateManager.OnBodyFound -= EveryoneLock;
    }

    private void EveryoneLock()
    {
        if(!isLockDown)
        {
            isLockDown = true;
            GameManager.Instance.time = lockdownTime;
            SwitchState(lockdownState);
        }
        else if(isGuard)
        {
            GameManager.Instance.time = lockdownTime;
        }
    }

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


    private void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Vector3.Dot(transform.forward, Vector3.Normalize(other.transform.position - transform.position)) >= fieldOfView&&!isPanic)
        {
            isPanic = true;
            agent.SetDestination(transform.position);
            spottedPos=other.transform.position;
            SwitchState(alarmedState);
        }
        if (other.gameObject.GetComponent<IDangerous>() != null && Vector3.Dot(transform.forward, Vector3.Normalize(other.transform.position - transform.position)) >= fieldOfView)
        {
            isPanic = true;
            agent.isStopped = true;
            Collider[] collider = Physics.OverlapSphere(other.transform.position, alarmedRange, mask);
            for (int i = 0; i < collider.Length; i++)
            {
                if (collider[i].gameObject.GetComponentInChildren<IDangerous>()!=null)
                {
                    OnBodyFound();
                    return;
                }
            }
            SwitchState(alarmedState);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<IDangerous>() != null && Vector3.Distance(transform.position,other.transform.position)<=closeRange)
        {
            SwitchState(alarmedState);
        } 
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, (fieldOfView*90)-90,0) * transform.forward*3f);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, (fieldOfView *-90)+90, 0) * transform.forward*3f);
    }

}
