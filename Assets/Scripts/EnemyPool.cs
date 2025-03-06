using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance { get; private set; }

    [SerializeField] private EnemyAI enemyPrefab;
    [SerializeField] private int initialSize = 5;
    private Queue<EnemyAI> pool = new Queue<EnemyAI>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < initialSize; i++)
        {
            EnemyAI enemy = Instantiate(enemyPrefab, transform);
            enemy.gameObject.SetActive(false);
            pool.Enqueue(enemy);

        }
    }

    public EnemyAI GetEnemy(Vector3 spawnPosition)
    {
        EnemyAI enemy;
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

    public void ReleaseEnemy(EnemyAI enemy)
    {
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
        FindObjectOfType<EnemySpawner>().EnemyDestroyed();
    }
}
