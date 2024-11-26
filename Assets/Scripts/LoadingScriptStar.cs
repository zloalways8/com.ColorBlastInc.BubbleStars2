using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScriptStar : MonoBehaviour
{
    Timer tStar;

    void Start()
    {
        HideTimerStar();
    }

    public void EndLoadStar()
    {
        SceneManager.LoadScene("MenuSceneStar");
    }




    public void HideTimerStar()
    {

        tStar = new Timer(1500);
        tStar.AutoReset = false;

        tStar.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tStar.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {

        try
        {
            EndLoadStar();
        }
        finally
        {
            tStar.Enabled = false;
        }
    }

}
