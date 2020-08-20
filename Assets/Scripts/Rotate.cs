using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    public AudioSource TurningWheelSound;
    private int numberShown;
    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    private void OnMouseDown()
    {


        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");

        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            
            transform.Rotate(0f, 3f, 0f);
            yield return new WaitForSeconds(0.01f);
          
        }

        coroutineAllowed = true;
        if (gameObject.name == "WheelOne" || gameObject.name == "WheelThree" || gameObject.name == "WheelFive")
        {
            TurningWheelSound = GameObject.Find("Turning Lock Effect").GetComponent<AudioSource>();
            TurningWheelSound.Play();
        }
        else {
            TurningWheelSound = GameObject.Find("Turning Lock Effect 2").GetComponent<AudioSource>();
            TurningWheelSound.Play();
        }
        numberShown += 1;
       
        if (numberShown > 9)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }
}
