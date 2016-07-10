using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region BrickConfig definition
public struct BrickConfig
{
    public string name;
    public bool[,,] config;
    public int[] nextConfig;
    public BrickConfig(string name, bool[,,] config, int[] nextConfig)
    {
        this.name = name;
        this.config = config;
        this.nextConfig = nextConfig;
    }
}
#endregion 
public abstract class TetriminoConfig
{
    public const bool _1 = true;
    public const bool _0 = false;

    public enum RotationType
    {
        up,
        down,
        left,
        right,
        forward,
        back,
        none
    }

    public string name;
    public Vector3 center;
    public BrickConfig[] config;
    public Color color;

    public List<Vector3> toPoints(int shapeID)
    {
        var result = new List<Vector3>();
        var config = this.config[shapeID];
        var I = config.config.GetLength(0);
        var J = config.config.GetLength(1);
        var K = config.config.GetLength(2);
        var orig = this.center;
        for (int i = 0; i < I; i++)
        {
            for (int j = 0; j < J; j++)
            {
                for (int k = 0; k < K; k++)
                {
                    if (config.config[i, j, k])
                    {
                        result.Add(new Vector3(i, j, k) - orig);
                    }
                }
            }
        }
        return result;
    }
}
