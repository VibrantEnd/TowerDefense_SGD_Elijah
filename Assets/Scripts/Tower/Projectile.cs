using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] private int damage = 10;
   [SerializeField] private float speed = 20f;
   [SerializeField] private float lifetime = 3f;
   [SerializeField] private bool explosive=false;

   [SerializeField] private GameObject explosivePrefab;

   private Transform target;
   void Start()
   {
       Destroy(gameObject, lifetime);
   }

   // Update is called once per frame
   void Update()
   {
        if(target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
   }
    
   public void OnTriggerEnter(Collider other)
   {
       if(other.transform == target && !explosive)
       {
           Enemy enemy = other.GetComponent<Enemy>();
           if(enemy != null )
           {
               Destroy(enemy.gameObject);
           }
       }
        if (other.transform == target && explosive)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Instantiate(explosivePrefab, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
   }
    public void SetTarget(Transform other) 
    {
        target = other;
    }

}
