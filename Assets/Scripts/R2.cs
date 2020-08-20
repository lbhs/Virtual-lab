using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class R2 : MonoBehaviour
{
    public static event Action<string, int> Rotated1 = delegate { };
    private bool coroutineAllowed1;
    public AudioSource TurningWheelSound2;
    private int numberShown1;
    private void Start()
    {
        coroutineAllowed1 = true;
        numberShown1 = 0;
    }

    private void OnMouseDown()
    {


        if (coroutineAllowed1)
        {
            StartCoroutine("RotateWheel");

        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed1 = false;

        for (int i = 0; i <= 11; i++)
        {

            transform.Rotate(0f, 3f, 0f);
            yield return new WaitForSeconds(0.01f);

        }

        coroutineAllowed1 = true;
        TurningWheelSound2 = GameObject.Find("Turning Lock Effect 2").GetComponent<AudioSource>();
        TurningWheelSound2.Play();
        numberShown1 += 1;

        if (numberShown1 > 9)
        {
            numberShown1 = 0;
        }

        Rotated1(name, numberShown1);
    }
}
