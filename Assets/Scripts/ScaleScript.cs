using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleScript : MonoBehaviour
{
    public Text DisplayText;
    public GameObject[] massObjects = new GameObject[2];
    public Renderer[] metalObjects;
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
    public void setOneGrams()
    {
        massObjects[0].SetActive(true);
        massObjects[1].SetActive(false);
        DisplayText.text = "1.00 g";
        setRendrer(ReactionManagerScript.MetalObject.GetComponent<MetalScript>().MetalMaterial, ReactionManagerScript.MetalObject.GetComponent<MetalScript>().MetalMesh);
        ReactionManagerScript.MassisReady = true;
        ReactionManagerScript.MassAmount = 1;
    }
    public void setTwoGrams()
    {
        massObjects[0].SetActive(true);
        massObjects[1].SetActive(false);
        DisplayText.text = "2.00 g";
        setRendrer(ReactionManagerScript.MetalObject.GetComponent<MetalScript>().MetalMaterial,ReactionManagerScript.MetalObject.GetComponent<MetalScript>().MetalMesh);
        ReactionManagerScript.MassisReady = true;
        ReactionManagerScript.MassAmount = 2;
    }
    public void setFourGrams()
    {
        massObjects[0].SetActive(true);
        massObjects[1].SetActive(true);
        DisplayText.text = "4.00 g";
        setRendrer(ReactionManagerScript.MetalObject.GetComponent<MetalScript>().MetalMaterial, ReactionManagerScript.MetalObject.GetComponent<MetalScript>().MetalMesh);
        ReactionManagerScript.MassisReady = true;
        ReactionManagerScript.MassAmount = 4;
    }

    public void setNoGrams()
    {
        massObjects[0].SetActive(false);
        massObjects[1].SetActive(false);
        DisplayText.text = "000 g";
        ReactionManagerScript.MassisReady = false;
        ReactionManagerScript.MassAmount = 0;
    }

    void setRendrer(Material mat, Mesh mesh)
    {
        foreach (var item in metalObjects)
        {
            item.material = mat;
            item.GetComponent<MeshFilter>().mesh = mesh;
            item.GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}
