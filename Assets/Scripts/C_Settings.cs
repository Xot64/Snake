using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Settings: MonoBehaviour 
{
    public Color[] colors = { Color.red, Color.green, Color.blue,Color.yellow, Color.cyan, Color.magenta };
    public Color snakeColor;
    public Color badFoodColor;
    private void Awake()
    {
        SetColor(GetColor());
    }

    public void SetColor(Color c)
    {
        snakeColor = c;
        badFoodColor = c;
        while (badFoodColor == snakeColor)
        {
            badFoodColor = GetColor();
        }
    }
    public void SetColor (int i)
    {
        SetColor(colors[i]);
    }

    public Color GetColor(int i)
    {
        return colors[Mathf.Min(Mathf.Max(i,0),colors.Length - 1)];
    }
    public Color GetColor()
    {
        return GetColor(Random.Range(0,colors.Length));
    }
    public Color GetColor(bool snake)
    {
        return snake ? snakeColor : badFoodColor;
    }
}
