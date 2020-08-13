using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    private Transform targetObject;  

    public void MoveAndZoomToGameObject(Transform obj)
    {
        targetObject = obj;
    }

    private void Update()
    {
        if(targetObject != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetObject.position + new Vector3(0,3f,-8), 3 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetObject.transform.position - transform.position), 3 * Time.deltaTime);
        }
    }
}
