using UnityEngine;
using System.Collections;

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
        back
    }

    public string name;
    public Vector3 center;
    public BrickConfig[] config;
    public Color color;
    
}
