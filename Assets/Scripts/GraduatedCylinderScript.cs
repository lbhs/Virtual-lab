using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduatedCylinderScript : MonoBehaviour
{
    [Range(0,1)]
    public float HowFullPercent;
    public float fillRate = 0.01f;
    public Transform LiquidScaler;
    public Renderer LiquidRenderer;

    // Update is called once per frame
    void Update()
    {
        //cap percent between 0 and 1
        if (HowFullPercent > 1)
            HowFullPercent = 1;
        else if (HowFullPercent < 0)
            HowFullPercent = 0;

        //Transparency (scale.y = 0 causes weird bugs)
        if(HowFullPercent == 0)
        {
            Color newColor = LiquidRenderer.material.color;
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
        LiquidScaler.localScale = new Vector3(1, HowFullPercent, 1);
    }

    private void OnParticleCollision(GameObject other)
    {
        //fill up liquid and set color
        HowFullPercent = HowFullPercent + fillRate;
        LiquidRenderer.material.color = other.GetComponent<ParticleSystem>().main.startColor.color;
    }
}
