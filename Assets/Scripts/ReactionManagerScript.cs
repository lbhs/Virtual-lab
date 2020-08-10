using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReactionState {inital, choseReactants, reactionStarting, videoPlaying};

public class ReactionManagerScript : MonoBehaviour
{
    public ReactionState reactionState;
    public static Transform LiquidObject;
    public static Transform MetalObject;
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
        if (reactionState == ReactionState.inital && LiquidObject != null && MetalObject != null)
        {
            reactionState = ReactionState.choseReactants;
        }

        if (reactionState == ReactionState.choseReactants)
        {
            //LiquidObject.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        }
        else if (reactionState == ReactionState.reactionStarting)
        {

        }
        else if (reactionState == ReactionState.videoPlaying)
        {

        }
    }
}
