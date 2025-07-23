using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField] private Transform endPoint;
    [SerializeField] private string animatorParam_IsWalking;

    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        agent.SetDestination(endPoint.position);
        animator.SetBool(animatorParam_IsWalking, true);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (agent.hasPath || agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                animator.SetBool(animatorParam_IsWalking, false);
            }
            
        }
        
    }
}
