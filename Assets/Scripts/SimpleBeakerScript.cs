using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBeakerScript : MonoBehaviour
{
    public Renderer LiquidRenderer;
    public float fillRate = 0.008f;
    private void OnParticleCollision(GameObject other)
    {
        //fill up liquid and set color
        LiquidRenderer.material.SetFloat("_FillAmount", LiquidRenderer.material.GetFloat("_FillAmount") - (fillRate*Time.deltaTime));
        //HowFullPercent = HowFullPercent + fillRate;
        LiquidRenderer.material.SetColor("_Tint", other.GetComponent<ParticleSystem>().main.startColor.color);
        LiquidRenderer.material.SetColor("_TopColor", other.GetComponent<ParticleSystem>().main.startColor.color);
    }
}
