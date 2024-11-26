using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinKeeperStar : MonoBehaviour
{
    public Text pointsTextStar;


    public void OnClickStar()
    {
        if (GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar >= 100)
        {
            GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar -= 100;
            PlayerPrefs.SetInt("coinsArcade", GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar);
            var newTimerStar = GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().TimerModStar;
            newTimerStar += 0.5f;
            GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().TimerModStar = newTimerStar;
            PlayerPrefs.SetFloat("timerArcade", newTimerStar);
        }
    }
    void Update()
    {
        pointsTextStar.text = "Points:"+ GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar;
    }
}
