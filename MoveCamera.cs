//Attach script to camera object for panning controls


    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     


    public GameObject player;
    Vector3 offset;

    private void Start()
    {
         offset = transform.position - player.transform.position;
    }
    
     void Update()
    {

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }
        
        if (!Input.GetMouseButton(1)) isPanning = false;
        
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }
