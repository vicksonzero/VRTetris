using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class TetrisField {

    public int width = 5;   // x
    public int depth = 6;   // z
    public int height = 8;  // y
    public bool[,,] field;
    public BTetrisGrid tetrisGrid;

    /// <summary>
    /// Creates a tetris field with x, z, y sizes
    /// </summary>
    /// <param name="width"></param>
    /// <param name="depth"></param>
    /// <param name="height"></param>
    public TetrisField(int width, int depth, int height)
    {
        this.width = width;
        this.depth = depth;
        this.height = height;
        field = new bool[height, depth, width];
    }

    public void setBit(int x, int y, int z, bool val)
    {
        if (x >= field.GetLength(2) ||
            y >= field.GetLength(0) ||
            z >= field.GetLength(1) ||
            false
            )
        {
            return;
        }
        field[y, z, x] = val;
        tetrisGrid.setBit(x, y, z, val);
    }

    public bool getBit(int x, int y, int z)
    {
        if (x >= field.GetLength(2) ||
            y >= field.GetLength(0) || 
            z >= field.GetLength(1) || 
            false
            )
        {
            return false;
        }
        return field[y, z, x];
    }

    public void setTetrimino(BTetrisTransform tetrimino, bool val)
    {
        tetrimino.toCoordArray().ForEach(block =>
        {
            setBit((int)block.x, (int)block.y, (int)block.z, val);
        });
    }

    /// <summary>
    /// whether all blocks on level y is occupied. can call clearLine() later
    /// </summary>
    /// <param name="y">level index. starts from 0</param>
    /// <returns></returns>
    public bool levelIsFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                if (getBit(x, y, z) == false) return false;
            }
        }
        return true;
    }

    public List<int> getFullLevels()
    {
        List<int> result = new List<int>();
        for (int j = 0; j < this.height; j++)
        {
            if (this.levelIsFull(j))
            {
                result.Add(j);
            }
        }
        return result;
    }

    /// <summary>
    /// clear the line y, delete all the blocks and set this layer to zero
    /// </summary>
    /// <param name="y">level index. starts from 0</param>
    public void clearLine(int y)
    {
        
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                setBit(x, y, z, false);
            }
        }
    }

    public void clearLines(List<int> lines)
    {
        lines.Sort((i1, i2) => i2.CompareTo(i1));
        lines.ForEach((line) =>
        {
            this.clearLine(line);
            dropLinesAbove(line);
        });
    }

    /// <summary>
    /// move all blocks one step downward, but not level y
    /// </summary>
    /// <param name="y">the level , and below, to exclude. starts from 0</param>
    public void dropLinesAbove(int y)
    {
        for (int _y = y+1; _y < height; _y++)
        {
            int destY = _y - 1;
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < depth; z++)
                {
                    // copy this box to next
                    setBit(x, destY, z, getBit(x, _y, z));

                    // clear this box
                    setBit(x, _y, z, false);
                }
            }
        }
    }

    public bool collides(BTetrisTransform tetrimino)
    {
        return this.collides(tetrimino.toCoordArray());
    }

    public bool collides(List<Vector3> points)
    {
        return points.Any(
            point => {
                //Debug.Log(point);
                return getBit((int)point.x, (int)point.y, (int)point.z);
            }
            );
    }
    public bool pointInField(Vector3 point)
    {
        return (
            point.x >= 0 && point.x < this.width &&
            point.y >= 0 && point.y < this.height &&
            point.z >= 0 && point.z < this.depth &&
            true);
    }
}
