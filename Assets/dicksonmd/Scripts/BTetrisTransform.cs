using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public struct Bound
{
    public int left;
    public int right;
    public int up;
    public int down;
    public int front;
    public int back;
    public override string ToString()
    {
        return "{"
            + left+", "
            + right + ", "
            + up + ", "
            + down + ", "
            + front + ", "
            + back
            +"}";
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

    private Quaternion _rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

    public Quaternion rotation
    {
        get { return _rotation; }
        set { _rotation = value; }
    }


    public List<BTetrisTransform> children = new List<BTetrisTransform>();
    public BTetrisTransform parent;

    public Vector3 toScaledLocalPosition()
    {
        var pos = this.position;
        return new Vector3(pos.x * BTetrisGame.cellWidth, pos.y * BTetrisGame.cellHeight, pos.z * BTetrisGame.cellDepth);
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
            bound.front = Mathf.Min(bound.front, (int)child.position.z);
            bound.back = Mathf.Max(bound.back, (int)child.position.z);
        }
        bound.left += (int)this.position.x;
        bound.right += (int)this.position.x;
        bound.up += (int)this.position.y;
        bound.down += (int)this.position.y;
        bound.front += (int)this.position.z;
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
            result.Add(this.position);
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

}
