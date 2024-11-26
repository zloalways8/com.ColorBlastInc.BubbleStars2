using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public System.Random r = new System.Random();
    public Sprite OrbSprite1;
    public Sprite OrbSprite2;
    public Sprite OrbSprite3;
    public Sprite OrbSprite4;

    public List<GameObject> orbsInField = new List<GameObject>();


    public GameObject leftOrbPrefab; 
    public GameObject startObjectLeft;
    public Vector3 startPositionLeft;
    int scoreStar = 0;
    int goalStar = 50;

    public GameObject BallRight;
    public GameObject startObjectRight;

    public Slider ScoreSlider;
    GameObject CurrentLeft;

    bool once = false;
    private OrbMovement leftOrbMovement; 




    void Start()
    {
        if (GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().diffStar == 1)
            goalStar = 100;
        else if (GameObject.Find("StatesHolderStar").GetComponent<StatesStar>().diffStar == 2)
            goalStar = 150;
        else goalStar = 50;
        ScoreSlider.maxValue = goalStar;
        StartCoroutine(WaitForOrientationChange());
    }

    IEnumerator WaitForOrientationChange()
    {
        yield return new WaitForSeconds(0.1f);

        while ((Screen.orientation != ScreenOrientation.Landscape))
        {
            yield return new WaitForEndOfFrame();
        }
        Launch();
    }

    private void Launch()
    {
        Camera mainCamera = Camera.main;

        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float middleY = screenHeight / 2f;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(0, middleY, mainCamera.nearClipPlane));

        startPositionLeft = worldPosition;
        //startPositionLeft = startObjectLeft.transform.position;

        Init();
    }
    public void Init()
    {
        for (int i = 0; i < 13; i++)
        {
            BallSpawn(i, 0);
        }
        SpawnLeftOrb();
        GetComponent<TimerScriptStar>().RefreshTimerStar();
    }

    public void BallSpawn(int x = 0, int y = 0)
    {
        Vector3 pos = new Vector3(0 + (BallRight.GetComponent<SpriteRenderer>().bounds.size.x * x), startObjectRight.transform.position.y + (BallRight.GetComponent<SpriteRenderer>().bounds.size.x * y), 1);
        GameObject refr = Instantiate(BallRight, pos, Quaternion.identity);
        refr.GetComponent<OrbScript>().Activate();
        refr.GetComponent<OrbSelection>().active = true;
        orbsInField.Add(refr);
        if (y < 8)
        {
            BallSpawn(x, y + 1);
        }
    }

        void SpawnLeftOrb()
    {
        Vector3 pos = new Vector3(startPositionLeft.x+2f,startPositionLeft.y,startPositionLeft.z);
        GameObject leftOrb = Instantiate(leftOrbPrefab, pos, Quaternion.identity);
        leftOrb.GetComponent<OrbScript>().Activate();
        leftOrbMovement = leftOrb.GetComponent<OrbMovement>();
        CurrentLeft =leftOrb;
        orbsInField.Add(leftOrb);
    }

    public void HideOrbs()
    {
        foreach (var orb in orbsInField)
        {
            orb.SetActive(false);
        }
    }

    public void ShowOrbs()
    {
        foreach (var orb in orbsInField)
        {
            orb.SetActive(true);
        }
    }

    public OrbMovement GetLeftOrbMovement()
    {
        return leftOrbMovement;
    }

   
    public void CheckForLines()
    {
        List<GameObject> orbsToDestroy = new List<GameObject>(); 

        
        CheckHorizontalLines(orbsToDestroy);
        CheckVerticalLines(orbsToDestroy);

        
        if (orbsToDestroy.Count >= 3)
        {
            foreach (var orb in orbsToDestroy)
            {
                scoreStar++;
                ScoreSlider.value = scoreStar;
                Destroy(orb);
                orbsInField.Remove(orb);
                if (scoreStar >= goalStar)
                {
                    GameObject.Find("MainCameraStar").GetComponent<GameCanvasSwitch>().WinCanvas();
                }
            }
            GameObject.Find("MainCameraStar").GetComponent<SoundsManagerStar>().PlayWinStar();
        }

            
            SpawnLeftOrb();
        
    }

   
    private void CheckHorizontalLines(List<GameObject> orbsToDestroy)
    {
        for (int i = 0; i < orbsInField.Count; i++)
        {
            GameObject currentOrb = orbsInField[i];
            Vector3 currentPosition = currentOrb.transform.position;
            Sprite currentSprite = currentOrb.GetComponent<OrbScript>().OrbSprite;

            List<GameObject> matchedOrbs = new List<GameObject> { currentOrb };

         
            for (int j = 1; j < 8; j++) 
            {
                GameObject rightOrb = FindOrbAtPosition(new Vector3(currentPosition.x + currentOrb.GetComponent<OrbScript>().length*j, currentPosition.y, currentPosition.z));
                if (rightOrb != null && rightOrb.GetComponent<OrbScript>().OrbSprite == currentSprite)
                {
                    matchedOrbs.Add(rightOrb);
                }
                else
                {
                    break; 
                }
            }

            if (matchedOrbs.Count >= 3&&matchedOrbs.Contains(CurrentLeft))
            {
                orbsToDestroy.AddRange(matchedOrbs); 
            }
        }
    }

    private void CheckVerticalLines(List<GameObject> orbsToDestroy)
    {
        for (int i = 0; i < orbsInField.Count; i++)
        {
            GameObject currentOrb = orbsInField[i];
            Vector3 currentPosition = currentOrb.transform.position;
            Sprite currentSprite = currentOrb.GetComponent<OrbScript>().OrbSprite;

            List<GameObject> matchedOrbs = new List<GameObject> { currentOrb };

          
            for (int j = 1; j < 8; j++) 
            {
                GameObject downOrb = FindOrbAtPosition(new Vector3(currentPosition.x, currentPosition.y - currentOrb.GetComponent<OrbScript>().length*j, currentPosition.z));
                if (downOrb != null && downOrb.GetComponent<OrbScript>().OrbSprite == currentSprite)
                {
                    matchedOrbs.Add(downOrb);
                }
                else
                {
                    break; 
                }
            }

            if (matchedOrbs.Count >= 3 && matchedOrbs.Contains(CurrentLeft))
            {
               
                orbsToDestroy.AddRange(matchedOrbs); 
            }
        }
    }


    private GameObject FindOrbAtPosition(Vector3 position)
    {
        foreach (var orb in orbsInField)
        {
            if (Vector3.Distance(orb.transform.position, position) < 0.1f)  
            {
                return orb;
            }
        }
        return null;
    }


    public bool GetLeftmostColumnPosition(OrbScript checkOrb)
    {

        foreach (var orb in orbsInField)
        {
            if(orb.GetComponent<OrbScript>().position.y==checkOrb.position.y)
            if (orb.GetComponent<OrbScript>().position.x < checkOrb.position.x)
            {
                    return false;
            }
        }

        return true;
    }

    public Sprite GetRandomSprite()
    {
        int rInt = r.Next(0, 4);

        if (rInt == 0) return OrbSprite1;
        else if (rInt == 1) return OrbSprite2;
        else if (rInt == 2) return OrbSprite3;
        else return OrbSprite4;

    }
}
