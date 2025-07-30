using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifetime = 3f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
    public void SetTarget(Transform inputTarget)
    {
        if(other.transform == target)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null )
            {
                Destroy(enemy.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
