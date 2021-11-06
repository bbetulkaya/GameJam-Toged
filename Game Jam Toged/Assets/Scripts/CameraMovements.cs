using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] public Transform target;

    [SerializeField] public float smoothSpeed = 0.125f;
    [SerializeField] public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // transform.position = smoothedPosition;

        // Cam only follow z axis 

        transform.position = new Vector3(offset.x, offset.y, smoothedPosition.z);
    }
}
