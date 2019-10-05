using UnityEngine;
using System.Collections;

public class Loop : MonoBehaviour
{
    private BoxCollider2D collider;      
    private float horizontalLength;      
    private void Awake()
    {
        //Set collider of object
        collider = GetComponent<BoxCollider2D>();
        //Use collider length to determine loop timing
        horizontalLength = collider.size.x;
    }

    //Shift the background at correct time
    private void RepositionBackground()
    {
        //Transform the object to the offset position, which is 2 lengths away
        //2 lengths away because we always use 2 backgrounds 
        Vector2 offset = new Vector2(horizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }

    //Update per frame. Shift if condition is met
    private void Update()
    {
        if (transform.position.x < -horizontalLength)
        {
            //When the entire object has scrolled past the screen by its 
            //length, reposition it
            RepositionBackground();
        }
    }
}
