using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyHolderStar : MonoBehaviour
{
    public Sprite EasyOnStar;
    public Sprite EasyOffStar;
    public Sprite MidOnStar;
    public Sprite MidOffStar;
    public Sprite HardOnStar;
    public Sprite HardOffStar;

    public Button easyButtonStar;
    public Button midButtonStar;
    public Button hardButtonStar;



    public void ChangeActiveButton(int activeStar)
    {
        if(activeStar == 0)
        {
            easyButtonStar.GetComponent<Image>().sprite = EasyOnStar;
            midButtonStar.GetComponent<Image>().sprite = MidOffStar;
            hardButtonStar.GetComponent<Image>().sprite = HardOffStar;
        }

        if (activeStar == 1)
        {
            easyButtonStar.GetComponent<Image>().sprite = EasyOffStar;
            midButtonStar.GetComponent<Image>().sprite = MidOnStar;
            hardButtonStar.GetComponent<Image>().sprite = HardOffStar;
        }

        if (activeStar == 2)
        {
            easyButtonStar.GetComponent<Image>().sprite = EasyOffStar;
            midButtonStar.GetComponent<Image>().sprite = MidOffStar;
            hardButtonStar.GetComponent<Image>().sprite = HardOnStar;
        }

        GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().diffStar = activeStar;
    }


}
