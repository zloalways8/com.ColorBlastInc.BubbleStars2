using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBallSpawner : MonoBehaviour
{

    public GameObject Ball;
    public void BallSpawn(int x=0, int y=0)
    {
        Vector3 pos = new Vector3(0+(Ball.GetComponent<SpriteRenderer>().bounds.size.x * x), transform.position.y + (Ball.GetComponent<SpriteRenderer>().bounds.size.x * y), 1);
        GameObject refr =Instantiate(Ball, pos, Quaternion.identity);
        refr.GetComponent<OrbScript>().Activate();
       // GameObject.Find("GameCanvas").GetComponent<GameScript>().orbsInField.Add(refr);
        if (y < 8)
        {
            BallSpawn(x,y + 1);
        }
    }

    void Start()
    {

        for (int i = 0; i < 13; i++)
        {
            BallSpawn(i,0);
        }

         
    }

}
