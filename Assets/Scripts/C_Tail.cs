using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Tail : MonoBehaviour
{
    public Transform neck;
    List<Transform> tail = new List<Transform>();
    List<Vector3> tailPosition = new List<Vector3>();
    public int foodToAdd = 3;
    int startLength;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] _tail = GetComponentsInChildren<Transform>();
        foreach (Transform t in _tail)
        {
            tail.Add(t);
            tailPosition.Add(t.position);
        }
        startLength = tail.Count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tail.Count < Mathf.Floor(C_Status.food/foodToAdd) + startLength)
        {
            Transform t = Instantiate(tail[tail.Count - 1], tail[tail.Count - 1].parent);
            tail.Add(t);
            tailPosition.Add(t.position);
        }

        for (int i = tail.Count - 1; i > 0; i--)
        {
            tail[i].position = tailPosition[i - 1];
            tailPosition[i] = tailPosition[i - 1];
            tail[i].GetComponent<Renderer>().material.color = C_Settings.snakeColor;
        }
        tailPosition[0] = neck.position;
        tail[0].position = tailPosition[0];
    }
}
