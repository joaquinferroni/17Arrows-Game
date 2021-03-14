using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Destroyer":
            {
              // Destroy(gameObject);
                break;
            }
        }
    }
}