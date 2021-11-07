using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] public float blood = 100f;
    [SerializeField] public float bloodLostSpeed = 1f;
    [SerializeField] public bool isPlayerBleeding = false;

    [Header("Player Movements")]
    [SerializeField] public float speed = 5f;
    [SerializeField] public float sideSpeed = 2f;
    [SerializeField] public float jumpForce = 30f;

    private Rigidbody rb;
    private Animator animator;
    private float _horizontalInput;
    private bool _jumpInput;
    private float distToGround;
    private bool _isInBoundary;
    private bool _isPlayerCanMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        // Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * sideSpeed * _horizontalInput * Time.fixedDeltaTime;

        // if the player is in boundary move normal
        if (_isInBoundary)
        {
            rb.MovePosition(rb.position + horizontalMove);
        }

        // Check player is allowed to move again if it is then move
        else if (_isPlayerCanMove)
        {

            rb.MovePosition(rb.position + horizontalMove);


        }

        // if neither one of them only allow to only forward movement
        else
        {
            rb.MovePosition(rb.position);
        }
    }


    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("JUMP");
            Jump();
        }

        _isInBoundary = IsPlayerInBoundary();
        _isPlayerCanMove = IsPlayerAllowedToMove();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
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
            var obstacle = collision.collider.GetComponent<Obstacle>();
            isPlayerBleeding = true;
            animator.SetBool("isBleeding", isPlayerBleeding);
            CalculateBloodLostSpeed(obstacle.damageImpact);
            StartCoroutine(PlayerBloodLostXTime(bloodLostSpeed, obstacle.damageValue));
        }
        if (collision.collider.CompareTag("Medicine"))
        {
            Destroy(collision.gameObject);
            isPlayerBleeding = false;
            animator.SetBool("isBleeding", isPlayerBleeding);
            bloodLostSpeed = 1;
            Debug.Log("Player took the medicine");
        }
    }

    private void CalculateBloodLostSpeed(float damage)
    {
        bloodLostSpeed = bloodLostSpeed + damage;
    }

    IEnumerator PlayerBloodLostXTime(float totalTicks, float damageValue)
    {
        blood -= damageValue * bloodLostSpeed;
        yield return new WaitForSeconds(2);

        if (isPlayerBleeding)
        {
            StartCoroutine(PlayerBloodLostXTime(totalTicks, damageValue));
        }
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
