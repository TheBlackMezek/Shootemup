using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float moveRange = 10.0f;
    public float gunCooldown = 0.1f;

    public CharacterController cc;
    public ObjectPool bulletPool;
    private float gunHeat = 0;


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
        }
    }

}
