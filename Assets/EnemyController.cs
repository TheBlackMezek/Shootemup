using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxHealth = 20.0f;
    public float gunCooldown = 0.5f;

    public ObjectPool bulletPool;

    private float gunHeat = 0;



    private void Update()
    {
        if(gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }

        if(gunHeat <= 0)
        {
            gunHeat = gunCooldown;

            GameObject o = bulletPool.GetObject();
            o.transform.position = transform.position;
            o.transform.rotation = transform.rotation;
            o.SetActive(true);
            o.GetComponent<EnemyBullet>().Shoot();
        }
    }


}
