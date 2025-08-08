using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Explosion : MonoBehaviour
{
    int projectileDamage = 10;
    private void Awake()
    {
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
