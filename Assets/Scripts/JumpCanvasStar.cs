using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasStar : MonoBehaviour
{

    private int CounterStar(string numberStar = "")
    {
        try
        {
            int counterStar = numberStar.Length;
            if (counterStar > 3)
            {
                return 0;
            }
            return counterStar;
        }
        catch { return 0; }
    }

    public void JumpStar(string destinationStar)
    {
        CounterStar();
        GameObject.Find("MainCameraStar").GetComponent<SoundsManagerStar>().PlayClickStar();
        GameObject.Find("MainCameraStar").GetComponent<CanvasHolderStar>().MoveStar(destinationStar,false);
    }


    public void JumpBackStar()
    {
        GameObject.Find("MainCameraStar").GetComponent<SoundsManagerStar>().PlayClickStar();
        CounterStar("81");
        GameObject.Find("MainCameraStar").GetComponent<CanvasHolderStar>().MoveBackStar();
       
    }

    public void CloseStar()
    {
        CounterStar("91");
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        CounterStar("91");
        activity.Call<bool>("moveTaskToBack", true);
    }
}
