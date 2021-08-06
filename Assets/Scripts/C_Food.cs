using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Food : MonoBehaviour
{
    public bool good;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = C_Settings.GetColor(good);
    }
}
