
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : Enemy
{
    public NavMeshAgent agent;
    protected override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        base.Start();
    }
    protected override void SetDestination(Transform endPoint)
    {
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
}
