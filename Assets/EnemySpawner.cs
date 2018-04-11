using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public struct EnemyWave
{
    public Vector2 spawnOrigin;
    public float xRange;
    public float zRange;
    public List<GameObject> enemyPrefabs;
}


public class EnemySpawner : MonoBehaviour {

    public float spawnInterval = 2.0f;
    public float spawnRate = 0.1f;
    public float waitBetwenWaves = 5.0f;

    public List<EnemyWave> waves;

    public ObjectPool bulletPool;
    public GameObject enemyPrefab;

    private float spawnCooldown = 0;
    private float waveCooldown = 0;
    private int currentWave = 0;
    private int currentSpawn = 0;



    private void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }

        if (spawnCooldown <= 0)
        {
            spawnCooldown = spawnInterval;

            if(currentSpawn < waves[currentWave].enemyPrefabs.Count)
            {
                Vector3 origin = new Vector3(waves[currentWave].spawnOrigin.x,
                                             0,
                                             waves[currentWave].spawnOrigin.y);
                float xrange = waves[currentWave].xRange;
                float zrange = waves[currentWave].zRange;
                GameObject o = Instantiate(waves[currentWave].enemyPrefabs[currentSpawn]);
                o.transform.position = new Vector3(origin.x + Random.Range(-xrange, xrange),
                                                   origin.y,
                                                   origin.z + Random.Range(-zrange, zrange));

                EnemyController c = o.GetComponent<EnemyController>();
                c.bulletPool = bulletPool;
                c.SetChildPools();

                ++currentSpawn;
            }
        }

        if (currentSpawn >= waves[currentWave].enemyPrefabs.Count)
        {
            waveCooldown += Time.deltaTime;

            if(waveCooldown >= waitBetwenWaves)
            {
                waveCooldown = 0;
                currentSpawn = 0;
                ++currentWave;
                if(currentWave >= waves.Count)
                {
                    currentWave = 0;
                }
            }
        }
    }

}
