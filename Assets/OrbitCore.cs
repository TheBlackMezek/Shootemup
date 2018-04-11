using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCore : MonoBehaviour {

    public float gravConst = 1.0f;
    public float myMass = 1.0f;
    public OrbitObj[] sats;



    private void Update()
    {
        foreach(OrbitObj o in sats)
        {
            if(o == null)
            {
                continue;
            }
            Transform t = o.transform;
            float dist = Vector3.Distance(t.position, transform.position);
            float force = (gravConst * myMass * o.mass) / (dist * dist);
            Vector3 velMod = (t.position - transform.position).normalized * force;

            o.vel -= velMod;
            t.position += o.vel * Time.deltaTime;
        }
    }

}
