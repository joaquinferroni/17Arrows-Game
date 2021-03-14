using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightAndLeftEnemy : MonoBehaviour
{
    public int speed = 6;
    private bool moveLeft;

    private float defaultY;
    // Start is called before the first frame update
    void Start()
    {
        var number = Random.Range(0, 100);
        moveLeft = number > 49;
        defaultY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.name == "WallLeft")
                moveLeft = false;
            else
                moveLeft = true;
            MoveObject();
        }
    }

    private void MoveObject()
    {
        transform.rotation = Quaternion.identity;
        if (moveLeft)
        {
            transform.Translate(-speed*Time.deltaTime, 0, 0);
                //position += new Vector3(-transform.right * speed * Time.deltaTime, defaultY, defaultY); 
        }
        else
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            //transform.position += (transform.right * speed * Time.deltaTime);
        }
    }

}
