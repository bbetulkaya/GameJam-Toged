using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float sideSpeed = 2f;
    [SerializeField] public float jumpSpeed = 10f;
    [SerializeField] public float horizantalMultiplier = 2f;

    private Rigidbody rb;
    private float _horizontalInput;
    private bool _jumpInput;
    private bool _isInBoundary;
    private bool _isPlayerCanMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * sideSpeed * _horizontalInput * Time.fixedDeltaTime;

        if (_jumpInput)
        {
            rb.velocity = transform.up * jumpSpeed;
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            // rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }

        // if the player is in boundary move normal
        if (_isInBoundary)
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }

        // Check player is allowed to move again if it is then move
        else if (_isPlayerCanMove)
        {

            rb.MovePosition(rb.position + forwardMove + horizontalMove);


        }

        // if neither one of them only allow to only forward movement
        else
        {
            rb.MovePosition(rb.position + forwardMove);
        }
    }


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _jumpInput = Input.GetKeyDown(KeyCode.Space);

        _isInBoundary = IsPlayerInBoundary();
        _isPlayerCanMove = IsPlayerAllowedToMove();
    }

    bool IsPlayerInBoundary()
    {
        if (this.gameObject.transform.position.x >= LevelBoundary.leftSide &&
        this.gameObject.transform.position.x <= LevelBoundary.rightSide)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsPlayerAllowedToMove()
    {
        if (this.gameObject.transform.position.x <= LevelBoundary.leftSide && _horizontalInput > 0)
        {
            return true;

        }
        // check if player in right boundary and press left direction then allow to player move
        else if (this.gameObject.transform.position.x >= LevelBoundary.rightSide && _horizontalInput < 0)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if (collision.collider.name == "Small")
            {
                Debug.Log("small blood lost");
            }
            if (collision.collider.name == "Wide")
            {
                Debug.Log("more blood lost");
            }
        }
    }
}
