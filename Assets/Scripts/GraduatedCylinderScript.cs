using System.Collections;
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
    public GameObject LiquidParticle;
    // Update is called once per frame
    void Update()
    {
        //cap percent between 0 and 1
        if (LiquidRenderer.material.GetFloat("_FillAmount") < -1.74f)

            LiquidRenderer.material.SetFloat("_FillAmount", -1.74f);
        else if (LiquidRenderer.material.GetFloat("_FillAmount") > 1.74f)
            LiquidRenderer.material.SetFloat("_FillAmount", 1.74f);
        //print(transform.eulerAngles.z);
        if (transform.eulerAngles.z > 300 && transform.eulerAngles.z < 320)
        {
            var main = LiquidParticle.GetComponent<ParticleSystem>().main;
            main.startColor = LiquidRenderer.material.GetColor("_Tint");
            LiquidParticle.SetActive(true);
            LiquidRenderer.material.SetFloat("_FillAmount", LiquidRenderer.material.GetFloat("_FillAmount") +0.001f);
        }
        else
        {
            LiquidParticle.SetActive(false);
        }
        //Color newColor = LiquidRenderer.material.GetColor("_Tint");
        ////Transparency (scale.y = 0 causes weird bugs)
        //if (LiquidRenderer.material.GetFloat("_FillAmount") == 0)
        //{
        //    Color newColor = LiquidRenderer.material.GetColor("_Tint");
        //    newColor.a = 0;
        //    LiquidRenderer.material.color = newColor;
        //}
        //else
        //{
        //    Color newColor = LiquidRenderer.material.GetColor("_Tint");
        //    newColor.a = 1;
        //    LiquidRenderer.material.color = newColor;
        //}

            //set the scale

            if (isPouring)
        {
                //print(ReactionManagerScript.LiquidObject.eulerAngles.x);
            if (ReactionManagerScript.LiquidObject.eulerAngles.x < 330)
            {
                ReactionManagerScript.LiquidObject.Rotate(0,-90 *Time.deltaTime,0);
            }
            if (ReactionManagerScript.LiquidObject.position.y < 5.5f)
            {
                ReactionManagerScript.LiquidObject.position += new Vector3(0, 5,0) * Time.deltaTime;
            }
           // else
           // {
               // Vector3 pos = ReactionManagerScript.LiquidObject.position;
                //ReactionManagerScript.LiquidObject.position = new Vector3(pos.x, 4.5f, pos.z);
           // }
            if (LiquidRenderer.material.GetFloat("_FillAmount") <= pouringPercent)
            {
                BackButton.SetActive(true);
                isPouring = false;
                ReactionManagerScript.LiquidisReady = true;
                ReactionManagerScript.LiquidObject.eulerAngles = new Vector3(270, 180,0);
                ReactionManagerScript.LiquidObject.position = new Vector3(-7f, 2.5f, 7f);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //fill up liquid and set color
        LiquidRenderer.material.SetFloat("_FillAmount", LiquidRenderer.material.GetFloat("_FillAmount") - fillRate);
        //HowFullPercent = HowFullPercent + fillRate;
        LiquidRenderer.material.SetColor("_Tint", other.GetComponent<ParticleSystem>().main.startColor.color);
        LiquidRenderer.material.SetColor("_TopColor", other.GetComponent<ParticleSystem>().main.startColor.color);
    }

    public void fillToLevleFunction(float percentToFill)
    {
        LiquidRenderer.material.SetFloat("_FillAmount", 1.74f);
        //if (percentToFill > 1)
        //{
        //    pouringPercent = 1;
        //}
        //else if (percentToFill < 0)
        //{
        //    pouringPercent = 0;
        //}
        //else
        //{
            pouringPercent = percentToFill;
       // }
        ReactionManagerScript.liquidAmount = pouringPercent;
        ReactionManagerScript.LiquidObject.eulerAngles = new Vector3(-90, 270, -90);
        ReactionManagerScript.LiquidisReady = false;

        BackButton.SetActive(false);
        isPouring = true;
    }
}
