using UnityEngine;
using System.Collections;

public class Tetri4S : TetriminoConfig
{


    public new string name = "4LL";
    public new Color color = new Color(255, 255, 0);
    public new Vector3 center = new Vector3(1, 1, 1);
    public new BrickConfig[] config = {
        new BrickConfig(
            "0",
            new bool[,,] {//x-
                {   //z-  z   z+
                    {_0, _0, _0 },//y-
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y+
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _1 },
                    {_0, _1, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _0 },
                    {_0, _0, _0 },
                },//x+
            },
            new int[] // next
            {
                1,// up
                3,// down
                4,// left
                3,// right
                4,// front
                1,// back
            }
            ),
        new BrickConfig(
            "1",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _1 },
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
                2,// up
                0,// down
                5,// left
                2,// right
                0,// front
                5,// back
            }
            ),
        new BrickConfig(
            "2",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
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
                1,// down
                1,// left
                6,// right
                3,// front
                6,// back
            }
            ),
        new BrickConfig(
            "3",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _0, _0 },
                    {_1, _1, _0 },
                    {_0, _1, _0 },
                },
                {
                    {_0, _0, _0 },
                    {_0, _1, _0 },
                    {_0, _0, _0 },
                },
            },
            new int[] // next
            {
                0,// up
                2,// down
                0,// left
                7,// right
                7,// front
                2,// back
            }
            ),
        new BrickConfig(
            "4",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _1, _0 },
                    {_0, _1, _1 },
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
                5,// up
                7,// down
                7,// left
                0,// right
                5,// front
                0,// back
            }
            ),
        new BrickConfig(
            "5",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _1, _0 },
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
                6,// up
                4,// down
                6,// left
                1,// right
                1,// front
                4,// back
            }
            ),
        new BrickConfig(
            "6",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _1, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _1, _0 },
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
                7,// up
                5,// down
                2,// left
                5,// right
                2,// front
                7,// back
            }
            ),
        new BrickConfig(
            "7",
            new bool[,,] {//x
                {   //z-  z   z+
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                    {_0, _0, _0 },//y
                },
                {
                    {_0, _1, _0 },
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
                4,// up
                6,// down
                3,// left
                4,// right
                6,// front
                3,// back
            }
            ),
    };
}
