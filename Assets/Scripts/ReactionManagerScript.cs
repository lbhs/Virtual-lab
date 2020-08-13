using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReactionState {inital, choseLiquid, choseWeight, reactionStarting, videoPlaying};

public class ReactionManagerScript : MonoBehaviour
{
    public ReactionState reactionState;
    public static bool isReadyForReaction=false;
    public static Transform LiquidObject;
    public static Transform MetalObject;
    public GameObject LiquidCanvas;
    public GameObject StartReactionCanvas;
    public ScaleScript scale;
    public GameObject Cylinder;
    //public float rotateSpeed=90;

    // Start is called before the first frame update
    void Start()
    {
        reactionState = ReactionState.inital;
        Cylinder.SetActive(false);
        scale.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //print(LiquidObject);
        if (reactionState == ReactionState.inital && LiquidObject != null && MetalObject != null)
        {
            reactionState = ReactionState.choseLiquid;
        }
        else if(reactionState == ReactionState.choseLiquid && MetalObject == null || LiquidObject == null)
        {
            reactionState = ReactionState.inital;
        }
        
        if(reactionState == ReactionState.inital)
        {
            toggleMovment(true);
        }
        else if (reactionState == ReactionState.choseLiquid)
        {
            toggleMovment(false);
            LiquidCanvas.SetActive(true);
            Cylinder.SetActive(true);
            if (isReadyForReaction && scale.listOfObjectsOnHere.Count > 0)
            {
                StartReactionCanvas.SetActive(true);
            }
            else
            {
                StartReactionCanvas.SetActive(false);
            }
            //LiquidObject.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        }
    }

    void toggleMovment(bool enableBool)
    {
        BeakerScript[] gos = GameObject.FindObjectsOfType<BeakerScript>();
        foreach (var item in gos)
        {
            item.CanMove = enableBool;
        }

        MetalScript[] goss = GameObject.FindObjectsOfType<MetalScript>();
        foreach (var item in goss)
        {
            item.CanMove = enableBool;
        }
    }
}
