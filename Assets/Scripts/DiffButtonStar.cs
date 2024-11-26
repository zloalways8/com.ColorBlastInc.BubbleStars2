using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffButtonStar : MonoBehaviour
{
    public int difficultyStar = 0;
    public void OnClick()
    {
        GameObject.Find("DiffTitleStar").GetComponent<DifficultyHolderStar>().ChangeActiveButton(difficultyStar);
    }


}
