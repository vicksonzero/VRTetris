using UnityEngine;
using System.Collections;
using System;

public class Tetri4T : TetriminoConfig
{

    public Tetri4T()
    {
        name = "4T";
        color = new Color(255.0f / 255, 192.0f / 255, 0.0f / 255, 1);
        center = new Vector3(1, 1, 1);
        config = new BrickConfig[]{
        new BrickConfig(
            "0",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _1, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                4,// up
                4,// down
                8,// left
                9,// right
                3,// forward
                2,// back
            }
            ),
        new BrickConfig(
            "1",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _1, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                5,// up
                5,// down
                9,// left
                8,// right
                2,// forward
                3,// back
            }
            ),
        new BrickConfig(
            "2",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _1, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _1, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                6,// up
                7,// down
                10,// left
                10,// right
                0,// forward
                1,// back
            }
            ),
        new BrickConfig(
            "3",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _1, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _1, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                7,// up
                6,// down
                11,// left
                11,// right
                1,// forward
                0,// back
            }
            ),
        new BrickConfig(
            "4",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _1, _0},//y-
                    {_1, _1, _1},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                0,// up
                0,// down
                7,// left
                6,// right
                11,// forward
                10,// back
            }
            ),
        new BrickConfig(
            "5",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_1, _1, _1},//y
                    {_0, _1, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                1,// up
                1,// down
                6,// left
                7,// right
                10,// forward
                11,// back
            }
            ),
        new BrickConfig(
            "6",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _1, _0},//y-
                    {_0, _1, _1},//y
                    {_0, _1, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                3,// up
                2,// down
                4,// left
                5,// right
                9,// forward
                9,// back
            }
            ),
        new BrickConfig(
            "7",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _1, _0},//y-
                    {_1, _1, _0},//y
                    {_0, _1, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                2,// up
                3,// down
                5,// left
                4,// right
                8,// forward
                8,// back
            }
            ),
        new BrickConfig(
            "8",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_1, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                10,// up
                11,// down
                1,// left
                0,// right
                7,// forward
                7,// back
            }
            ),
        new BrickConfig(
            "9",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _1},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                11,// up
                10,// down
                0,// left
                1,// right
                6,// forward
                6,// back
            }
            ),
        new BrickConfig(
            "10",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_1, _1, _1},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                9,// up
                8,// down
                2,// left
                2,// right
                4,// forward
                5,// back
            }
            ),
        new BrickConfig(
            "11",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _1, _0},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_1, _1, _1},//y
                    {_0, _0, _0},//y+
                },
                {   //z-  z   z+
                    {_0, _0, _0},//y-
                    {_0, _0, _0},//y
                    {_0, _0, _0},//y+
                },//x+
            },
            new int[] // next
            {
                8,// up
                9,// down
                3,// left
                3,// right
                5,// forward
                4,// back
            }
            ),

        };
    }
}
