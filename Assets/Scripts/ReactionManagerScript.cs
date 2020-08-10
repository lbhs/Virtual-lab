using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReactionState {inital, choseReactants, reactionStarting, videoPlaying};

public class ReactionManagerScript : MonoBehaviour
{
    public ReactionState reactionState;
    public static Transform LiquidObject;
    public ScaleScript scale;
    public GameObject LiquidCanvas;
    //public float rotateSpeed=90;

    // Start is called before the first frame update
    void Start()
    {
        reactionState = ReactionState.inital;
    }

    // Update is called once per frame
    void Update()
    {
        //print(LiquidObject);
        if (reactionState == ReactionState.inital && LiquidObject != null && scale.listOfObjectsOnHere.Count > 0)
        {
            reactionState = ReactionState.choseReactants;
        }
        else if(reactionState == ReactionState.choseReactants && scale.listOfObjectsOnHere.Count == 0 || LiquidObject == null)
        {
            reactionState = ReactionState.inital;
        }

        if (reactionState == ReactionState.choseReactants)
        {
            //LiquidObject.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
            LiquidCanvas.SetActive(true);
        }
        else
        {
            LiquidCanvas.SetActive(false);
        }

        if (reactionState == ReactionState.reactionStarting)
        {

        }
        else if (reactionState == ReactionState.videoPlaying)
        {

        }
    }
}
