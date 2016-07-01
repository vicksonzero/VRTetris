using UnityEngine;
using System.Collections;
using System;

public class Tetri1Dot : TetriminoConfig
{
    private static Tetri1Dot instance;
    public static Tetri1Dot get()
    {
        if (instance == null) instance = new Tetri1Dot();
        return instance;
    }
    public Tetri1Dot()
    {
        name = "1Dot";
        color = new Color(255, 255, 0);
        center = new Vector3(0, 0, 0);
        config = new BrickConfig[]{
        new BrickConfig(
            "0",
            new bool[,,] {//x-
                {   //z-
                    {_1},//y-
                },
            },
            new int[] // next
            {
                0,// up
                0,// down
                0,// left
                0,// right
                0,// forward
                0,// back
            }
            ),
        };
    }
}
