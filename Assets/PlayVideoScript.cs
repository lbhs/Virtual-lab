using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoScript : MonoBehaviour
{
    public GameObject videoScreen;

   public void PlayAVideo()
    {
        videoScreen.SetActive(true);
    }
}
