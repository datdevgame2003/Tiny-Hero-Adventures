
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public Transform spawnPoint;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private List<GameObject> paths;
    [SerializeField] private int maxEnemies = 5;
    private int currentEnemyCount = 0;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (currentEnemyCount < maxEnemies) 
            {
                SpawnEnemy();
            }
           
        }
    }
    private void SpawnEnemy()
    {
        //Enemy enemy = EnemyPool.Instance.GetEnemy();
        //enemy.transform.position = spawnPoint.position;
        Vector3 spawnPosition = transform.position;
        Enemy enemy = EnemyPool.Instance.GetEnemy(spawnPosition);
        enemy.GetComponent<EnemyHealth>()?.ResetHealth();
        enemy.SetPath(new List<GameObject>(paths));
        currentEnemyCount++;

    }
    public void EnemyDestroyed()
    {
        currentEnemyCount--; 
    }
}
