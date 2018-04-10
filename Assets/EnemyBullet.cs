using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float lifetime = 5.0f;
    public float dmg = 10.0f;
    public float shootForce = 10.0f;

    public Rigidbody body;


    public void Shoot()
    {
        body.velocity = Vector3.zero;
        body.AddForce(transform.forward * shootForce, ForceMode.Impulse);
        Invoke("Deactivate", lifetime);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Deactivate();
        }
    }

}
