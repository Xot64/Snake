﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Settings: MonoBehaviour 
{
    public static Color[]  colors = { Color.red, Color.green, Color.blue,Color.yellow, Color.cyan, Color.magenta };
    public        Color[] _colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta };
    public static Color snakeColor;
    public static Color badFoodColor;
    public static float  playerSpeed = 1f;
    public        float _playerSpeed = 1f;
    private void Awake()
    {
        SetColor(GetColor());
        colors = _colors;
        playerSpeed = _playerSpeed;
        distColorChange = _distColorChange;
        
    }

    public static float _distColorChange = 20;
    public float distColorChange = 20;
    public static Color[] goodColor;
    public static Color[] badColor;
    int numWall;

    public GameObject wall;
    public GameObject road;
    private void Start()
    {
        numWall = Mathf.FloorToInt(road.transform.lossyScale.z / _distColorChange);
        goodColor = new Color[numWall];
        badColor = new Color[numWall];
        generateWalls();   
    }
    void generateWalls() //Генерация стен
    {
        GameObject parentWall = Instantiate(new GameObject("Walls"), Vector3.zero, Quaternion.identity);
        GameObject oldWall = null, newWall;
        Color c;
        for (int i = 1; i <= numWall; i++)
        {
            newWall = Instantiate(wall, Vector3.forward * i * _distColorChange, Quaternion.identity, parentWall.transform);
            c = GetColor(0.3f);
            if (i > 1)
            {
                while (oldWall.GetComponentInChildren<Renderer>().material.color == c) c = GetColor(0.3f);
            }
            oldWall = newWall;
            newWall.GetComponentInChildren<Renderer>().material.color = c;
            goodColor[i - 1] = c;
            while (goodColor[i] == c) c = GetColor(0.3f);
            badColor[i] = c;
        }
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
    public static Color GetColor(float alpha)
    {
        Color c = GetColor();
        c.a = alpha;
        return c;
    }

}