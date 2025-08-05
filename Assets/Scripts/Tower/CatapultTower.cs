using UnityEngine;

public class CatapultTower : Tower
{
    [SerializeField] private GameObject projectilePrefab;

    protected override void Update()
    {
        base.Update();
    }
    protected override void FireAt(Enemy target)
    {
        if (projectilePrefab != null)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileInstance.GetComponent<Projectile>().SetTarget(target.transform);
        }
    }
    protected override Enemy GetTargetEnemy()
    {
        ClearDestroyedEnemies();

        Vector3 sumOfPositions = Vector3.zero;
        int enemyCount = 0;

        foreach(Enemy enemy in enemiesInRange)
        {
            if(enemy!= null)
            {
                sumOfPositions += enemy.transform.position;
                enemyCount++;
            }
        }
        if(enemyCount == 0)
        {
            return null;
        }
        Vector3 averageOfPositions = sumOfPositions / enemyCount;

        Enemy closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (Enemy enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, averageOfPositions);
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
