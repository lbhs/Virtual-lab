using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerScript : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	public static Dictionary<Vector3, bool> snapPositions = new Dictionary<Vector3, bool>(){
		{new Vector3(-2f, 9.5f, 8f), false},
		{new Vector3(0f, 9.5f, 8f), false},
		{new Vector3(-1.5f, 2.69f, 7f), false}
	};
	
	 
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

	}
	
	void OnMouseUp()
	{
		//transform.position = nearestOpenSnapPosition();
	}
	
	public Vector3 nearestOpenSnapPosition()
	{
		float minDistance = 100000f;
		Vector3 nearestPosition = Vector3.zero;
		foreach(KeyValuePair<Vector3, bool> position in snapPositions)
		{
			float curDistance = Vector3.Distance(gameObject.transform.position, position.Key);
			if(!position.Value && curDistance < minDistance)
			{
				minDistance = curDistance;
				nearestPosition = position.Key;
			}
		}
		return nearestPosition;
	}
}
