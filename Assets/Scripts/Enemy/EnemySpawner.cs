using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawnRadius = 5f;

    [SerializeField]
    private float minSpawnInterval = 1f;

    [SerializeField]
    private float maxSpawnInterval = 3f;

    [SerializeField]
    private float enemyLifetime = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            StartCoroutine(DestroyEnemyAfterDelay(newEnemy, enemyLifetime));

            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        return transform.position + new Vector3(randomPoint.x, randomPoint.y, 0);
    }

    IEnumerator DestroyEnemyAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (enemy != null)
        {
            Destroy(enemy);
        }
    }
}
