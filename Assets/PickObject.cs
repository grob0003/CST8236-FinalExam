using UnityEngine;
using System.Collections;

// Tells Unity that whatever object has this script must ALSO have a camera.
[RequireComponent(typeof(Camera))]
public class PickObject : MonoBehaviour
{
    // Store the camera on this object.
    Camera _currentCamera;

    // Sound effect to be played when we click.
    AudioSource _currentSource;

    Ray _lastRayCast;
    float _raycastDistance = 1.0f;

    // Use this for initialization
    void Start()
    {
        // Get the Camera and AudioSource components on the current GameObject.
        _currentCamera = GetComponent<Camera>();
        _currentSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(_lastRayCast.origin, _lastRayCast.direction * _raycastDistance, Color.red);

        // Select an object based on mouse click.
        // button 0 is the left mouse button.
        if (Input.GetMouseButtonDown(0) == true)
        {
            // Create a ray that represents the 3D equivalent of our 2D position in the window frame.
            Ray clickRay = _currentCamera.ScreenPointToRay(Input.mousePosition);
            _lastRayCast = clickRay;

            // Play the selected sound effect.
            _currentSource.Play();

            // This stores what we have hit with our raycast.
            RaycastHit hit;

            // Cast the click ray into the world and see what is hit.
            bool didHit = Physics.Raycast(clickRay, out hit);
            if (didHit)
            {
                Debug.Log("Hey! We hit something!");

                // Grab the GameObject we hit, and store it for later.
                GameObject objectWeHit = hit.transform.gameObject;

                // Check to see if the object we've hit has an AudioSource..
                AudioSource objectWeHitAudio = objectWeHit.GetComponent<AudioSource>();
                if (objectWeHitAudio != null)
                {
                    // If so, play it!
                    objectWeHitAudio.Play();
                }

                // Store the distance of the last raycast.
                _raycastDistance = hit.distance;

                // Apply a force where the ray hit the object.
                if (hit.rigidbody != null)
                {
                    // If the object isn't using gravity, tell it to.
                    hit.rigidbody.useGravity = true;

                    // Spawn an explosion where the ray hit the object.
                    hit.rigidbody.AddExplosionForce(5000.0f, hit.point, 10.25f);
                }

            }
        }
    }
}
