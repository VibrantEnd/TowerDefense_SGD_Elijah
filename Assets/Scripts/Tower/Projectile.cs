using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
   [SerializeField] public int damage = 10;


   [SerializeField] private float speed = 20f;
   [SerializeField] private float lifetime = 3f;
   [SerializeField] private bool explosive = false;
   [SerializeField] private bool piercing = false;

   [SerializeField] private bool stuck = false;
   [SerializeField] private bool sticky = false;

   [SerializeField] Vector3 finalDirection;
   [SerializeField] Quaternion finalRotation;
   [SerializeField] private GameObject explosivePrefab;
   [SerializeField] private int PathLayer = 7;

   private Transform target;
   void Start()
   {
       Destroy(gameObject, lifetime);
   }


   void Update()
   {
        if((target != null || piercing) && !stuck)
        {
            transform.position += finalDirection * speed * Time.deltaTime;
            transform.rotation = finalRotation;
        }
   }
   private void Explosion()
   {
        Instantiate(explosivePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   public void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.layer == PathLayer && explosive)
       {
            Explosion();
       }
       else if (other.gameObject.layer == PathLayer && sticky)
       {
           stuck = true;
       }
       if (other.transform == target && !explosive)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

            }
        }
       if (other.transform == target && explosive)
       {
           Enemy enemy = other.GetComponent<Enemy>();
           if (enemy != null)
           {
                Explosion();
           }
       }
   }
    public void SetTarget(Transform other) 
    {
        target = other;
        finalDirection = ((target.position + new Vector3(0,.5f,0)) - transform.position).normalized;
        finalRotation = Quaternion.LookRotation(finalDirection);
    }

}
