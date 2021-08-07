using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Canvas : MonoBehaviour
{
    public Text level, gem, food;
    public Image foodIMG;
    // Start is called before the first frame update
    void Start()
    {
        level.text = string.Format("LEVEL {0}", C_Status.Level);
    }

    // Update is called once per frame
    void Update()
    {
        gem.text = C_Status.gems.ToString();
        food.text = C_Status.food.ToString();
        foodIMG.color = C_Settings.snakeColor;
    }
}
