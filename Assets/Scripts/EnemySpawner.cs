
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public Transform spawnPoint;
    [SerializeField] private float spawnInterval = 2f;
    //[SerializeField] private List<GameObject> paths;
    [SerializeField] private int maxEnemies = 5;
    private int currentEnemyCount = 0;
    [SerializeField] private List<Transform> spawnPoints;
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
        if (spawnPoints.Count == 0) return; // Kiểm tra danh sách có rỗng không

        // Chọn ngẫu nhiên một vị trí trong danh sách
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        //Vector3 spawnPosition = transform.position;
        EnemyAI enemy = EnemyPool.Instance.GetEnemy(randomSpawnPoint.position);
    enemy.GetComponent<EnemyHealth>()?.ResetHealth();
        //enemy.SetPath(new List<GameObject>(paths));
        currentEnemyCount++;

}
public void EnemyDestroyed()
{
    currentEnemyCount--;
}
}
