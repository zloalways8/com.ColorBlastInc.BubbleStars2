using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickScript : MonoBehaviour
{
    [SerializeField]
    private Sprite boughtSprite;

    [SerializeField]
    private Sprite notBoughtSprite;
    private bool bought=false;
    private int themeViewed = 0;

    void Start()
    {
        CheckBought();
    }

    public void CheckBought()
    {
        themeViewed = GameObject.Find("BackgroundPickStar").GetComponent<ShowcaseTheme>().themeViewed;
        if (themeViewed == 1) bought =  GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().ThemeBlackBought;
        else if (themeViewed == 2) bought =  GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().ThemeBlueBought;
        else bought = true;

        if (bought)
        {
            GetComponent<Image>().sprite = boughtSprite;
        }
        else { GetComponent<Image>().sprite = notBoughtSprite; }

    }

    public void BuyTheme()
    {
       if (bought)
        {
             GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().CurrentTheme= themeViewed;
        }
       else
        {
            if ( GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar >= 100)
            {

                 GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar -= 100;
                 GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().CurrentTheme = themeViewed;
                if (themeViewed == 1)
                {
                     GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().ThemeBlackBought = true;
                    PlayerPrefs.SetInt("blackArcade",1);
                }
                else if (themeViewed == 2)
                {
                     GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().ThemeBlueBought = true;
                    PlayerPrefs.SetInt("blueArcade", 1);
                }

                PlayerPrefs.SetInt("coinsArcade",  GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().coinsStar);
                 GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().CurrentTheme = themeViewed;
                GetComponent<Image>().sprite = boughtSprite;
            }             
        }
      
    }


}
