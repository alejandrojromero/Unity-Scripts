//Uses raycasting to generate a path for a player object 
// through a navMesh given any 3 points on the ground plane that the user 
// clicks on.

using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    Material[] matArray;
    public Material highlight;
    public Material seeThru;
    GameObject WayPoint;
    private int i = 0;
    public GameObject markers;
    GameObject[] wayPoints = new GameObject[3];
    private bool highlighted = false;
    LineRenderer lineRenderer;

    private void Start()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = markers.transform.GetChild(i).gameObject;
            wayPoints[i].SetActive(false);
        }
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        matArray = agent.GetComponent<MeshRenderer>().materials;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Vector3[] points = new Vector3[3];

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "Ground")
            {
                if (wayPoints[1].activeSelf && wayPoints[1].activeSelf && !wayPoints[2].activeSelf)
                {
                    wayPoints[2].transform.position = hit.point;
                    wayPoints[2].SetActive(true);
                    points[2] = hit.point;
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, wayPoints[2].transform.position);
                }

                if (wayPoints[0].activeSelf && !wayPoints[1].activeSelf && !wayPoints[2].activeSelf)
                {
                    wayPoints[1].transform.position = hit.point;
                    wayPoints[1].SetActive(true);
                    points[1] = hit.point;
                }

                if (!wayPoints[0].activeSelf && !wayPoints[1].activeSelf && !wayPoints[2].activeSelf && highlighted)
                {
                    wayPoints[0].transform.position = hit.point;
                    wayPoints[0].SetActive(true);

                }

                nextTarget();

            }

            if (hit.collider.gameObject.name == name)
            {
                Debug.Log("HI");
                toggleHighlight();
            }

            agent.GetComponent<MeshRenderer>().materials = matArray;
        }


        for (int j = 0; j < wayPoints.Length; j++)
        {
            if (Vector3.Distance(wayPoints[j].transform.position, transform.position) < 0.45f)
            {
                wayPoints[j].SetActive(false);
               // Debug.Log(j);
                if (j < 2)
                {
                    WayPoint = wayPoints[j + 1];
                    agent.SetDestination(WayPoint.transform.position);
                    highlighted = false;
                    matArray[1] = seeThru;
                    agent.GetComponent<MeshRenderer>().materials = matArray;
                }
            }

        }

        if (wayPoints[0].activeSelf)
        {
            drawLine(0);
        }
        else if (wayPoints[1].activeSelf)
        {
            drawLine(1);
        }
        else if (wayPoints[2].activeSelf)
        {
            drawLine(2);
        }
        else
        {
            lineRenderer.SetPosition(0, new Vector3(-2,-2,-2));
            lineRenderer.SetPosition(1, new Vector3(-2, -2, -2));
        }


    }

    public void nextTarget()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = markers.transform.GetChild(i).gameObject;
        }
        if (wayPoints[0].activeSelf && wayPoints[2].activeSelf)
        {
            agent.SetDestination(wayPoints[0].transform.position);
        }

    }

    public void drawLine(int x)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, wayPoints[x].transform.position);
    }

    public void toggleHighlight()
    {
        highlighted = !highlighted;

        if (highlighted)
        {
            matArray[1] = highlight;
            agent.GetComponent<MeshRenderer>().materials = matArray;
        }
        else
        {
            matArray[1] = seeThru;
            agent.GetComponent<MeshRenderer>().materials = matArray;
        }
    }
}
