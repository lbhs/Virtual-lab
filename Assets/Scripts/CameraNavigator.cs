using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigator : MonoBehaviour
{
    // Responsiveness of arrow keys
    public float speed;
    // Responsiveness of mouse scroll
    public float scrollSpeed;
    private bool manualControlEnabled;
    // Will be used to reset camera position after undo operation
    private Vector3 startPosition;
    private Quaternion startDirection;

    private void Start()
    {
        manualControlEnabled = true;
        // Used to undo an operation
        startPosition = transform.position;
        startDirection = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && manualControlEnabled)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
            }
            else
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0), Space.World);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6.5f),
                                             transform.position.y,
                                             transform.position.z);
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && manualControlEnabled)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.World);
            }
            else
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0), Space.World);
            }

            transform.position = new Vector3(transform.position.x,
                                             Mathf.Clamp(transform.position.y, 4f, 12.5f),
                                             transform.position.z);
        }

        // Zoom camera
        if ((Input.GetAxis("Mouse ScrollWheel") != 0) && manualControlEnabled)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime), Space.World);
        }
    }

    // Used for zooming into the flasks when they are placed on the table
    public IEnumerator MoveToObject(GameObject target)
    {
        manualControlEnabled = false;

        // 4 units up, 4 units behind the object
        Vector3 offset = new Vector3(0, 4, -4);

        Vector3 correctTargetPosition = target.transform.position + offset;

        transform.LookAt(target.transform);

        while (transform.position != correctTargetPosition)
        {
            // Adjust third argument to change camera speed
            transform.position = Vector3.MoveTowards(transform.position, correctTargetPosition, .05f);
            yield return new WaitForEndOfFrame();
        }

        manualControlEnabled = true;
    }

    public IEnumerator ReturnToOriginalPosition()
    {
        manualControlEnabled = false;

        while (transform.position != startPosition)
        {
            // Adjust third argument to change camera speed
            transform.position = Vector3.MoveTowards(transform.position, startPosition, .05f);
            yield return new WaitForEndOfFrame();
        }

        while (transform.rotation != startDirection)
        {
            // Adjust third argument to change camera speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startDirection, .05f);
            yield return new WaitForEndOfFrame();
        }

        manualControlEnabled = true;
    }
}
