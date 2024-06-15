using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{
    [Header("Game Design")]
    [SerializeField,Range(-1,1)] float view;
    [SerializeField]float blueRange;
    [SerializeField] public float delay;
    public List<Transform> transforms = new List<Transform>();


    public NavMeshAgent agent;
    NPCBaseState currentState;
    public NPCIdleState idleState=new NPCIdleState();
    public NPCPathrollingState pathState = new NPCPathrollingState();
    public NPCAlarmedState alarmedState = new NPCAlarmedState();


    public delegate void ClickAction();
    public static event ClickAction OnClicked;


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
        if (Vector3.Dot(transform.forward, Vector3.Normalize(other.transform.position-transform.position))>=view)
        {
            SwitchState(alarmedState);
            Debug.Log("Player in");
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null && Vector3.Distance(transform.position, other.transform.position) <= blueRange)
        {
            //check che il player abbia larma ecc nell inventario
            SwitchState(alarmedState);
        }
        if (other.gameObject.GetComponent<IDangerous>() != null&&Vector3.Dot(transform.forward, Vector3.Normalize(other.transform.position - transform.position)) >= view)
        {
            SwitchState(alarmedState);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, (view*90)-90,0) * transform.forward*3f);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, (view *-90)+90, 0) * transform.forward*3f);
    }

}
