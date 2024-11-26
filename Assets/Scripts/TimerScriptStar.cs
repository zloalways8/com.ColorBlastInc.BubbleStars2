using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptStar : MonoBehaviour
{
    public float TimeLeftStar = 100;
    public bool TimerOnStar = false;
    public Slider sliderStar;
    public Text TimerTextStar;



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


    void Update()
    {
        if (TimerOnStar)
        {
            if (TimeLeftStar > 1)
            {
                
                TimeLeftStar -= Time.deltaTime;
                UpdateTimerStar(TimeLeftStar);
            }
            else
            {
                TimerOnStar = false;
               GameObject.Find("MainCameraStar").GetComponent<GameCanvasSwitch>().LoseCanvas();
            }
        }
    }

    public void RefreshTimerStar()
    {    
        TimeLeftStar = 100 * GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().TimerModStar;
            TimerOnStar = true;
            CounterStar();
        sliderStar.maxValue =TimeLeftStar;
        sliderStar.value = TimeLeftStar;
    }
    void UpdateTimerStar(float currentTimeStar)
    {
        currentTimeStar -= 1;
        CounterStar();
        sliderStar.value = (int)currentTimeStar;
        TimerTextStar.text = "Time: " + (int)currentTimeStar + " sec";
    }
}
