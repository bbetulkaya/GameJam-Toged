using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    public float damageValue;
    public float damageImpact;
    public string obstacleName;
    public float speed = 5f;

    public Rigidbody rb;
    void Start()
    {
        obstacleName = this.gameObject.name;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 forwardMove = -transform.forward * speed * Time.fixedDeltaTime;
        // transform.Translate(forwardMove, Space.World);
        rb.MovePosition(rb.position + forwardMove);
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
