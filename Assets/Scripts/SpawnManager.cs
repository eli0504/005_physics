using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerupPrefabs;

    private int enemiesInScene;
    private int enemiesPerWave = 1;
    private float spawnRange = 9f; //límite de la plataforma
    

    private void Start()
    {
        SpawnEnemyWave(enemiesPerWave); //instanciar un enemigo
    }

    private void Update()
    {
        //buscamos la cantidad de enemigos que hay en escena
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        if(enemiesInScene <= 0)
        {
            //si me quedo sin enemigos en escena
            //aumento en uno los enemigos por oleada
            enemiesPerWave++;
            //llamo a una nueva oleada
            SpawnEnemyWave(enemiesPerWave);
        }
    }
    private Vector3 RandomSpawnPosition()
    {
        float randX = Random.Range(-spawnRange, spawnRange);
        float randZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randX, 0, randZ);
    }

    private void SpawnEnemyWave (int enemiesToSpawn)
    {
        int randomIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomIndex], RandomSpawnPosition(), Quaternion.identity);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(), Quaternion.identity);
        }
    }
}
