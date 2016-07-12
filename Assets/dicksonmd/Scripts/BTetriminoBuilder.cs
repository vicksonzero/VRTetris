using UnityEngine;
using System.Collections.Generic;


public class BTetriminoBuilder : MonoBehaviour
{

    const bool _1 = true;
    const bool _0 = false;
    public BTetrisTransform cubePrefab;
    public BTetrisTransform basePrefab;
    public Material baseMaterial;
    public Transform tetriminoGroup;
    public Transform debugGroup;

    private Transform nextGroup;

    static SortedDictionary<string, TetriminoConfig> tetriminoConfigsByName;
    private static BTetri1DotPool tetri1DotPool;

    public static TetriminoConfig[] tetriminoConfigs;

    void Awake()
    {
        tetriminoConfigs = new TetriminoConfig[]{
            new Tetri4LL().initMaterial(baseMaterial),
            new Tetri4S().initMaterial(baseMaterial),
            new Tetri4I().initMaterial(baseMaterial),
            new Tetri8OO().initMaterial(baseMaterial),
            new Tetri4T().initMaterial(baseMaterial)
        };
        var tetriminoConfigsByName = new SortedDictionary<string, TetriminoConfig>();
        for (int i = 0; i < tetriminoConfigs.Length; i++)
        {

            tetriminoConfigsByName.Add(tetriminoConfigs[i].name, tetriminoConfigs[i]);
        }
        BTetriminoBuilder.tetriminoConfigsByName = tetriminoConfigsByName;
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
        return this.forGroup(debugGroup);
    }

    public BTetriminoBuilder forGroup(Transform gp)
    {
        this.nextGroup = gp;
        return this;
    }
    
    public TetriminoConfig randomBrickConfig()
    {
        var brickID = Random.Range(0, tetriminoConfigs.Length);
        return tetriminoConfigs[brickID];
    }

    /// <summary>
    /// creates a tetrimino and return its tetrimino behaviour
    /// </summary>
    /// <param name="config">Config defined in BTetriminoBuilder.cs</param>
    /// <param name="basePrefab"></param>
    /// <param name="cube"></param>
    /// <param name="startPos">starting position</param>
    /// <returns></returns>
    public BTetrisTransform createBrick(TetriminoConfig config, BTetrisTransform basePrefab, BTetrisTransform cube, Vector3 startPos)
    {
        BTetrisTransform result = MonoBehaviour.Instantiate(basePrefab.gameObject).GetComponent<BTetrisTransform>();
        result.cubePrefab = this.cubePrefab;
        result.tetriminoConfig = config;
        result.setRotation(0);
        result.name = "Tetrimino " + config.name;
        result.transform.SetParent(this.nextGroup, false);
        result.position = startPos - config.center;

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
        TetriminoConfig tetriminoConfig;
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
    public BTetrisTransform createBrick(TetriminoConfig config, Vector3 startPos)
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