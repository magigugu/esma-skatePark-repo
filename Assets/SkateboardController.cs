
using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float turnSpeed = 10f;

    [Header("Jump")]
    public float jumpForce = 8f;
    public float airSpinSpeed = 360f;
    public float airMoveSpeed = 5f;

    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // GROUND MOVEMENT
        if (isGrounded && movement.magnitude > 0.1f)
        {
            movement.Normalize();

            transform.position +=
                movement * moveSpeed * Time.deltaTime;

            Quaternion targetRotation =
                Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );
        }

        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // AIR MOVEMENT
        if (!isGrounded)
        {
            // Allow forward and backward movement in midair
            Vector3 airMovement = transform.forward * vertical;

            rb.AddForce(
                airMovement * airMoveSpeed,
                ForceMode.Force
            );

            // Allow air spinning
            transform.Rotate(
                0f,
                horizontal * airSpinSpeed * Time.deltaTime,
                0f,
                Space.World
            );
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}


