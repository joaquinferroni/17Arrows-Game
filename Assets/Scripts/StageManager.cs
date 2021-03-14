using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private GameObject _player;
    private GameObject _destroyer;
    private GameObject _countDown;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _destroyer = GameObject.Find("Destroyer");
        _countDown = GameObject.Find("Timer");
        StartGame();
    }
    void StartGame()
    {
        ResumeGame();
        _countDown.GetComponent<CountDown>().StartCountDown(ActionsOnStart());
        
    }

    private Action ActionsOnStart()
    {
        var playerScript = _player.GetComponent<MoveForward>();
        var destroyerScript = _destroyer.GetComponent<MoveForward>();
        Action act = playerScript.StartMoving;
        act += destroyerScript.StartMoving;
        act += () => { FullGameInformation.ChangeState(GameState.PLAYING);};
        return act;
    }

    public bool IsPaused() => Time.timeScale == 0;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void LoseGame()
    {
        PauseGame();
        FullGameInformation.ChangeState(GameState.LOSE);
        SceneManager.LoadScene("EndGame", LoadSceneMode.Additive);
    }

    public void WinGame()
    {
        PauseGame();
        FullGameInformation.ChangeState(GameState.WIN);
        SceneManager.LoadScene("EndGame", LoadSceneMode.Additive);
    }

}
