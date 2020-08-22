using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideoScript : MonoBehaviour
{
    public GameObject videoScreen;
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
    }

    public void ReloadScene()
    {
        ReactionManagerScript.LiquidisReady = false;
        ReactionManagerScript.MassisReady = false;
        ReactionManagerScript.LiquidObject = null;
        ReactionManagerScript.MetalObject = null;
        ReactionManagerScript.liquidAmount = 0;
        ReactionManagerScript.MassAmount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
