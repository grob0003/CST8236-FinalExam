using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject objectToShoot;
    public Vector2 maxAngles;
    public GameObject anchor;
    public float cameraSpeed;
    public float maxCamLeft;
    public float maxCamRight;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = Input.mousePosition;

        Camera thisCamera = GetComponent<Camera>();

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenCenter = screenSize / 2.0f;

        Vector2 difference = mousePosition - screenCenter;
        Vector2 deltaPercentage = new Vector2(difference.x / screenCenter.x, difference.y / screenCenter.y);

        Vector2 newAngle = new Vector2(deltaPercentage.x * maxAngles.x, deltaPercentage.y * maxAngles.y);

        transform.localRotation = Quaternion.Euler(newAngle.y, newAngle.x, 0.0f);

        if (Input.GetKey(KeyCode.D))
        {
            print(anchor.transform.position);
            if (transform.position.x < maxCamRight) 
            transform.RotateAround(anchor.transform.position, Vector3.down, cameraSpeed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.x > maxCamLeft) 
            transform.RotateAround(anchor.transform.position, Vector3.up, cameraSpeed);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newObject = (GameObject)GameObject.Instantiate(objectToShoot, transform.position, Quaternion.identity);

            Rigidbody bulletRB = newObject.GetComponent<Rigidbody>();

            bulletRB.AddForce(transform.forward * 15.0f, ForceMode.Impulse);

        }
       

    }
}

