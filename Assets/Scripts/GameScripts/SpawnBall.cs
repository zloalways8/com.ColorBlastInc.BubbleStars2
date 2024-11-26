using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject Ball;

    public void Activate(int num = 0)
    {
        Vector3 pos = new Vector3(transform.position.x - 2.6f, 0+(Ball.GetComponent<SpriteRenderer>().bounds.size.y*num), transform.position.z);
       // Instantiate(Ball, pos, Quaternion.identity);
        //if(num<4)  Activate(num+1);
     //   GameObject.Find("GameCanvas").GetComponent<GameScript>().spawnPosition = transform;
    }

  /*  void Start()
    {
      
        Activate();
    }*/



}
