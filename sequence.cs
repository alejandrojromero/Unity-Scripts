using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class Sequence : MonoBehaviour
{
    public int numPieces;      //Number of pieces in sequence
    public int task = 1;        // Start on the first task
    public bool taskComplete = false;    //No task completed at start
    public GameObject piece1;           //Create all of the gameobjects
    public GameObject piece2;           //  |
    public GameObject piece3;           //  |
    public GameObject piece4;           //  |
    public GameObject piece5;           //  |
    public GameObject piece6;           //  |
    public GameObject piece7;           //  v
    public GameObject[] sequence;     //Create array to store pieces 
    public Material[] mats;           //Create array to store materials
    public Material highlight;        //Store the common highlight material

    // Use this for initialization
    void Start()
    {
        //Define piece array for start
        GameObject[] sequence = new GameObject[numPieces];

        for (int i = 0; i < numPieces; i++)
        {
            //Set the piece objects (find out how to generalize)
            sequence[0] = piece1;
            sequence[1] = piece2;
            sequence[2] = piece3;
            sequence[3] = piece4;
            sequence[4] = piece5;
            sequence[5] = piece6;
            sequence[6] = piece7;
            for (int j = 1; j < numPieces; j++)
            {
                //Disable colliders for all pieces other than current piece
                sequence[j].GetComponent<Collider>().enabled = false;

                //Disable the highlight material for all pieces other than current
                MeshRenderer meshRend = sequence[j].GetComponent<MeshRenderer>();
                mats = meshRend.materials;
                mats[1] = mats[0];
                Debug.Log(mats[1]);
                meshRend.materials = mats;
            }
        }
    }

    void Update()
    {
        //Set the piece objects (find out how to generalize)
        GameObject[] sequence = new GameObject[numPieces];
            sequence[0] = piece1;
            sequence[1] = piece2;
            sequence[2] = piece3;
            sequence[3] = piece4;
            sequence[4] = piece5;
            sequence[5] = piece6;
            sequence[6] = piece7;
        //WhenOpened script detects when the task is completed via collision.
        //If this bool is true:
        if (taskComplete)
        {
            //Enable the next task's collider
            sequence[task].GetComponent<Collider>().enabled = true;
            //Reset the bool
            taskComplete = false;
            //Disable the collider of the task that was just completed
            sequence[task - 1].GetComponent<Collider>().enabled = false;
            //Create a renderer to find the materials of a piece
            MeshRenderer meshRend = sequence[task].GetComponent<MeshRenderer>();
            mats = meshRend.materials;
            //Set the second material to the highlight so that the next task piece is 
            //highlighted
            mats[1] = highlight;
            meshRend.materials = mats;

            //Same as above, but eliminating the highlight from the previous task piece
            MeshRenderer first = sequence[task - 1].GetComponent<MeshRenderer>();
            mats = first.materials;
            mats[1] = mats[0];
            first.materials = mats;
            //Increment the task number to move on and repeat
            task++;
        }
    }
}
