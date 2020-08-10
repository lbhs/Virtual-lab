using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScript : MonoBehaviour
{
    public Text DisplayText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.GetComponent<Rigidbody>() != null)
        {
            float val = float.Parse(DisplayText.text);
            val += other.transform.parent.GetComponent<Rigidbody>().mass;
            DisplayText.text = val.ToString();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.GetComponent<Rigidbody>() != null)
        {
            float val = float.Parse(DisplayText.text);
            val -= other.transform.parent.GetComponent<Rigidbody>().mass;
            DisplayText.text = val.ToString();
        }
    }
}
