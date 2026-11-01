using UnityEngine;

public class FallReset : MonoBehaviour
{
    public float fallHeight = -5f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody rb;

    void Start()
    {
        // Save the starting position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if skateboard falls below the reset height
        if (transform.position.y < fallHeight)
        {
            ResetSkateboard();
        }
    }

    void ResetSkateboard()
    {
        // Move back to starting position
        transform.position = startPosition;

        // Reset rotation
        transform.rotation = startRotation;

        // Stop movement
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

