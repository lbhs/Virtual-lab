using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class ReactionAnim : MonoBehaviour
{
    private bool isPlaying = false;
    public string[] videoNames;
    public ReactionManagerScript RMS;
    public List<Transform> Metals = new List<Transform>();
    public Transform TargetPos;
    public Transform GCylinder;
    public ScaleScript Scale;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == true)
        {
            //print("animating...");
            Scale.DisplayText.text = "000 g";
            foreach (var item in Metals)
            {
                if (item.gameObject.activeSelf == true)
                {
                    if (Time.time - time < 2.7f)
                    {
                        if (item.localPosition.x > -5)
                        {
                            item.GetComponent<Rigidbody>().useGravity = false;
                            item.GetComponent<MeshCollider>().enabled = false;
                            item.position = Vector3.MoveTowards(item.position, TargetPos.position, 3 * Time.deltaTime);
                        }
                        else
                        {
                            item.GetComponent<Rigidbody>().useGravity = true;
                            item.GetComponent<MeshCollider>().enabled = true;
                        }
                    }
                    else
                    {
                        if(Vector3.Distance(item.position,TargetPos.position) > 1)
                        {
                            item.position = TargetPos.position;
                            item.GetComponent<Rigidbody>().useGravity = true;
                            item.GetComponent<MeshCollider>().enabled = true;
                        }
                    }
                   
                }
            }

            GCylinder.position = Vector3.MoveTowards(GCylinder.position, new Vector3(-4.5f, 4f, 7), 2 * Time.deltaTime);
            //print(GCylinder.eulerAngles.z);
            if (GCylinder.eulerAngles.z > 310 || GCylinder.eulerAngles.z ==0)
            {
                GCylinder.Rotate(0,0, -90 * Time.deltaTime);
            }

            if (Time.time - time > 4) //if Animation is done
            { 
                isPlaying = false;
                StartVideo();
            }
        }
    }

    public void startAnimation()
    {
        time = Time.time;
        isPlaying = true;
    }

    void StartVideo()
    {
        string LiquidName = ReactionManagerScript.LiquidObject.name; //Name of GameObject
        string MetalName = ReactionManagerScript.MetalObject.name; //Name of GameObject
        float LiquidAmount = ReactionManagerScript.liquidAmount; //from a scale of 0 to 1
        float MassAmount = ReactionManagerScript.MassAmount; //Set in the ScaleScript functions

        if (LiquidAmount == 1f && MassAmount == 1 && LiquidName == "3M")
        {
            if (MetalName == "Zn")
            {
                GetComponent<PlayVideoScript>().PlayAVideo(videoNames[0]);
            }
            else if(MetalName == "Mg")
            {
                GetComponent<PlayVideoScript>().PlayAVideo(videoNames[1]);
            }
            else if(MetalName == "Cu")
            {
                GetComponent<PlayVideoScript>().PlayAVideo(videoNames[2]);
            }
        }
        else //Backup
        {
            print("Liquid name: " + LiquidName + " Liquid Amount: " + LiquidAmount + " Metal Name: " + MetalName + " Metal Amount: " + MassAmount);
            throw new System.ArgumentException("Error, could not meet conditions in ReactionAnim Script");
            //GetComponent<PlayVideoScript>().PlayAVideo(videoNames[0]);
        }
    }
}
