using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowcaseTheme : MonoBehaviour
{
    public int themeViewed = 0;
    public Sprite theme0;
    public Sprite theme1;
    public Sprite theme2;
   

    public void SwapShocase(int theme)
    {
        themeViewed = theme;
        if (themeViewed == 1) GetComponent<Image>().sprite=theme1;
        else if (themeViewed == 2) GetComponent<Image>().sprite = theme2; 
        else GetComponent<Image>().sprite = theme0; 

    }
}
