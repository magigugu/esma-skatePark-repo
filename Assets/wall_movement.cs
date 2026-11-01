using UnityEngine;

public class wall_movement : MonoBehaviour
{
    public float moveDistance = 9f;
    public float speed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, moveDistance);

        transform.position = startPosition + Vector3.right * movement;
    }
}


