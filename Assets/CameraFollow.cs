using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f, 5f, -8f);
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly follow target
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        // Look at the player
        transform.LookAt(target);
    }
}

