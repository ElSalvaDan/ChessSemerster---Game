using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 100f;
    public float panBorder = 5f;

    public Vector2 panLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            position.y += panSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder)
        {
            position.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            position.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder)
        {
            position.x -= panSpeed * Time.deltaTime;
        }

        // Need to add zoom in zoom out feature soon
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        position.x = Mathf.Clamp(position.x, -panLimit.x, panLimit.x);
        position.y = Mathf.Clamp(position.y, -panLimit.y, panLimit.y);

        transform.position = position;
    }
}
