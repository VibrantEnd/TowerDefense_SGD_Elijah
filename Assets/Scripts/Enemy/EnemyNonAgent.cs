using System.Net;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class EnemyNonAgent : Enemy
{
    private float moveSpeed;
    private Vector3 finalDirection;
    private Quaternion finalRotation;
    private float distance;
    private Vector3 finalPosition;

    protected override void Start()
    {
        moveSpeed = speed;
        base.Start();
    }
    protected override void SetDestination(Transform endPoint)
    {
        finalDirection = ((endPoint.position + new Vector3(0, .5f, 0)) - transform.position).normalized;
        finalRotation = Quaternion.LookRotation(finalDirection);
        finalPosition = (endPoint.position+ new Vector3(0,.5f,0));
        distance = ((finalPosition) - transform.position).magnitude;
    }
    // Update is called once per frame
    void Update()
    {
        if(distance > .3)
        {
            transform.position += finalDirection * speed * Time.deltaTime;
            transform.rotation = finalRotation;
            distance = ((finalPosition) - transform.position).magnitude;
        }
        else
        {
            ReachedEnd();
        }
        
    }
}
