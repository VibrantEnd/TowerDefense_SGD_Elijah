using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    [SerializeField] private Transform endPoint;
    [SerializeField] private string animatorParam_IsWalking;

    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
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
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
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
