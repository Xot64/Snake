using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Canvas : MonoBehaviour
{
    public Text level, gem, food, status;
    public Image foodIMG;
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
                break;
            case mode.lose:
                status.text = "YOU LOSE";
                status.color = Color.red;
                break;
            case mode.win:
                status.text = "YOU WIN";
                status.color = Color.green;
                break;
        }


    }
}
