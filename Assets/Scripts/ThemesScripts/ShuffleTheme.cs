using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleTheme : MonoBehaviour
{

    public int ThemeViewed = 0;
    public void OnClickRight()
    {
        ThemeViewed = GameObject.Find("BackgroundPickStar").GetComponent<ShowcaseTheme>().themeViewed;
        if (ThemeViewed > 1)
            ThemeViewed = 0;
        else ThemeViewed++;
        GameObject.Find("BackgroundPickStar").GetComponent<ShowcaseTheme>().SwapShocase(ThemeViewed);
        GameObject.Find("PickButtonStar").GetComponent<PickScript>().CheckBought();

    }

    public void OnClickLeft()
    {
        ThemeViewed = GameObject.Find("BackgroundPickStar").GetComponent<ShowcaseTheme>().themeViewed;
        if (ThemeViewed < 1)
            ThemeViewed = 2;
        else ThemeViewed--;
        GameObject.Find("BackgroundPickStar").GetComponent<ShowcaseTheme>().SwapShocase(ThemeViewed);
        GameObject.Find("PickButtonStar").GetComponent<PickScript>().CheckBought();
    }


}
