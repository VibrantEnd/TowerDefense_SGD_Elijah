using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField] private Transform endPoint;
    [SerializeField] private string animatorParam_IsWalking;
    [SerializeField] private int damage;

    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        animator.SetBool(animatorParam_IsWalking, true);
    }

    public void Initialize(Transform inputEndPoint)
    {
        endPoint = inputEndPoint;
        agent.SetDestination(endPoint.position);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (agent.hasPath || agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                ReachedEnd();
            }
            
        }
        
    }
    private void ReachedEnd()
    {
        animator.SetBool(animatorParam_IsWalking, false);
        GameManager.Instance.playerHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
}
