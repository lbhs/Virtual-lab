using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionAnim : MonoBehaviour
{
    private bool isPlaying = false;

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
        GetComponent<PlayVideoScript>().PlayAVideo();
    }
}
