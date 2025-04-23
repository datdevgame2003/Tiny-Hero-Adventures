//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyPool : MonoBehaviour
//{
    //public static EnemyPool Instance { get; private set; }

    //[SerializeField] private Golem enemyPrefab;
    //[SerializeField] private int initialSize = 5;
    //private Queue<Golem> pool = new Queue<Golem>();

    //private void Awake()
    //{
    //    Instance = this;
    //    for (int i = 0; i < initialSize; i++)
    //    {
    //        Golem enemy = Instantiate(enemyPrefab, transform);
    //        enemy.gameObject.SetActive(false);
    //        pool.Enqueue(enemy);

    //    }
    //}

    //public Golem GetEnemy(Vector3 spawnPosition)
    //{
    //    Golem enemy;
    //    if (pool.Count > 0)
    //    {
    //        enemy = pool.Dequeue();
    //    }
    //    else
    //    {
    //        enemy = Instantiate(enemyPrefab, transform);
    //    }

    //    enemy.transform.position = spawnPosition;
    //    enemy.gameObject.SetActive(true);
    //    return enemy;
    //}

    //public void ReleaseEnemy(Golem enemy)
    //{
    //    enemy.gameObject.SetActive(false);
    //    pool.Enqueue(enemy);
    //    FindObjectOfType<EnemySpawner>().EnemyDestroyed();
    //}
//}
