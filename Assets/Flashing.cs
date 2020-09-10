using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public Renderer r;
    public float flashTime = 0.25f;

    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color DarkColor;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color LightColor;

    bool UseDark = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("StartFlashing");
    }
    
    IEnumerator StartFlashing()
    {
        while (true==true) //infinite loop
        {
            yield return new WaitForSeconds(flashTime);
                //print("test");
            if (UseDark)
            {
                UseDark = false;
                r.material.SetColor("_EmissionColor", DarkColor);
            }
            else
            {
                UseDark = true;
                r.material.SetColor("_EmissionColor", LightColor);
            }
        }
    }
    
}
