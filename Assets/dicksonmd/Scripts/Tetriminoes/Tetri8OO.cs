using UnityEngine;
using System.Collections;
using System;

public class Tetri8OO : TetriminoConfig
{

    public Tetri8OO()
    {
        name = "8OO";
        color = new Color(255, 255, 0);
        center = new Vector3(1, 1, 1);
        config = new BrickConfig[]{
        new BrickConfig(
            "0",
            new bool[,,] {//x-
                {   //z-  z+
                    {_1, _1},//y-
                    {_1, _1},//y+
                },
                {   //z-  z+
                    {_1, _1},//y-
                    {_1, _1},//y+
                }, // x+
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
