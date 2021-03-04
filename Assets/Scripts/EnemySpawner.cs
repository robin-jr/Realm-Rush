using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float minSpanBetweenEnemies = 2f;
    [SerializeField] float maxSpanBetweenEnemies = 4f;
    [SerializeField] bool spawnEnemies = true;
    void Start()
    {
        if (enemyPrefab)
            StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnEnemies)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            FindObjectOfType<GameSession>().IncreaseScore();
            yield return new WaitForSeconds(Random.Range(minSpanBetweenEnemies, maxSpanBetweenEnemies));
        }
    }
}
