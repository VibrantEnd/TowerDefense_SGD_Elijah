using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float FireCoolDown = 1.0f;

    protected float currentFireCooldown = 0.0f;
    protected List<Enemy> enemiesInRange= new List<Enemy>();
    private void Update()
    {
        currentFireCooldown -= Time.deltaTime;
        Enemy closestEnemy = GetTargetEnemy();
        if (closestEnemy != null && currentFireCooldown <= 0)
        {
            FireAt(closestEnemy);
            currentFireCooldown = FireCoolDown;
        }
    }
    protected abstract void FireAt(Enemy target);
    
    protected abstract Enemy GetTargetEnemy();
    protected void ClearDestroyedEnemies()
    {
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            if (enemiesInRange[i] == null)
            {
                enemiesInRange.RemoveAt(i);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy!=null && enemiesInRange.Contains(enemy))
        {

        }
    }
}
