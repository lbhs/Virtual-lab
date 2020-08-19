using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class ReactionAnim : MonoBehaviour
{
    private bool isPlaying = false;
    public string[] videoNames;
    public ReactionManagerScript RMS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == true)
        {
            print("animating...");

            if(true == true) //if Animation is done
            {
                isPlaying = false;
                StartVideo();
            }
        }
    }

    public void startAnimation()
    {
        isPlaying = true;
    }

    void StartVideo()
    {
        if (ReactionManagerScript.liquidAmount == 0.5f && ReactionManagerScript.MassAmount == 2)
        {
            if (ReactionManagerScript.LiquidObject.name == "Bottle1" && ReactionManagerScript.MetalObject.name == "metal1")
            {
                GetComponent<PlayVideoScript>().PlayAVideo(videoNames[1]);
            }
            else
            {
                GetComponent<PlayVideoScript>().PlayAVideo(videoNames[0]);
            }
        }
        else
        {
            GetComponent<PlayVideoScript>().PlayAVideo(videoNames[0]);
        }
    }
}
