using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardMove : MonoBehaviour
{
    Vector3 Vec;

    private int speed;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.current;
        speed = int.Parse(FullGameInformation.GetValue(GeneralInfo.SPEED, "30"));
    }

    // Update is called once per frame
    void Update()
    {
        if (FullGameInformation.GetState() != GameState.PLAYING) return;
        Vec = transform.localPosition;
        //Vec.y += Input.GetAxis("Jump") * Time.deltaTime * 20;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed / 2;
        //Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;
        transform.localPosition = Vec;
        Debug.Log("position x: "+transform.position.x);
        for (var i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            var screenPosition = cam.WorldToScreenPoint(transform.position);
            if (touch.position.x < screenPosition.x)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else if (touch.position.x > screenPosition.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }
    }

   

}
