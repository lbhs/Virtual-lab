using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
  
    private bool isOpened;
    public AudioSource SpookyBackgroundMusic;
    private void Start()
    {
      
            if (isOpened)
            {
                SpookyBackgroundMusic = GameObject.Find("Spooky Background Song").GetComponent<AudioSource>();
                SpookyBackgroundMusic.Stop();
            }
        }
       
        
    }

  
   


