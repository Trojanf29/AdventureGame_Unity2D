using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRadius = 5f;
    [SerializeField] private float minSpawnInterval = 1f; // Thời gian tối thiểu giữa các lần spawn
    [SerializeField] private float maxSpawnInterval = 3f; // Thời gian tối đa giữa các lần spawn
    [SerializeField] private float enemyLifetime = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Tạo enemy
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Xóa enemy sau thời gian lifetime
            StartCoroutine(DestroyEnemyAfterDelay(newEnemy, enemyLifetime));

            // Chờ một khoảng thời gian ngẫu nhiên trước khi spawner enemy tiếp theo
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
