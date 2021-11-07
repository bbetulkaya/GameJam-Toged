using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator enemyAnim;
    [SerializeField] public float smoothSpeed = 0.125f;
    [SerializeField] public Vector3 offset;
    public PlayerMovements player;
    public CameraMovements cameraMovements;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlayerBleeding)
        {

            enemyAnim.SetBool("isVampireRunning", true);
            cameraMovements.offset.z = -10f;

            // enemy follow to player
            Vector3 desiredPosition = player.transform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, 0.5f, smoothedPosition.z);

        }
        else
        {
            cameraMovements.offset.z = -5f;
            enemyAnim.SetBool("isVampireRunning", false);
        }
    }
}
