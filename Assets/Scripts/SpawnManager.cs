using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int waveNumber = 1;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);

    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 1, spawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<Enemy>().Length == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
}
