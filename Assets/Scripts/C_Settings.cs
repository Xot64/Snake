using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Settings: MonoBehaviour 
{
    public static Color[] colors = { Color.red, Color.green, Color.blue,Color.yellow, Color.cyan, Color.magenta };
    public Color[] colorsInLevel = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta };
    public static Color snakeColor;
    public static Color badFoodColor;
    private void Awake()
    {
        SetColor(GetColor());
        colors = colorsInLevel;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        SetColor(GetColor());
    }

    public static void SetColor(Color c)
    {
        snakeColor = c;
        badFoodColor = c;
        while (badFoodColor == snakeColor)
        {
            badFoodColor = GetColor();
        }
    }
    public static void SetColor (int i)
    {
        SetColor(colors[i]);
    }

    public static Color GetColor(int i)
    {
        return colors[Mathf.Min(Mathf.Max(i,0),colors.Length - 1)];
    }
    public static Color GetColor()
    {
        return GetColor(Random.Range(0,colors.Length));
    }
    public static Color GetColor(bool snake)
    {
        return snake ? snakeColor : badFoodColor;
    }
}
