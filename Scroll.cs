
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D body;
    void Start()
    {
        //Set the object with this script to scroll at the predefined speed
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    }

    void Update()
    {
        if (GameController.instance.gameOver == true)
        {
            //Stop scroll on game over
            body.velocity = Vector2.zero;
        }
    }
}