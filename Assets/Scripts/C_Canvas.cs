using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C_Canvas : MonoBehaviour
{
    public Text level, gem, food, status;
    public Image foodIMG;
    public GameObject b_next, b_reset;
    // Start is called before the first frame update
    void Start()
    {
        level.text = string.Format("LEVEL {0}", C_Status.level);
    }

    // Update is called once per frame
    void Update()
    {
        gem.text = C_Status.gems.ToString();
        food.text = C_Status.food.ToString();
        foodIMG.color = C_Settings.snakeColor;
        switch (C_Status.GM)
        {
            case mode.game:
                status.text = "";
                b_reset.SetActive(false);
                b_next.SetActive(false);
                break;
            case mode.undead:
                status.text = "";
                b_reset.SetActive(false);
                b_next.SetActive(false);
                break;
            case mode.lose:
                status.text = "YOU LOSE";
                b_reset.SetActive(true);
                status.color = Color.red;
                break;
            case mode.win:
                status.text = "YOU WIN";
                b_next.SetActive(true);
                status.color = Color.green;
                break;
        }


    }

    public void rest ()
    {
        SceneManager.LoadScene(0);
        C_Status.rest();
    }
    public void next ()
    {
        C_Status.level++;
        rest();
    }
}
