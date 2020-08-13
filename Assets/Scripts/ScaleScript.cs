using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScript : MonoBehaviour
{
    public Text DisplayText;
    [Header("Needs to be only 4, first two will always be picked")]
    public GameObject[] massObjects = new GameObject[4];

    //[HideInInspector]
   // public List<GameObject> listOfObjectsOnHere = new List<GameObject>();
    //private void ontriggerenter(collider other)
    //{
    //    if(other.transform.parent.getcomponent<rigidbody>() != null)
    //    {
    //        listofobjectsonhere.add(other.transform.parent.gameobject);
    //        float val = float.parse(displaytext.text);
    //        val += other.transform.parent.getcomponent<rigidbody>().mass;
    //        displaytext.text = val.tostring();
    //    }
    //}
    //private void ontriggerexit(collider other)
    //{
    //    if (other.transform.parent.getcomponent<rigidbody>() != null)
    //    {
    //        listofobjectsonhere.remove(other.transform.parent.gameobject);
    //        float val = float.parse(displaytext.text);
    //        val -= other.transform.parent.getcomponent<rigidbody>().mass;
    //        displaytext.text = val.tostring();
    //    }
    //}

    public void setTwoGrams()
    {
        massObjects[0].SetActive(true);
        massObjects[1].SetActive(true);
        massObjects[2].SetActive(false);
        massObjects[3].SetActive(false);
        DisplayText.text = "2.00 g";
        ReactionManagerScript.MassisReady = true;
    }
    public void setFourGrams()
    {
        massObjects[0].SetActive(true);
        massObjects[1].SetActive(true);
        massObjects[2].SetActive(true);
        massObjects[3].SetActive(true);
        DisplayText.text = "4.00 g";
        ReactionManagerScript.MassisReady = true;
    }

    public void setNoGrams()
    {
        massObjects[0].SetActive(false);
        massObjects[1].SetActive(false);
        massObjects[2].SetActive(false);
        massObjects[3].SetActive(false);
        DisplayText.text = "000 g";
        ReactionManagerScript.MassisReady = false;
    }
}
