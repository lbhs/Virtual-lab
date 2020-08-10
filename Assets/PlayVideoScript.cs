using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoScript : MonoBehaviour
{
    public GameObject videoScreen;
    public GameObject eventSystem;

   public void PlayAVideo()
    {
        videoScreen.SetActive(true);
        eventSystem.SetActive(false);
    }
}
