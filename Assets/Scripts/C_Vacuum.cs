using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Vacuum : MonoBehaviour
{
    public float power = 1f;

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Food") && (C_Status.GM == mode.game))
        {
            Vector3 direct = (other.transform.position - transform.position).normalized;
            other.transform.position -= direct * power * Time.deltaTime;
        }
    }
}
