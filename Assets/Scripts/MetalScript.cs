using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalScript : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 lastSnapPosition;
    public bool CanMove = true;
    public Material MetalMaterial;
    public Mesh MetalMesh;
    public AudioSource PlinkingMetal;
    //dictionary keeps track of available snapping positions with boolean to describe occupancy
    public static Dictionary<Vector3, bool> snapPositions = new Dictionary<Vector3, bool>(){
		
		//upper shelf snapping positions
        {new Vector3(0f, 9.5f, 8f), false},
        {new Vector3(2f, 9.5f, 8f), false},
        {new Vector3(3.7f, 9.5f, 8f), false},
		
		//lower shelf snapping positions
        {new Vector3(6f,2.7f, 7f), false},
    };

    //on start, teleport the beaker into the nearest available snapping position
    void Start()
    {
        var d = new Dictionary<Vector3, bool>();
        foreach (var item in snapPositions)
        {
            d.Add(item.Key, false);
        }
        snapPositions = d;
        snapIntoPosition();
    }

    //when user clicks on trhe beaker start the ability to drag by measuring offset and teleport towards camera off the shelf
    void OnMouseDown()
    {
        if (CanMove)
        {
            //keep track of last position so we can make it available for other beakers
            lastSnapPosition = transform.position;

            //translate mouse position into world position and manually edit z to 6.5f so that the beaker is off of the shelf while in hand
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 6.5f);
            PlinkingMetal = GameObject.Find("MetalMovementSound").GetComponent<AudioSource>();
            PlinkingMetal.Play();
        }
    }

    //as player moves the mouse around, alter the position of the beaker accordingly - don't allow any z-axis movement
    void OnMouseDrag()
    {
        if (CanMove)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
            Vector3 curPosition = new Vector3(worldPoint.x + offset.x, worldPoint.y + offset.y, gameObject.transform.position.z);
            transform.position = curPosition;
        }
    }

    //when the player lets go, snap the beaker into the nearest available snapping position
    void OnMouseUp()
    {
        if (CanMove)
        {
            snapIntoPosition();
            PlinkingMetal = GameObject.Find("MetalMovementSound").GetComponent<AudioSource>();
            PlinkingMetal.Stop();
        }
    }

    //function returns the nearest available snapping position by looking through the dictionary
    public Vector3 nearestOpenSnapPosition()
    {
        float minDistance = 100000f;
        Vector3 nearestPosition = Vector3.zero;
        foreach (KeyValuePair<Vector3, bool> position in snapPositions)
        {
            if (position.Key != Vector3.zero)
            {
                float curDistance = Vector3.Distance(gameObject.transform.position, position.Key);
                if (!position.Value && curDistance < minDistance)
                {
                    minDistance = curDistance;
                    nearestPosition = position.Key;
                }
            }
        }
        return nearestPosition;
    }

    //function uses the nearest snapping position to actually move the beaker and updates availability of positions accordingly
    public void snapIntoPosition()
    {
        snapPositions[lastSnapPosition] = false;
        transform.position = nearestOpenSnapPosition();
        snapPositions[transform.position] = true;
        if (transform.position == new Vector3(6f, 2.7f, 7f))
        {
            ReactionManagerScript.MetalObject = transform;
        }
        else if (ReactionManagerScript.MetalObject == gameObject.transform)
        {
            ReactionManagerScript.MetalObject = null;
        }
    }
}
