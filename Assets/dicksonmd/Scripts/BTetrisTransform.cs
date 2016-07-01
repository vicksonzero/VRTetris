using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public struct Bound
{
    public int left;
    public int right;
    public int up;
    public int down;
    public int forward;
    public int back;
    public override string ToString()
    {
        return "{"
            + "L" + left + ", "
            + "R" + right + ", "
            + "U" + up + ", "
            + "D" + down + ", "
            + "F" + forward + ", "
            + "B" + back
            + "}";
    }
};
public class BTetrisTransform : MonoBehaviour {

    public bool showBounds = false;

    private Vector3 _position = Vector3.zero;

    public Vector3 position
    {
        get { return _position; }
        set { _position = value; updateTransform(); }
    }

    public List<BTetrisTransform> children = new List<BTetrisTransform>();
    public BTetrisTransform parent;

    [HideInInspector]
    public TetriminoConfig tetriminoConfig = Tetri1Dot.get();
    [HideInInspector]
    public BTetrisTransform cubePrefab;

    private int _shapeID = 0;

    public int shapeID
    {
        get { return _shapeID; }
        set { _shapeID = value; this.updateShape(); }
    }
    private static BTetri1DotPool tetri1DotPool;

    public Vector3 toScaledLocalPosition()
    {
        var pos = this.position;
        return new Vector3(pos.x, pos.y, pos.z);
    }

    public Bound getBound()
    {
        var bound = new Bound();
        foreach (var child in children)
        {
            bound.left = Mathf.Min(bound.left, (int)child.position.x);
            bound.right = Mathf.Max(bound.right, (int)child.position.x);
            bound.up = Mathf.Max(bound.up, (int)child.position.y);
            bound.down = Mathf.Min(bound.down, (int)child.position.y);
            bound.forward = Mathf.Min(bound.forward, (int)child.position.z);
            print(child.position);
            bound.back = Mathf.Max(bound.back, (int)child.position.z);
        }
        bound.left += (int)this.position.x;
        bound.right += (int)this.position.x;
        bound.up += (int)this.position.y;
        bound.down += (int)this.position.y;
        bound.forward += (int)this.position.z;
        bound.back += (int)this.position.z;
        return bound;
    }

    public List<Vector3> toCoordArray()
    {
        var result = new List<Vector3>();
        if (children.Count > 0)
        {
            children.ForEach(child =>
            {
                var childResult = child.toCoordArray();
                childResult = childResult.Select(res =>
                {
                    return res + this.position;
                }).ToList();
                result.AddRange(childResult);
            });
        }
        else
        {
            result.Add(this.position - this.tetriminoConfig.center);
        }
        return result;
    }

    /// <summary>
    /// gets a component of position according to a vector.
    /// returns the larger one if multiple dimensions are supplied
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public int positionFiltered(Vector3 direction)
    {
        int result = 0;
        result = Mathf.Max(result, (int)(direction.normalized.x * this.position.x));
        result = Mathf.Max(result, (int)(direction.normalized.y * this.position.y));
        result = Mathf.Max(result, (int)(direction.normalized.z * this.position.z));
        return result;
    }

    public int most(Vector3 direction)
    {
        int most = this.positionFiltered(direction);
        foreach (var child in children)
        {
            var m = child.most(direction);
            if (m > most)
            {
                most = m;
            }
        }
        return most;
    }

    private void updateTransform()
    {
        if (this.transform != null)
        {
            this.transform.localPosition = toScaledLocalPosition();
        }
    }

    public void move(Vector3 direction)
    {
        this.position += direction;
    }

    public BTetrisTransform translate(Vector3 moveVector)
    {
        this.position = this.position + moveVector;
        return this;
    }

    /// <summary>
    /// rotates this tetrimino 90 degrees to a rotationVector
    /// </summary>
    /// <param name="rotationVector">direction to rotate. use right hand screw rule. relative to tetriminoGroup</param>
    /// <returns>chainable self</returns>
    public BTetrisTransform rotate(Vector3 rotationVector)
    {
        int index = BTetrisTransform.RotationVectorToInt(rotationVector);
        this.rotate(index);
        return this;
    }

    /// <summary>
    /// rotates this tetrimino 90 degrees to a rotationVector
    /// </summary>
    /// <param name="rotationType">direction to rotate. use right hand screw rule. relative to tetriminoGroup [0-5]</param>
    /// <returns>chainable self</returns>
    public BTetrisTransform rotate(int rotationType)
    {
        int nextConfig = this.tetriminoConfig.config[this._shapeID].nextConfig[rotationType];
        this.setRotation(nextConfig);
        return this;
    }

    /// <summary>
    /// sets this tetrimino to a specified form
    /// </summary>
    /// <param name="index">array index of the shape, see the class TetriminoConfig</param>
    /// <returns>chainable self</returns>
    public BTetrisTransform setRotation(int index)
    {
        this.shapeID = index;
        return this;
    }

    public BTetrisTransform updateShape()
    {
        this.children.ForEach(child =>
        {
            tetri1DotPool.DisposeAndPush(child);
        });
        this.children.Clear();

        var config = this.tetriminoConfig.config[this._shapeID];
        var I = config.config.GetLength(0);
        var J = config.config.GetLength(1);
        var K = config.config.GetLength(2);
        var orig = this.tetriminoConfig.center;
        for (int i = 0; i < I; i++)
        {
            for (int j = 0; j < J; j++)
            {
                for (int k = 0; k < K; k++)
                {
                    if (config.config[i, j, k])
                    {
                        BTetrisTransform cube_go = tetri1DotPool.Pop();
                        cube_go.transform.SetParent(this.transform, false);
                        cube_go.position = new Vector3(i, j, k) - orig;

                        // HACK: updates rotation here to override remaining value from pool. may have a better implementation?
                        cube_go.transform.localRotation = this.transform.localRotation;
                        this.children.Add(cube_go);
                        cube_go.parent = this;
                    }
                }
            }
        }
        return this;
    }
    static int RotationVectorToInt(Vector3 rot)
    {
        if (rot.normalized == Vector3.up) return 0;
        if (rot.normalized == Vector3.down) return 1;
        if (rot.normalized == Vector3.left) return 2;
        if (rot.normalized == Vector3.right) return 3;
        if (rot.normalized == Vector3.forward) return 4;
        if (rot.normalized == Vector3.back) return 5;
        return 0;
    }

    void Update()
    {
        if (showBounds)
        {
            print(positionFiltered(new Vector3(1, 0, 0)));
            print(positionFiltered(new Vector3(-1, 0, 0)));
            print(positionFiltered(new Vector3(0, 1, 0)));
            print(positionFiltered(new Vector3(0, -1, 0)));
            print(positionFiltered(new Vector3(0, 0, 1)));
            print(positionFiltered(new Vector3(0, 0, -1)));

            showBounds = false;
        }
    }

    void Awake()
    {
        tetri1DotPool = GameObject.Find("TetrisPools").GetComponent<BTetri1DotPool>();
    }

    public void Dispose()
    {
        // HACK: only considering 1 level shape and 1 level dots

        // return children
        this.children.ForEach(child =>
        {
            tetri1DotPool.DisposeAndPush(child);
        });
        this.children.Clear();
        this._position = Vector3.zero;
        this.transform.parent = null;
    }

}
