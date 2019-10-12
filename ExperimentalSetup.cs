using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment : MonoBehaviour
{


    public GameObject cube;
    public GameObject fixationPlane1;
    public GameObject fixationPlane2;
    public TextMesh textComponent;
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        makeFixationCross();
        hideFixationCross();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            StartCoroutine(procedure());
        }

        if (active && Input.GetKeyDown("1") || Input.GetKeyDown("2"))
        {
            active = false;
            StartCoroutine(procedure());
        }

    }


    void makeCube()
    {
        //Generate a cube of random height within specified range
        var range = Random.Range(-0.5f, 0.5f);

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 1f, 0);
        cube.transform.localScale += new Vector3(0, range, 0);

        var cubeRenderer = cube.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.red);
    }


    void hideCube()
    {
        cube.SetActive(false);
    }

    void showCube()
    {
        cube.SetActive(true);
    }


    void makeFixationCross()
    {
        fixationPlane1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fixationPlane1.transform.position = new Vector3(0, 1, 0);
        fixationPlane1.transform.localScale = new Vector3(0.05f, 0.9f, 0.05f);
        var planeRenderer = fixationPlane1.GetComponent<Renderer>();
        planeRenderer.material.SetColor("_Color", Color.white);


        fixationPlane2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fixationPlane2.transform.position = new Vector3(0, 1, 0);
        fixationPlane2.transform.localScale = new Vector3(0.9f, 0.05f, 0.05f);
        var plane2Renderer = fixationPlane2.GetComponent<Renderer>();
        plane2Renderer.material.SetColor("_Color", Color.white);
    }

    void hideFixationCross()
    {
        fixationPlane1.SetActive(false);
        fixationPlane2.SetActive(false);
    }

    void showFixationCross()
    {
        fixationPlane1.SetActive(true);
        fixationPlane2.SetActive(true);
    }




    IEnumerator procedure()
    {
        showFixationCross();
        yield return new WaitForSeconds(1);
        hideFixationCross();
        makeCube();
        yield return new WaitForSeconds(1);
        hideCube();
        showFixationCross();
        yield return new WaitForSeconds(1);
        hideFixationCross();
        makeCube();
        yield return new WaitForSeconds(1);
        hideCube();
        active = true;
    }
