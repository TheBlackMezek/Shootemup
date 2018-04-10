using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnInterval = 2.0f;

    public ObjectPool bulletPool;
    public GameObject enemyPrefab;

    private float spawnCooldown = 0;



    private void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }

        if (spawnCooldown <= 0)
        {
            spawnCooldown = spawnInterval;

            GameObject o = Instantiate(enemyPrefab);
            o.transform.position = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f),
                                               transform.position.y,
                                               transform.position.z);

            EnemyController c = o.GetComponent<EnemyController>();
            c.bulletPool = bulletPool;
        }
    }

}
