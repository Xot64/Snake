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
    void FixedUpdate()
    {
        Movement();
    }

    void recolor(Color c)
    {
        Renderer[] snake = transform.parent.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in snake)
        {
            r.material.color = c;
            C_Settings.snakeColor = c;
        }
    }

    public Vector2 speed = new Vector2(0.01f, 3);
    public float sensitive = 1.5f;
    bool enCotrol = true;
    Color myColor;
    public float feverPeriod = 6f;
    void Movement()
    {
        if (C_Status.GM == mode.game)
        {
            transform.parent.position += speed.y * Time.deltaTime * Vector3.forward * (fever ? 3 : 1);
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
                if (Time.time - lastFeverTime > feverPeriod)
                {
                    fever = false;
                    C_Status.gems = 0;
                }
                GetComponent<Rigidbody>().velocity = (-transform.position.x * Vector3.right) * speed.x;
                recolor(Color.white);
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(3, -GetComponent<Rigidbody>().velocity.x) / Mathf.PI * 180 - 90, transform.eulerAngles.z);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
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
            if (!fever) takeGem();
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
        if (other.tag == "Bomb")
        {
            if (!fever) gameOver();
            Destroy(other.gameObject);
        }

    }
    float lastGem = 0f;
    int gemRow;
    public float gemPeriod = 0.5f;
    bool fever;
    float lastFeverTime = 0f;
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
            enCotrol = false;
            fever = true;
            lastFeverTime = Time.time;
        }
        lastGem = Time.time;


    }
    void gameOver ()
    {
        Debug.Log("GameOver");
        C_Status.GM = mode.lose;
    }
}
