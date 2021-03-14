using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private int speed;
    private bool _startMoving;

    void Start()
    {
        speed = int.Parse(FullGameInformation.GetValue(GeneralInfo.SPEED, "40"));
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (_startMoving)
            transform.position += (transform.forward * (int)(speed * 1.75) * Time.deltaTime);
    }

    public void StartMoving()
    {
        this._startMoving= true;
    }
}
