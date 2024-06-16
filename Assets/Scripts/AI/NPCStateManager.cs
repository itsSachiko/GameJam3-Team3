using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{
    [Header("Game Design")]
    [SerializeField,Range(-1,1)] float fieldOfView;
    [SerializeField]float closeRange;
    [SerializeField] float alarmedRange;
    [SerializeField] public float stopTime;
    public List<Transform> checkpoints = new List<Transform>();
    public float lockSpeed;


    [Header("Ignore this")]
    public NavMeshAgent agent;
    NPCBaseState currentState;
    public NPCIdleState idleState=new NPCIdleState();
    public NPCPathrollingState pathState = new NPCPathrollingState();
    public NPCAlarmedState alarmedState = new NPCAlarmedState();
    public NPCLockdownState lockdownState = new NPCLockdownState();


    public delegate void NPCState();
    public static event NPCState Lock;
    public LayerMask mask;

    private void OnEnable()
    {
        Lock += EveryoneLock;
    }
    private void OnDisable()
    {
        Lock -= EveryoneLock;
    }

    private void EveryoneLock()
    {
        agent.speed = lockSpeed;
        agent.isStopped = false;
        GameManager.Instance.time = 60;
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


    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Vector3.Dot(transform.forward, Vector3.Normalize(other.transform.position - transform.position)) >= fieldOfView)
        {
            agent.isStopped = true;
            SwitchState(alarmedState);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null && Vector3.Distance(transform.position, other.transform.position) <= closeRange)
        {
            agent.isStopped=true;
            //check che il player abbia larma ecc nell inventario
            SwitchState(alarmedState);
        }

        //idangerous=script del corpo del bersaglio o qualsiasi altra cosa che triggeri alarmedstate

        if (other.gameObject.GetComponent<IDangerous>() != null&&Vector3.Dot(transform.forward, Vector3.Normalize(other.transform.position - transform.position)) >= fieldOfView)
        {
            agent.isStopped = true;
            Collider[] collider = Physics.OverlapSphere(other.transform.position,alarmedRange,mask);
            for(int i = 0;i<collider.Length;i++)
            {
                Debug.Log(collider[i]);
                if (collider[i].gameObject.GetComponent<PlayerController>()== other.gameObject.GetComponent<PlayerController>())
                {
                    Lock();
                    return;
                }
            }
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
