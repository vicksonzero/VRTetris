using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BTetrisGrid : MonoBehaviour {
    

    public Transform columnPrefab;
    public Transform columnAltPrefab;
    public Transform transformGroup;

    private LineRenderer[] lines;

    private BTetrisTransform[,,] fieldVisual;
    public BTetrisTransform cubePrefab;
    public Transform cubeGroup;


    // Use this for initialization
    void Start ()
    {
        var _constants = BGameConstants.getInstance();
        fieldVisual = new BTetrisTransform[_constants.height, _constants.depth, _constants.width];
        constructColumns();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void constructColumns()
    {
        var _constants = BGameConstants.getInstance();
        bool alt = false;
        for (int x = 0; x < _constants.width; x++)
        {
            alt = !alt;
            for (int z = 0; z < _constants.depth; z++)
            {
                constructColumn(x, z, _constants.height, (alt? columnAltPrefab : columnPrefab));
                alt = !alt;
            }
        }
    }

    void constructColumn(int x, int z, int height, Transform columnPrefab)
    {
        
        Transform column = Instantiate(columnPrefab) as Transform;
        column.localScale = new Vector3(1, height, 1);
        column.SetParent(transformGroup, false);
        column.localPosition = new Vector3(x, height / 2, z);
    }

    public void setBit(int x, int y, int z, bool val)
    {

        if (val)
        {
            fieldVisual[y, z, x] = Object.Instantiate(cubePrefab);
            fieldVisual[y, z, x].transform.SetParent(cubeGroup, false);
            fieldVisual[y, z, x].transform.localPosition = new Vector3(x, y, z);
        }
        else
        {
            if (fieldVisual[y, z, x])
            {
                Object.Destroy(fieldVisual[y, z, x].gameObject);
                fieldVisual[y, z, x] = null;
            }
        }
    }
}
