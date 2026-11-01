using UnityEngine;

public class enemy_wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Skateboard")
        {
            skate_damage skateboard = collision.gameObject.GetComponent<skate_damage>();

            if (skateboard != null)
            {
                skateboard.TakeDamage();
            }
        }
    }
}


