using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderStar : MonoBehaviour
{
    public Canvas menuCanvasStar;
    public Canvas bonusCanvasStar;
    public Canvas infoCanvasStar;
    public Canvas settingsCanvasStar;
    public Canvas levelChoiceCanvasStar;


    private int CounterStar(string numberStar = "4")
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
        catch { return 12; }
    }


    public bool activeStar = true;



    public Stack<string> currentStackStar;

    void Start()
    {
        CounterStar("1");
        menuCanvasStar.enabled = true;
        infoCanvasStar.enabled = false;
        settingsCanvasStar.enabled = false;
        levelChoiceCanvasStar.enabled = false;
        bonusCanvasStar.enabled = false;
        currentStackStar = new Stack<string>();
        currentStackStar.Push("menuStar");
    }




    public void MoveBackStar()
    {
        currentStackStar.Pop();
         CounterStar();
        MoveStar(currentStackStar.Peek(), true);
    }
    public void MoveStar(string destinationStar, bool backmoveStar = false, int difStar =1)
    {



        infoCanvasStar.enabled = false;
        menuCanvasStar.enabled = false;
        
        bonusCanvasStar.enabled = false;

        settingsCanvasStar.enabled = false;

        levelChoiceCanvasStar.enabled = false;
        if (!backmoveStar) {
            if (destinationStar == "menuStar") currentStackStar.Clear();
                currentStackStar.Push(destinationStar);
            
        }
      
        CounterStar();

        if (destinationStar == "menuStar")
        {
            menuCanvasStar.enabled = true;
            activeStar = false;
        }
        else if (destinationStar == "bonusStar")
        {
            bonusCanvasStar.enabled = true;
        }
        else if (destinationStar == "infoStar")
        {
            infoCanvasStar.enabled = true;
        }
        else if (destinationStar == "levelsStar")
        {
            levelChoiceCanvasStar.enabled = true;
        }
        else if (destinationStar == "settingsStar")
        {
            settingsCanvasStar.enabled = true;
        }





    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackStar.Count >= 0)
                    {
                         CounterStar();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackStar();
                    }

                }
            }
            catch (Exception eStar)
            {

            }
        }
    }


}
