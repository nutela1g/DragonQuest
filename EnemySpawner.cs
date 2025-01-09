using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;         // The enemy prefab to spawn
    public Transform player;               // Reference to the player (used for the enemies to follow)
    public float minSpawnInterval = 20f;   // Minimum time between enemy spawns (in seconds)
    public float maxSpawnInterval = 40f;   // Maximum time between enemy spawns (in seconds)
    public float spawnChance = 0.5f;       // Probability to spawn enemies (0.0 to 1.0)
    public Vector3 spawnAreaMin;           // Minimum position for spawning (x, y, z)
    public Vector3 spawnAreaMax;           // Maximum position for spawning (x, y, z)

    private void Start()
    {
        //enemyPrefab.gameObject.SetActive(false);
        // Start the spawn process
        InvokeRepeating(nameof(AttemptSpawn), 0f, 1f);  // Check every second if we should spawn
    }

    private void AttemptSpawn()
    {
        // Generate a random number between 0 and 1 to check if spawning should occur based on the spawn chance
        if (Random.value <= spawnChance)
        {
            // Generate a random interval between the minimum and maximum spawn interval
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Wait for the spawn interval before spawning enemies
            Invoke(nameof(SpawnEnemies), spawnInterval);
        }
    }

    private void SpawnEnemies()
    {
        // Randomly select how many enemies to spawn (between 2 and 4)
        int enemyCount = Random.Range(2, 5); // 2 to 4 enemies

        for (int i = 0; i < enemyCount; i++)
        {
            // Generate a random position within the spawn area
            Vector3 randomSpawnPos = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // Instantiate the enemy prefab at the random position
            GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);
        }
    }
}

