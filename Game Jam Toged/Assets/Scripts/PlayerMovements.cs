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

        // if the player is in boundary move normal
        if (this.gameObject.transform.position.x >= LevelBoundary.leftSide &&
            this.gameObject.transform.position.x <= LevelBoundary.rightSide)
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
        // if player not in boundary check three different state
        else
        {
            // check if player in left boundary and press right direction then allow to player move
            if (this.gameObject.transform.position.x <= LevelBoundary.leftSide && _horizontalInput > 0)
            {
                rb.MovePosition(rb.position + forwardMove + horizontalMove);

            }
            // check if player in right boundary and press left direction then allow to player move
            else if (this.gameObject.transform.position.x >= LevelBoundary.rightSide && _horizontalInput < 0)
            {
                rb.MovePosition(rb.position + forwardMove + horizontalMove);
            }
            // if neither one of them only allow to forward movement
            else
            {
                rb.MovePosition(rb.position + forwardMove);
            }
        }
    }


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }
}
