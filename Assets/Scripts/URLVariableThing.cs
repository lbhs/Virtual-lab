using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class combo
{
    public string KeyLetter;
    public GameObject[] EnableOn;
}
public class URLVariableThing : MonoBehaviour
{
    public combo[] combos;

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_EDITOR
        string[] URL = "test.com/test?ad".Split('?');
#else
        string[] URL = Application.absoluteURL.Split('?');
#endif
        if (URL.Length < 2)//if there's no queston mark
        {
            return;
        }

        foreach (var item in combos)
        {
            if (URL[1].Contains(item.KeyLetter))
            {
                foreach (var item2 in item.EnableOn)//enable all the right ones
                {
                    item2.SetActive(true);
                }
            }
            else
            {
                foreach (var item2 in item.EnableOn)//disable all the wrong ones
                {
                    item2.SetActive(false);
                }
            }
        }
    }
}
