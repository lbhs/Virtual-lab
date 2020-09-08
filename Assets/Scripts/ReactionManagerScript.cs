using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReactionState {inital, choseLiquid, choseMass, reactionStarting, videoPlaying};

public class ReactionManagerScript : MonoBehaviour
{
    public ReactionState reactionState;
    public static bool LiquidisReady=false;
    public static bool MassisReady = false;
    public static Transform LiquidObject;
    public static Transform MetalObject;
    public static float liquidAmount;
    public static float MassAmount;
    public GameObject LiquidCanvas;
    public GameObject StartReactionCanvas;
    public GameObject ContinueCanvasOne;
    public GameObject ContinueCanvasTwo;
    public GameObject MassCanvas;
    public GameObject StartReactionButton;
    public ScaleScript scale;
    public GameObject Cylinder;
    public GameObject beaker;
    public GameObject LiquidIndicator;
    public GameObject MassIndicator;
    //public float rotateSpeed=90;

    // Start is called before the first frame update
    void Start()
    {
        reactionState = ReactionState.inital;
        Cylinder.SetActive(false);
        scale.gameObject.SetActive(false);
        beaker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //print(LiquidObject);
        //print(MetalObject);
        if (reactionState == ReactionState.inital && LiquidObject != null && MetalObject != null)
        {
            ContinueCanvasOne.SetActive(true);
            LiquidCanvas.SetActive(false);
        }
        else if(reactionState == ReactionState.inital && MetalObject == null || LiquidObject == null)
        {
            ContinueCanvasOne.SetActive(false);
        }

        if (reactionState == ReactionState.inital && MetalObject == null)
        {
            MassIndicator.SetActive(true);
            LiquidIndicator.SetActive(false);
        }
        if (reactionState == ReactionState.inital && LiquidObject == null)
        {
            LiquidIndicator.SetActive(true);
            MassIndicator.SetActive(false);
        }

        if (reactionState == ReactionState.inital)
        {
            toggleMovment(true);
        }
        else if (reactionState == ReactionState.choseLiquid)
        {
            LiquidIndicator.SetActive(false);
            MassIndicator.SetActive(false);
            ContinueCanvasOne.SetActive(false);
            Camera.main.GetComponent<CameraZoomer>().MoveAndZoomToGameObject(Cylinder.transform);
            toggleMovment(false);
            LiquidCanvas.SetActive(true);
            Cylinder.SetActive(true);
            if(LiquidisReady == true)
            {
                ContinueCanvasTwo.SetActive(true);
            }
            else
            {
                ContinueCanvasTwo.SetActive(false);
            }
        }
        else if(reactionState == ReactionState.choseMass)
        {
            MassCanvas.SetActive(true);
            scale.gameObject.SetActive(true);
            Camera.main.GetComponent<CameraZoomer>().MoveAndZoomToGameObject(scale.transform);
            if(MassisReady == true)
            {
                StartReactionButton.SetActive(true);
            }
            else
            {
                StartReactionButton.SetActive(false);
            }
        }
        else if(reactionState == ReactionState.reactionStarting)
        {
            beaker.SetActive(true);
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

    public void GoBackToInital()
    {
        reactionState = ReactionState.inital;
        Camera.main.GetComponent<CameraZoomer>().MoveAndZoomToGameObject(transform);
        ContinueCanvasTwo.SetActive(false);
    }
    public void GoBackToLiquid()
    {
        reactionState = ReactionState.choseLiquid;
        Camera.main.GetComponent<CameraZoomer>().MoveAndZoomToGameObject(Cylinder.transform);
        //ContinueCanvasTwo.SetActive(false);
        MassCanvas.SetActive(false);
    }
    public void ContinueButtonOne()
    {
        reactionState = ReactionState.choseLiquid;
        //Cylinder.GetComponent<GraduatedCylinderScript>().LiquidRenderer.material.SetFloat("_FillAmount", 0);
        liquidAmount = 0;
        LiquidisReady = false;
    }

    public void ContinueButtonTwo()
    {
        reactionState = ReactionState.choseMass;
        ContinueCanvasTwo.SetActive(false);
        LiquidCanvas.SetActive(false);
        scale.setNoGrams();
    }

    public void StartReactionButtonFunction()
    {
        reactionState = ReactionState.reactionStarting;
        MassCanvas.SetActive(false);
        Camera.main.GetComponent<CameraZoomer>().MoveAndZoomToGameObject(beaker.transform); //change this to the beaker's transform
        GetComponent<ReactionAnim>().startAnimation();
    }
    
}
