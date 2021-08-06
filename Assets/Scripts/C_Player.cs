using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
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

    public Vector2 speed = new Vector2(0.01f, 3);
    public float sensitive = 1.5f;
    void Movement()
    {
        transform.parent.position += speed.y * Time.deltaTime * Vector3.forward;
        //GetComponent<Rigidbody>().velocity = Swipe() * Vector3.right * speed.x;
        if (Input.GetMouseButton(0))
        {

            Vector3 newPos = Mathf.Clamp((Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2), -1f, 1f) * Vector3.right * sensitive;
            GetComponent<Rigidbody>().velocity = (newPos - transform.position.x * Vector3.right) * speed.x;
        }
        else GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Color c = other.GetComponent<Renderer>().material.color;
            c.a = 1f;
            recolor(c);
            Destroy(other.transform.parent.gameObject);
        }
    }

}
