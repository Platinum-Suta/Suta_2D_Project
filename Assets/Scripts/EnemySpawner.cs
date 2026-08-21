using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public float timeToSpawn = 0.5f;
    bool canSpawn = true;

    public float minRange = -10f;
    public float maxRange = 10f;

    
    void Start()
    {
        StartCoroutine(SpawnTimer());
        GameManager.Instance.beginBossFight += StopSpawning;
    }

    void StopSpawning()
    {
        canSpawn = false;
    }

    private void FixedUpdate()
    {
        Vector3 randomPosition = spawnPoint.position;
        randomPosition.x = Random.Range(minRange, maxRange);
        spawnPoint.position = randomPosition;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    IEnumerator SpawnTimer()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(timeToSpawn);
            SpawnEnemy();
        }
        
    }
}
