using System;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private const float VALUE_COUNTDOWN = 3f;
    private float _timeToReduceInSeconds = VALUE_COUNTDOWN;
    public Text countDownText;
    private bool shouldCountDown;

    private Action _afterCountDown;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (shouldCountDown)
        {
            _timeToReduceInSeconds -= Time.deltaTime;
            countDownText.text = (_timeToReduceInSeconds).ToString("0");
            if (_timeToReduceInSeconds < 0)
            {
                
                GameObject.Find("Timer").SetActive(false);
                _afterCountDown();
                //Do something useful or Load a new game scene depending on your use-case
            }
        }
    }

    public void StartCountDown(Action AfterCountDown)
    {
        this.shouldCountDown = true;
        _afterCountDown = AfterCountDown;
    }

    public void StopCountDown()
    {
        _timeToReduceInSeconds = VALUE_COUNTDOWN;
        shouldCountDown = false;
    }

}
