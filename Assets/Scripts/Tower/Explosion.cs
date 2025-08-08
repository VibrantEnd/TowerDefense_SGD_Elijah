using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Explosion : MonoBehaviour
{
    Projectile projectile;
    int projectileDamage;
    private void Awake()
    {
        projectile = GetComponentInParent<Projectile>();
        projectileDamage = projectile.damage;
        StartCoroutine(LifeTime());
    }
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
    Enemy enemy = other.GetComponent<Enemy>();
    if (enemy != null)
        {
            enemy.TakeDamage(projectileDamage);
        }
    }
}
