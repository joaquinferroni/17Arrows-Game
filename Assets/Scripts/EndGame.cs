using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Button _restart;
    public Button _nextLevel;
    public Button _mainMenu;
    public Text _totalLosses;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        switch (FullGameInformation.GetState())
        {
            case GameState.WIN: SetStateWin();
                break;
            case GameState.LOSE: SetStateLose();
                break;
            default: SetStateLose();
                break;
        }
        _restart.onClick.AddListener(Restart);
        _nextLevel.onClick.AddListener(NextLevel);
        _mainMenu.onClick.AddListener(MainMenu);
    }
    private void SetStateLose()
    {
        _nextLevel.gameObject.SetActive(false);
        _restart.gameObject.SetActive(true);
        var totalLosses = FullGameInformation.GetValue(GeneralInfo.TOTAL_LOSSES,"0");
        _totalLosses.text = $"Come on, you are better than {totalLosses} losses!!";
        _totalLosses.gameObject.SetActive(true);
    }

    private void SetStateWin()
    {
        _nextLevel.gameObject.SetActive(true);
        _restart.gameObject.SetActive(false);
        _totalLosses.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level-1",LoadSceneMode.Single);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
