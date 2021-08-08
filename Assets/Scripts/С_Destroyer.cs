using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class С_Destroyer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Gem") || (other.tag == "Food") || (other.tag == "Bomb"))
        {
            Destroy(other.gameObject);
        }
    }
}
