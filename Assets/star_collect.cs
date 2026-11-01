using UnityEngine;

public class star_collect : MonoBehaviour
{public float spinSpeed = 100f;

    void Update()
    {
        // Make the star spin constantly
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect the Skateboard
        if (other.CompareTag("Player"))
        {
            Debug.Log("STAR COLLECTED!");

            Destroy(gameObject);
        }
    }
}
