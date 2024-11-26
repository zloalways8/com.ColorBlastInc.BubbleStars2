using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeController : MonoBehaviour
{

    public Sprite theme1;
    public Sprite theme2;
    public Sprite theme3;

    void Update()
    {
      int theme =   GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().CurrentTheme;

        if(theme == 0) GetComponent<Image>().sprite = theme1;
        else if (theme == 1) GetComponent<Image>().sprite = theme2;
        else if (theme == 2) GetComponent<Image>().sprite = theme3;
    }
}
