using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        bool spawnLeft = Random.value < 0.5f;
        
        Transform spawnPoint = spawnLeft ? leftSpawnPoint : rightSpawnPoint;
        
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        
        if (!spawnLeft)
        {
            Vector3 scale = enemy.transform.localScale;
            scale.x *= -1;
            enemy.transform.localScale = scale;
        }
    }
}