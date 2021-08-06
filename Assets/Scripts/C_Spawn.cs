using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Spawn : MonoBehaviour
{
    public float dist = 0.4f;
    public GameObject spawnObject;
    public int[] num = { 4, 6 };
    // Start is called before the first frame update
    void Start()
    {
        GameObject newFood;
        bool good = Random.Range(0f, 1f) > 0.5f;
            for (int i = 0; i < Random.Range(num[0], num[1] + 1); i++)
            {
                newFood = Instantiate(spawnObject, transform.position + new Vector3(Random.Range(-dist, dist), -0.5f, Random.Range(-dist, dist)), Quaternion.identity, transform.parent);
                newFood.GetComponentInChildren<C_Food>().good = good;
            }
        Destroy(gameObject);
        
    }
}