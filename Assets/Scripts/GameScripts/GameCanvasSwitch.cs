using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasSwitch : MonoBehaviour
{
    public Canvas gameCanvas;
    public Canvas settingsCanvas;
    public Canvas winCanvas;
    public Canvas loseCanvas;
    public Text timeWinText;

    bool gameIsOn = true;

    void Start()
    {
        settingsCanvas.enabled = false;
        winCanvas.enabled = false; 
        loseCanvas.enabled = false;
    }

    public void SwitchCanvas()
    {
        GameObject.Find("MainCameraStar").GetComponent<SoundsManagerStar>().PlayClickStar();
        gameIsOn = !gameIsOn;
        if( gameIsOn)
        {
            
            Screen.orientation = ScreenOrientation.Landscape;
            settingsCanvas.enabled = false;
            gameCanvas.enabled = true;
            gameCanvas.GetComponent<GameManager>().ShowOrbs();

        }
        else
        {
            gameCanvas.GetComponent<GameManager>().HideOrbs();
            Screen.orientation = ScreenOrientation.Portrait;
            settingsCanvas.enabled = true;
            gameCanvas.enabled = false;
        }
    }

    public void LoseCanvas()
    {
        gameCanvas.GetComponent<GameManager>().HideOrbs();
        Screen.orientation = ScreenOrientation.Portrait;
        loseCanvas.enabled = true;
        gameCanvas.enabled = false;
    }

    public void WinCanvas()
    {
        gameCanvas.GetComponent<GameManager>().HideOrbs();
        Screen.orientation = ScreenOrientation.Portrait;
        winCanvas.enabled = true;
        GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar += 100;
        PlayerPrefs.SetInt("coinsArcade", GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar);
        var timeStar = (int)gameCanvas.GetComponent<TimerScriptStar>().TimeLeftStar;
        gameCanvas.GetComponent<TimerScriptStar>().TimerOnStar = false;
        timeWinText.text = timeStar.ToString();
        gameCanvas.enabled = false;
    }

}
