using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 0;
    //Elapsed time since pipes were created
    private float timeSinceLastSpawned;
    //How often pipes should be created
    public float spawnRate = 3f;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
       
         //Scroll velocity of pipes
        velocity = new Vector2(-1.75f, 0f);

        //Scroll the pipes according to the game delta time
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + velocity * Time.fixedDeltaTime);

        //Time since the pipes were created increases at a rate slow enough for the pipes to
        //scroll across the screen before being repositioned
        timeSinceLastSpawned += Time.deltaTime / 6;
        //If the game is NOT over and the time since the pipe was created is greater than the 
        //desired rate of creation:
        if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            //Reset timer
            timeSinceLastSpawned = 0f;
            //Store position
            Vector3 position = this.transform.position;
            //Shift the pipes over by a specified distance
            position.x += 16;
            this.transform.position = position;

        }
        }

    }
