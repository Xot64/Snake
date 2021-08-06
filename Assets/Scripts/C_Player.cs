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
        recolor(Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Перекрашен");
        if (other.tag == "Wall")
        {
            Color c = other.GetComponent<Renderer>().material.color;
            c.a = 1f;
            recolor(c);
            Destroy(other.transform.parent.gameObject);
        }
    }

}
