using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField]
    private CameraNavigator cameraController;

    [SerializeField]
    private GameObject bottomTable;

    // History of moved GameObjects for undo button
    private Queue<GameObject> mostRecentlyMoved = new Queue<GameObject>();

    private IDictionary<GameObject, bool> beakerStatus = new Dictionary<GameObject, bool>();

    public void RegisterBeaker(GameObject beaker, bool onWorkspace)
    {
        if (beakerStatus.ContainsKey(beaker))
        {
            beakerStatus[beaker] = onWorkspace;
        }
        else
        {
            beakerStatus.Add(beaker, onWorkspace);
        }

        if (onWorkspace)
            mostRecentlyMoved.Enqueue(beaker);

        if (CheckIfTwoBeakersDrawn())
        {
            StartCoroutine(cameraController.MoveToObject(beaker));
            //cameraController.MoveToObject(beaker);
        }
    }

    private bool CheckIfTwoBeakersDrawn()
    {
        int numDrawnDown = 0;
        foreach (bool drawn in beakerStatus.Values)
        {
            if (drawn)
                numDrawnDown++;
        }

        return numDrawnDown >= 2;
    }

    public void UndoAction()
    {
        if (mostRecentlyMoved.Count > 0)
        {
            // Place object back on top shelf
            mostRecentlyMoved.Dequeue().GetComponent<BeakerScript>().ResetPosition();

            // Zoom out camera
            StartCoroutine(cameraController.ReturnToOriginalPosition());
        }
    }
}
