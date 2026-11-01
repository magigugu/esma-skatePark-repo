using UnityEngine;

public class skate_damage : MonoBehaviour
{
    public int lives = 3;

    public void TakeDamage()
    {
        lives--;

        Debug.Log("Lives remaining: " + lives);

        if (lives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("FAILED!");
        Destroy(gameObject);
    }
}

