using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public Button playButton;
    public Button backButton;

    public Button[] stages;

    private GameObject _panelMenu;
    private GameObject _panelStages;

    // Start is called before the first frame update
    void Start()
    {
        FullGameInformation.AddKey(GeneralInfo.SPEED, "40");
        _panelMenu = GameObject.Find("PanelMenu");
        _panelStages= GameObject.Find("PanelStages");
        _panelStages.SetActive(false);
        playButton.onClick.AddListener(OnPlayClick);
        backButton.onClick.AddListener(ShowMainMenu);
        foreach (var btn in stages) { btn.onClick.AddListener(OnStageClick);}
    }

    void OnPlayClick()
    {
        _panelStages.SetActive(true);

    }

    void OnStageClick()
    {
        var buttonClicked = EventSystem.current.currentSelectedGameObject;
        var stageNumber = buttonClicked.name;
        if (buttonClicked.name == "1") SceneManager.LoadScene("Level-"+stageNumber, LoadSceneMode.Single);
        else SceneManager.LoadScene($"Level-1", LoadSceneMode.Single);
    }

    void ShowMainMenu()
    {
        _panelStages.SetActive(false);
    }


}
