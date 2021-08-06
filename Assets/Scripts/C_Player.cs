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
    bool enCotrol = true;
    Color myColor;
    void Movement()
    {
        transform.parent.position += speed.y * Time.deltaTime * Vector3.forward;
        //GetComponent<Rigidbody>().velocity = Swipe() * Vector3.right * speed.x;
        if (!fever)
        {
            recolor(myColor);
            if (Input.GetMouseButton(0))
            {

                Vector3 newPos = Mathf.Clamp((Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2), -1f, 1f) * Vector3.right * sensitive;
                GetComponent<Rigidbody>().velocity = (newPos - transform.position.x * Vector3.right) * speed.x;
            }
            else { GetComponent<Rigidbody>().velocity = Vector3.zero; }
        }
        else 
        { 
            GetComponent<Rigidbody>().velocity = (-transform.position.x * Vector3.right) * speed.x;
            recolor(Color.white);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            myColor = other.GetComponent<Renderer>().material.color;
            myColor.a = 1f;
            Destroy(other.transform.parent.gameObject);
        }
        if (other.tag == "Gem")
        {
            takeGem();
            Destroy(other.gameObject);


        }
        if (other.tag == "Food")
        {
            if ((other.GetComponent<C_Food>().good) || (fever))
            {
                C_Status.food++;
                Destroy(other.gameObject);
            }
            else gameOver();
            

        }
    }
    float lastGem = 0f;
    int gemRow;
    public float gemPeriod = 0.5f;
    bool fever;
    void takeGem()
    {
        C_Status.gems++;
        if (Time.time - lastGem <= gemPeriod)
        {
            gemRow++;
        }
        else
        {
            gemRow = 0;
        }
        if (gemRow == 3)
        {
            C_Status.gems = 0;
            enCotrol = false;
            fever = true;
        }


    }
    void gameOver ()
    {
        Debug.Log("GameOver");
    }
}
