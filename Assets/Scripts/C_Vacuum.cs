using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Vacuum : MonoBehaviour
{
    public float power = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Food")
        {
            Vector3 direct = (other.transform.position - transform.position).normalized;
            other.transform.position -= direct * power * Time.deltaTime;
        }
    }
}
