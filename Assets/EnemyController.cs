using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxHealth = 20.0f;
    public float gunCooldown = 0.5f;
    public int scoreOnKill = 100;

    public ObjectPool bulletPool;

    private float gunHeat = 0;
    private float health;



    private void Start()
    {
        health = maxHealth;
    }

    public void SetChildPools()
    {
        foreach (Transform t in transform)
        {
            EnemyController c = t.GetComponent<EnemyController>();
            if (c != null)
            {
                c.bulletPool = bulletPool;
                c.SetChildPools();
            }
        }
    }

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



    public void Damage(float amt)
    {
        health -= amt;
        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        StaticStuff.score += scoreOnKill;
        StaticStuff.OnScoreChange();
        Destroy(gameObject);
    }


}
