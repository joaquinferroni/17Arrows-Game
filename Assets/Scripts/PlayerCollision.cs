using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var stageManagerScript = GameObject.Find("StageController").GetComponent<StageManager>();
        if (stageManagerScript.IsPaused()) return;
        switch (collision.gameObject.tag)
        {
            case "Finish":
            {
                stageManagerScript.WinGame();
                break;
            }
            case "Enemy":
            {
                stageManagerScript.LoseGame();
                break;
            }
        }
    }
}