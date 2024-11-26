using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSwitchStar : MonoBehaviour
{
 
    public void OnClick()
    {
        GameObject.Find("MainCameraStar").GetComponent<GameCanvasSwitch>().SwitchCanvas();
    }


}
