using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float moveRange = 10.0f;
    public float gunCooldown = 0.1f;
    public float maxHealth = 100.0f;
    public float hpRegenWait = 0.25f;
    public float yPos = 0;
    public float sideBulletAngle = 10.0f;
    public string sceneOnDeath = "Menu";

    public CharacterController cc;
    public ObjectPool bulletPool;

    public float Health
    {
        get
        {
            return health;
        }
    }

    private float gunHeat = 0;
    private float health;
    private float regenTimer = 0;



    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        float move = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;

        cc.Move(Vector3.right * move);

        if (transform.position.x > moveRange)
        {
            transform.position = new Vector3(moveRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -moveRange)
        {
            transform.position = new Vector3(-moveRange, transform.position.y, transform.position.z);
        }

        if(transform.position.y != yPos)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }


        if(regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
        }

        if(regenTimer <= 0)
        {
            regenTimer = hpRegenWait;
            if(health <= maxHealth - 1.0f)
            {
                Damage(-1.0f);
                StaticStuff.score += 1;
                StaticStuff.OnScoreChange();
            }
        }



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
            o.GetComponent<PlayerBullet>().Shoot();

            o = bulletPool.GetObject();
            o.transform.position = transform.position;
            o.transform.eulerAngles = transform.eulerAngles + new Vector3(0, sideBulletAngle, 0);
            o.SetActive(true);
            o.GetComponent<PlayerBullet>().Shoot();

            o = bulletPool.GetObject();
            o.transform.position = transform.position;
            o.transform.eulerAngles = transform.eulerAngles + new Vector3(0, -sideBulletAngle, 0);
            o.SetActive(true);
            o.GetComponent<PlayerBullet>().Shoot();
        }
    }



    public void Damage(float amt)
    {
        health -= amt;
        StaticStuff.OnHealthChange();
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        SceneManager.LoadScene(sceneOnDeath);
    }
    

}
