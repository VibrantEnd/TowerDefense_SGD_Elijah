using System.Collections;
using UnityEngine;

public struct SpawnData
{
    public GameObject EnemyToSpawn;
    public float TimeBeforeSpawn;
    public Transform SpawnPoint;
    public Transform EndPoint;
}

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private float timeBetweenWaves = 5f;

    [SerializeField] private int enemyCount = 5;
    [SerializeField] private int waveCount = 2;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
       for (int j = 0; j < enemyCount; j++)
       {
                yield return new WaitForSeconds(timeBetweenSpawns);
           SpawnEnemy();
       }
    }
    public void SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Enemy enemy = enemyInstance.GetComponent<Enemy>();
        enemy.Initialize(endPoint);
    }
}
