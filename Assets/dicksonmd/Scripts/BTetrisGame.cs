using UnityEngine;
using System.Collections;
using System.Linq;

public class BTetrisGame : MonoBehaviour {

    public static int width = 6;   // x
    public static int height = 14;  // y
    public static int depth = 7;   // z

    public float tickInterval = 1;

    [HideInInspector]
    public BTetrisTransform movingPiece;

    private TetrisField field;
    public BTetriminoBuilder builder;
    public BTetrisGrid tetrisGrid;

    // control
    private bool canHori = true;
    private bool canVert = true;

    void Awake()
    {
        var _constants = BGameConstants.getInstance();
        field = new TetrisField(_constants.width, _constants.depth, _constants.height);
        field.tetrisGrid = tetrisGrid;
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(tick());
        this.movingPiece = this.getNextBrick();
    }
	
	// Update is called once per frame
	void Update () {

        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        if (canHori && hori > 0)
        {
            tryMoveMovingPiece(new Vector3(1, 0, 0));
            canHori = false;
        }
        if (canHori && hori < 0)
        {
            tryMoveMovingPiece(new Vector3(-1, 0, 0));
            canHori = false;
        }
        if (hori == 0)
        {
            canHori = true;
        }

        if (canVert && vert > 0)
        {
            tryMoveMovingPiece(new Vector3(0, 0, 1));
            canVert = false;
        }
        if (canVert && vert < 0)
        {
            tryMoveMovingPiece(new Vector3(0, 0, -1));
            canVert = false;
        }
        if (vert == 0)
        {
            canVert = true;
        }

    }

    IEnumerator tick()
    {
        while (true)
        {
            if (this.movingPiece)
            {
                // if reach bottom
                //print(this.movingPiece.position.y);
                //print(this.movingPiece.most(new Vector3(0, -1, 0)));
                if (this.movingPiece.position.y - this.movingPiece.most(new Vector3(0, -1, 0))==0)
                {
                    field.setTetrimino(this.movingPiece, true);
                    Destroy(this.movingPiece.gameObject);
                    this.movingPiece = getNextBrick();
                }
                // if cannot move down
                else
                {
                    if (!this.canMoveAgainstField(this.movingPiece,new Vector3(0, -1, 0)))
                    {
                        field.setTetrimino(this.movingPiece, true);
                        Destroy(this.movingPiece.gameObject);
                        this.movingPiece = getNextBrick();
                    }
                    else {
                        // move freely
                        this.movingPiece.move(new Vector3(0, -1, 0));
                    }
                }
                
            }
            yield return new WaitForSeconds(this.tickInterval);
        }
    }

    public virtual BTetrisTransform getNextBrick()
    {
        var _constants = BGameConstants.getInstance();
        return builder.createRandomBrick(new Vector3(_constants.width / 2, _constants.height, _constants.depth / 2));
    }

    public void tryMoveMovingPiece(Vector3 direction)
    {
        if (!canMoveWall(this.movingPiece, direction))
        {
            print("cannot move against wall");
            print(this.movingPiece.getBound().ToString());
            return;
        }
        if (!this.canMoveAgainstField(this.movingPiece, direction))
        {
            print("cannot move against field");
            return;
        }

        this.movingPiece.move(direction);

        //var bound = this.movingPiece.getBound();
        //print(bound.ToString());
    }

    public void tryRotateMovingPiece(int rotationVector)
    {
        this.movingPiece.rotate(rotationVector);
    }

    public void tryRotateMovingPiece(TetriminoConfig.RotationType rotationnEnum)
    {
        this.movingPiece.rotate((int)rotationnEnum);
    }

    bool canMoveAgainstField(BTetrisTransform tetrimino, Vector3 direction)
    {
        return this.field.collides(
            tetrimino.toCoordArray().Select(point => point + direction).ToList()
            ) == false;
    }
    bool canMoveWall(BTetrisTransform tetrimino, Vector3 direction)
    {
        var _constants = BGameConstants.getInstance();
        var d = direction.normalized;
        var bound = tetrimino.getBound();
        if (d.x > 0)
        {
            return bound.right < _constants.width - 1;
        }
        if (d.x < 0)
        {
            return bound.left > 0;
        }
        if (d.y > 0)
        {
            return bound.up < height-1;
        }
        if (d.y < 0)
        {
            return bound.down > 1;
        }
        if (d.z > 0)
        {
            return bound.back < depth-1;
        }
        if (d.z < 0)
        {
            return bound.forward > 0;
        }
        return true;
    }
}
