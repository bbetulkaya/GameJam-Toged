using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float sideSpeed = 2f;
    [SerializeField] public float horizantalMultiplier = 2f;

    private Rigidbody rb;
    private float _horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * sideSpeed * _horizontalInput * Time.fixedDeltaTime;


        if (this.gameObject.transform.position.x > LevelBoundary.leftSide &&
            this.gameObject.transform.position.x < LevelBoundary.rightSide)
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
        else
        {
            rb.MovePosition(rb.position + forwardMove + -horizontalMove);
        }
    }


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }
}
