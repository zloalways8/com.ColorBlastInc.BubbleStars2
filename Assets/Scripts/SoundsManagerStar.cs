using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManagerStar : MonoBehaviour
{
    public AudioSource pingStar;
    public AudioSource clickStar;
    public AudioSource winStar;

    public void PlayPingStar()
    {
        if (GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().soundIsOnStar)
            pingStar.Play();

    }

    public void PlayClickStar()
    {
        if (GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().soundIsOnStar)  
            clickStar.Play();    
    }

    public void PlayWinStar()
    {
        if (GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().soundIsOnStar)
            winStar.Play();

    }

}
