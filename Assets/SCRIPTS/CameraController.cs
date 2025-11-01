using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 lastPos;
    private float distance;

    [Header("Camera Bounds")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // distance = player.transform.position.x - lastPos.x;
        // transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        // lastPos = player.transform.position;

        // Calculate how far the player has moved since last frame
        Vector3 distance = player.transform.position - lastPos;

        // Apply that movement to this object
        // transform.position += new Vector3(distance.x, distance.y, 0);

        // Move camera horizontally according to player's X movement
        transform.position += new Vector3(distance.x, 0, 0);

        // Make the camera's Y position match the player's Y (keeps player centered vertically)
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

    
     // Clamp camera position within defined boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    // Update the last position for next frame
    lastPos = player.transform.position;    
    }
}
