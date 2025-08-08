using UnityEngine;

public class BallistaTower : Tower
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f,0f);

    protected override void Update()
    {
        base.Update();
    }
    protected override void FireAt(Enemy target)
        {
         if(projectilePrefab  != null)
         {
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position+offset, Quaternion.identity);
            projectileInstance.GetComponent<Projectile>().SetTarget(target.transform);
         }
        }
    protected override Enemy GetTargetEnemy()
    {
        ClearDestroyedEnemies();

        Enemy closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (Enemy enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                } 
            }
        }
        return closestEnemy;
    }
}
