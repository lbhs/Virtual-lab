using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class PlayVideoScript : MonoBehaviour
{
    public GameObject videoScreen;
    public GameObject eventSystem;
    public VideoPlayer VP;
   public void PlayAVideo(string clip)
    {
#if UNITY_WEBGL 
        VP.url = "https://lbhs.github.io/Games/" + "Virtual-lab" + "/StreamingAssets/" + clip;
#else
        VP.url = System.IO.Path.Combine(Application.streamingAssetsPath, clip);
#endif
        VP.Play();
        videoScreen.SetActive(true);
        eventSystem.SetActive(false);
    }
}
