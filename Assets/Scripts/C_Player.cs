using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = C_Settings.playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        recolor(Color.white); //Контроль цвета змейки
        
    }

    void recolor(Color c)
    {
        Renderer[] snake = transform.parent.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in snake)
        {
            r.material.color = c;
        }
    }
    void Movement()
    {
        transform.parent.position += speed * Time.deltaTime * Vector3.forward;
    }
}
