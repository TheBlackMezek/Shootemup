using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float lifetime = 5.0f;
    public float dmg = 10.0f;
    public float shootForce = 10.0f;

    public Rigidbody body;

    private bool hasHit = false;



    public void Shoot()
    {
        hasHit = false;
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
        if (!hasHit && collision.transform.tag == "Enemy")
        {
            hasHit = true;
            EnemyController c = collision.transform.GetComponent<EnemyController>();
            c.Damage(dmg);
        }
        CancelInvoke();
        Deactivate();
    }

}
