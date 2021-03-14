using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
            {
                Destroy(collision.gameObject);
                break;
            }
        }
    }
}
