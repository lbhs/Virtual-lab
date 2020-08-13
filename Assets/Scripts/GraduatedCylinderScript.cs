using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduatedCylinderScript : MonoBehaviour
{
    [Range(0, 0.99f)]
    public float HowFullPercent;
    public float fillRate = 0.01f;
    public Transform LiquidScaler;
    public Renderer LiquidRenderer;
    private bool isPouring = false;
    private float pouringPercent;
    // Update is called once per frame
    void Update()
    {

        //cap percent between 0 and 1
        if (HowFullPercent > 0.99f)
            HowFullPercent = 0.99f;
        else if (HowFullPercent < 0)
            HowFullPercent = 0;

        //Transparency (scale.y = 0 causes weird bugs)
        if (HowFullPercent == 0)
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

        if (isPouring)
        {
            if (ReactionManagerScript.LiquidObject.eulerAngles.z > 315)
            {
                ReactionManagerScript.LiquidObject.Rotate(0, 0, -90 * Time.deltaTime);
            }
            if (ReactionManagerScript.LiquidObject.position.y < 5.5f)
            {
                ReactionManagerScript.LiquidObject.position += new Vector3(0, 5,0) * Time.deltaTime;
            }
            else
            {
                Vector3 pos = ReactionManagerScript.LiquidObject.position;
                ReactionManagerScript.LiquidObject.position = new Vector3(pos.x, 5.5f, pos.z);
            }
            if (HowFullPercent >= pouringPercent)
            {
                isPouring = false;
                ReactionManagerScript.isReadyForReaction = true;
                ReactionManagerScript.LiquidObject.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //fill up liquid and set color
        HowFullPercent = HowFullPercent + fillRate;
        LiquidRenderer.material.color = other.GetComponent<ParticleSystem>().main.startColor.color;
    }

    public void fillToLevleFunction(float percentToFill)
    {
        HowFullPercent = 0;
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

        ReactionManagerScript.LiquidObject.eulerAngles = new Vector3(0, 0, 359.9f);
        ReactionManagerScript.isReadyForReaction = false;
        isPouring = true;
    }
}
