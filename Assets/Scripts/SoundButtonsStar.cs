using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonsStar : MonoBehaviour
{

    public bool isOnStar = true;
    public int isMusicStar = 0;
    public Button buttonStar;
    public Sprite stateOnStar;
    public Sprite stateOffStar;

    void Start()
    {
        if(isMusicStar == 1)
        {
           isOnStar = GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().musicIsOnStar;
        }
        else isOnStar = GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().soundIsOnStar;

        if (isOnStar)
            buttonStar.GetComponent<Image>().sprite = stateOnStar;

        else
            buttonStar.GetComponent<Image>().sprite = stateOffStar;


    }
    public void ChangeState(int musicStar)
    {
        isOnStar=!isOnStar;

        if (isOnStar)
            buttonStar.GetComponent<Image>().sprite = stateOnStar;
 
        else 
            buttonStar.GetComponent<Image>().sprite = stateOffStar;


        if (musicStar == 1)
            GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().ChangeMusicSoundStar();
        else GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().soundIsOnStar = isOnStar;

    }


}
