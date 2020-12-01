using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLVariableThing : MonoBehaviour
{
    public GameObject[] DisableOnA;
    public GameObject[] DisableOnB;
    public GameObject[] DisableOnC;

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_EDITOR
        string[] URL = "test.com/test?a".Split('?');
#else
        string[] URL = Application.absoluteURL.Split('?');
#endif
        if (URL.Length < 2)
        {
            return;
        }

        if (URL[1] == "a")
        {
            foreach (var item in DisableOnA)
            {
                item.SetActive(false);
            }
        }
        else if (URL[1] == "b")
        {
            foreach (var item in DisableOnB)
            {
                item.SetActive(false);
            }
        }
        else if (URL[1] == "c")
        {
            foreach (var item in DisableOnC)
            {
                item.SetActive(false);
            }
        }
    }
}
