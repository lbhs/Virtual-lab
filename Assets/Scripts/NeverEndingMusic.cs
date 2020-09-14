using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverEndingMusic : MonoBehaviour
{
    static NeverEndingMusic me;
    // Start is called before the first frame update
    void Start()
    {
        if (me == null)
        {
            me = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
