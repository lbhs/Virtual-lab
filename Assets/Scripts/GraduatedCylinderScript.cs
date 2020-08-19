﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduatedCylinderScript : MonoBehaviour
{
    //[Range(0, 0.99f)]
    //public float HowFullPercent;
    public float fillRate = 0.01f;
    //public Transform LiquidScaler;
    public Renderer LiquidRenderer;
    private bool isPouring = false;
    private float pouringPercent;
    public GameObject BackButton;
    // Update is called once per frame
    void Update()
    {
        //cap percent between 0 and 1
        if (LiquidRenderer.material.GetFloat("_FillAmount") > 0.99f)

            LiquidRenderer.material.SetFloat("_FillAmount", 0.99f);
        else if (LiquidRenderer.material.GetFloat("_FillAmount") < 0)
            LiquidRenderer.material.SetFloat("_FillAmount", 0);

        //Transparency (scale.y = 0 causes weird bugs)
        if (LiquidRenderer.material.GetFloat("_FillAmount") == 0)
        {
            Color newColor = LiquidRenderer.material.GetColor("_Tint");
            newColor.a = 0;
            LiquidRenderer.material.color = newColor;
        }
        else
        {
            Color newColor = LiquidRenderer.material.color;
            newColor.a = 1;
            LiquidRenderer.material.color = newColor;
        }

        //set the scale

        if (isPouring)
        {
            if (ReactionManagerScript.LiquidObject.eulerAngles.y > 315)
            {
                ReactionManagerScript.LiquidObject.Rotate(0, -90 * Time.deltaTime,0);
            }
            if (ReactionManagerScript.LiquidObject.position.y < 4.5f)
            {
                ReactionManagerScript.LiquidObject.position += new Vector3(0, 5,0) * Time.deltaTime;
            }
           // else
           // {
               // Vector3 pos = ReactionManagerScript.LiquidObject.position;
                //ReactionManagerScript.LiquidObject.position = new Vector3(pos.x, 4.5f, pos.z);
           // }
            if (LiquidRenderer.material.GetFloat("_FillAmount") >= pouringPercent)
            {
                BackButton.SetActive(true);
                isPouring = false;
                ReactionManagerScript.LiquidisReady = true;
                ReactionManagerScript.LiquidObject.eulerAngles = new Vector3(0, 0, 0);
                ReactionManagerScript.LiquidObject.position = new Vector3(-7.25f, 1.7f, 6.5f);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //fill up liquid and set color
        LiquidRenderer.material.SetFloat("_FillAmount", LiquidRenderer.material.GetFloat("_FillAmount") + fillRate);
        //HowFullPercent = HowFullPercent + fillRate;
        LiquidRenderer.material.color = other.GetComponent<ParticleSystem>().main.startColor.color;
    }

    public void fillToLevleFunction(float percentToFill)
    {
        LiquidRenderer.material.SetFloat("_FillAmount", 0);
        if (percentToFill > 1)
        {
            pouringPercent = 1;
        }
        else if (percentToFill < 0)
        {
            pouringPercent = 0;
        }
        else
        {
            pouringPercent = percentToFill;
        }
        ReactionManagerScript.liquidAmount = pouringPercent;
        ReactionManagerScript.LiquidObject.eulerAngles = new Vector3(0, 0, 359.9f);
        ReactionManagerScript.LiquidisReady = false;

        BackButton.SetActive(false);
        isPouring = true;
    }
}
