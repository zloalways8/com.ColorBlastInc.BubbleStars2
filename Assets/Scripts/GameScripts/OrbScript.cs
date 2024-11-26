using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour
{

    public Sprite OrbSprite;
    public Vector2 position;
    public float length;
    public void Activate()
    {
        position = transform.position;
        OrbSprite =GameObject.Find("GameCanvas").GetComponent<GameManager>().GetRandomSprite();
        GetComponent<SpriteRenderer>().sprite = OrbSprite;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

}
