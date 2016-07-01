using UnityEngine;
using System.Collections;

public class Tetri4S : TetriminoConfig
{


    public new string name = "4S";
    public new Color color = new Color(255, 255, 0);
    public new Vector3 center = new Vector3(1, 1, 1);
    public new BrickConfig[] config = {
        new BrickConfig(
            "0",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0 },//y-
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y+
                },
                {
                    {_0, _1, _0 },
                    {_0, _1, _0 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _1, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },//x+
            },
            new int[] // next
            {
                8,// up
                9,// down
                4,// left
                5,// right
                2,// front
                2,// back
            }
            ),
        new BrickConfig(
            "1",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_1, _1, _0 },
                    {_0, _1, _1 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                9,// up
                8,// down
                5,// left
                4,// right
                3,// front
                3,// back
            }
            ),
        new BrickConfig(
            "2",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _1, _0 },//y
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _0 },
                    {_0, _1, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                10,// up
                11,// down
                6,// left
                7,// right
                0,// front
                0,// back
            }
            ),
        new BrickConfig(
            "3",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y-
                    {_0, _1, _0 },//y
                    {_0, _1, _0 },//y+
                },
                {
                    {_0, _1, _0 },
                    {_0, _1, _0 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                11,// up
                10,// down
                7,// left
                6,// right
                1,// front
                1,// back
            }
            ),
        new BrickConfig(
            "4",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_1, _1, _0 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_1, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                6,// up
                6,// down
                1,// left
                0,// right
                10,// front
                11,// back
            }
            ),
        new BrickConfig(
            "5",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_1, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_1, _1, _0 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                7,// up
                7,// down
                0,// left
                1,// right
                11,// front
                10,// back
            }
            ),
        new BrickConfig(
            "6",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_1, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _1 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                4,// up
                4,// down
                3,// left
                2,// right
                8,// front
                9,// back
            }
            ),
        new BrickConfig(
            "7",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _1, _1 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_1, _1, _0 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                5,// up
                5,// down
                2,// left
                3,// right
                9,// front
                8,// back
            }
            ),
        new BrickConfig(
            "8",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _1, _1 },
                    {_1, _1, _0 },
                    {_0, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                1,// up
                0,// down
                10,// left
                10,// right
                7,// front
                6,// back
            }
            ),
        new BrickConfig(
            "9",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _1 },
                    {_1, _1, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                0,// up
                1,// down
                11,// left
                11,// right
                6,// front
                7,// back
            }
            ),
        new BrickConfig(
            "10",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_1, _0, _0 },
                    {_1, _1, _0 },
                    {_0, _1, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                3,// up
                2,// down
                8,// left
                8,// right
                5,// front
                4,// back
            }
            ),
        new BrickConfig(
            "11",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _1, _0 },
                    {_1, _1, _0 },
                    {_1, _0, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                2,// up
                3,// down
                7,// left
                7,// right
                4,// front
                5,// back
            }
            ),
    };
}
