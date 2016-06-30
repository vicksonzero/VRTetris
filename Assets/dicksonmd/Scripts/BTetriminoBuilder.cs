using UnityEngine;
using System.Collections.Generic;


public class BTetriminoBuilder : MonoBehaviour
{

    const bool _1 = true;
    const bool _0 = false;
    public BTetrisTransform cubePrefab;
    public BTetrisTransform basePrefab;
    public Transform tetriminoGroup;
    public Transform debugGroup;

    private Transform nextGroup;

    static SortedDictionary<string, BrickConfig> tetriminoConfigsByName;
    public static BrickConfig[] tetriminoConfigs = new BrickConfig[]
    {
        new BrickConfig(
            "4S",
            new bool[,,] {
                { {_1, _1, _0 } },
                { {_0, _1, _1 } },
            },
            new int[] { }
        ),
        new BrickConfig(
            "4T",
            new bool[,,] {
                { {_0, _1, _0 } },
                { {_1, _1, _1 } },
            },
            new int[] { }
        ),
        new BrickConfig(
            "4LT",
            new bool[,,] {
                {
                    {_1, _1 },
                    {_0, _1 },
                },
                {
                    {_0, _1 },
                    {_0, _0 },
                },
            },
            new int[] { }
        ),
        new BrickConfig(
            "4LS",
            new bool[,,] {
                {
                    {_1, _1 },
                    {_0, _1 },
                },
                {
                    {_1, _0 },
                    {_0, _0 },
                },
            },
            new int[] { }
        ),
        new BrickConfig(
            "4LZ",
            new bool[,,] {
                {
                    {_1, _1 },
                    {_1, _0 },
                },
                {
                    {_0, _1 },
                    {_0, _0 },
                },
            },
            new int[] { }
        ),
    };

    void Awake()
    {
        tetriminoConfigsByName = new SortedDictionary<string, BrickConfig>();
        for (int i = 0; i < tetriminoConfigs.Length; i++)
        {
            tetriminoConfigsByName.Add(tetriminoConfigs[i].name, tetriminoConfigs[i]);
        }
    }

    void Start()
    {
        int startX = -1 * tetriminoConfigs.Length / 2 * 5;
        for (int i = 0; i < tetriminoConfigs.Length; i++)
        {
            var config = tetriminoConfigs[i];
            var newTetrimino = this.asDebug().createBrick(config, this.basePrefab, this.cubePrefab, new Vector3(startX + 5 * i, 0f, 0));

        }
        this.nextGroup = this.tetriminoGroup;
    }

    public BTetriminoBuilder asDebug()
    {
        return this.toGroup(debugGroup);
    }

    public BTetriminoBuilder toGroup(Transform gp)
    {
        this.nextGroup = gp;
        return this;
    }

    /// <summary>
    /// creates a tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="config">Config defined in BTetriminoBuilder.cs</param>
    /// <param name="basePrefab"></param>
    /// <param name="cube"></param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createBrick(BrickConfig config, BTetrisTransform basePrefab, BTetrisTransform cube, Vector3 startPos)
    {
        BTetrisTransform result = MonoBehaviour.Instantiate(basePrefab.gameObject).GetComponent<BTetrisTransform>();

        var I = config.config.GetLength(0);
        var J = config.config.GetLength(1);
        var K = config.config.GetLength(2);
        for (int i = 0; i < I; i++)
        {
            for (int j = 0; j < J; j++)
            {
                for (int k = 0; k < K; k++)
                {
                    if (config.config[i, j, k])
                    {
                        BTetrisTransform cube_go = MonoBehaviour.Instantiate(cube.gameObject).GetComponent<BTetrisTransform>();
                        cube_go.transform.SetParent(result.transform, false);
                        cube_go.position = new Vector3(i, j , k);
                        result.children.Add(cube_go);
                        cube_go.parent = result;
                    }

                }
            }
        }
        result.name = "Tetrimino " + config.name;
        result.transform.SetParent(this.nextGroup, false);
        result.position = startPos;

        this.nextGroup = this.tetriminoGroup;
        return result;
    }

    /// <summary>
    /// creates a tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="brickName">name of the brick</param>
    /// <param name="basePrefab"></param>
    /// <param name="cube"></param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createBrick(string brickName, BTetrisTransform basePrefab, BTetrisTransform cube, Vector3 startPos)
    {
        BrickConfig tetriminoConfig;
        tetriminoConfigsByName.TryGetValue(brickName, out tetriminoConfig);
        return createBrick(tetriminoConfig, basePrefab, cube, startPos);
    }
    /// <summary>
    /// creates a tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="brickName">name of the brick</param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createBrick(string brickName, Vector3 startPos)
    {
        return createBrick(brickName, this.basePrefab, this.cubePrefab, startPos);
    }

    /// <summary>
    /// creates a tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="config">Config defined in BTetriminoBuilder.cs</param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createBrick(BrickConfig config, Vector3 startPos)
    {
        return createBrick(config, this.basePrefab, this.cubePrefab, startPos);
    }
    /// <summary>
    /// creates a tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="brickID">id of a brick</param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createBrick(int brickID, Vector3 startPos)
    {
        return createBrick(tetriminoConfigs[brickID], this.basePrefab, this.cubePrefab, startPos);
    }
    /// <summary>
    /// creates a random tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="brickID">id of a brick</param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createRandomBrick(Vector3 startPos)
    {
        var brickID = Random.Range(0,tetriminoConfigs.Length);
        return createBrick(tetriminoConfigs[brickID], this.basePrefab, this.cubePrefab, startPos);
    }
}