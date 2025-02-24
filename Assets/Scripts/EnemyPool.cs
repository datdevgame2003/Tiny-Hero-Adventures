using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance { get; private set; }

    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int initialSize = 5;
    private Queue<Enemy> pool = new Queue<Enemy>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < initialSize; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform);
            enemy.gameObject.SetActive(false);
            pool.Enqueue(enemy);
        }
    }

    public Enemy GetEnemy(Vector3 spawnPosition)
    {
        Enemy enemy;
        if (pool.Count > 0)
        {
            enemy = pool.Dequeue();
        }
        else
        {
            enemy = Instantiate(enemyPrefab, transform);
        }

        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);
        return enemy;
    }

    public void ReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
        FindObjectOfType<EnemySpawner>().EnemyDestroyed();
    }
}
