using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameManager gameManager;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 16.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.75f;
    public bool spawningActive = false;

    private float startDelay = 1f;
    private float enemySpawnTime = 2.5f;
    private float powerupSpawnTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameInactive && !spawningActive)
        {
            InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
            InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
            spawningActive = true;
        }
    }
    void SpawnEnemy()
    {
        if (!gameManager.gameOver)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new(randomX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
        }
    }
    void SpawnPowerup()
    {
        if (!gameManager.gameOver)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

            Vector3 spawnPos = new(randomX, ySpawn, zEnemySpawn);
            Instantiate(powerup, spawnPos, powerup.transform.rotation);
        }
    }
}
