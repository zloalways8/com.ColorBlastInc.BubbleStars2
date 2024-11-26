using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDiffScene : MonoBehaviour
{



    public void GoToGame()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        SceneManager.LoadScene("GameSceneStar");  
    }


    public void GoToMenu()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("MenuSceneStar");
    }

}
