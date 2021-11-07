using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    public float damageValue;
    public float damageImpact;
    public string obstacleName;
    public float speed = 5f;
    void Start()
    {
        obstacleName = this.gameObject.name;
    }
    void FixedUpdate()
    {
        Vector3 forwardMove = -transform.forward * speed * Time.fixedDeltaTime;
        transform.Translate(forwardMove);
    }

    void Update()
    {
        // Obstacle life time
        if (transform.position.z < -50f)
        {
            Destroy(this.gameObject);
        }

    }
}
