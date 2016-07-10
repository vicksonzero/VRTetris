using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class BTetrisUI : MonoBehaviour {

    public BTetrisGame game;
    public Transform moveArrowsGroup; 
    public Transform rotateArrowsGroup; 
    public Transform syncRotationTransform;
    public Camera uiCamera;
    public Transform tetrisStage;
    public Text label;

    public TetriminoConfig.RotationType[] tumbleTypes = new TetriminoConfig.RotationType[]
    {
        TetriminoConfig.RotationType.left,
        TetriminoConfig.RotationType.back,
        TetriminoConfig.RotationType.right,
        TetriminoConfig.RotationType.forward
    };
    private static float[] angleStops;
    private static float angleOffset;
    void Awake()
    {
        if (angleStops == null)
        {
            print("init angle stops");
            angleStops = new float[4];
            var field = game.field;
            angleOffset = Mathf.Rad2Deg * Mathf.Atan2((1.0f * field.depth / 2), (1.0f * field.width / 2));
            //print(angleOffset);
            //print(90 - angleOffset);
            angleStops[0] = 2 * angleOffset;
            angleStops[1] = angleStops[0] + 2 * (90 - angleOffset);
            angleStops[2] = angleStops[1] + 2 * angleOffset;
            angleStops[3] = angleStops[2] + 2 * (90 - angleOffset);
            //angleStops.ToList().ForEach(angle => { print(angle); });
        }
    }

    public void moveUp()
    {
        //game.tryMoveMovingPiece(new Vector3(0, 1, 0));
    }
    public void moveDown()
    {
        game.tryMoveMovingPiece(new Vector3(0, -1, 0));
    }
    public void moveLeft()
    {
        game.tryMoveMovingPiece(new Vector3(-1, 0, 0));
    }
    public void moveRight()
    {
        game.tryMoveMovingPiece(new Vector3(1, 0, 0));
    }
    public void moveforward()
    {
        game.tryMoveMovingPiece(new Vector3(0, 0, 1));
    }
    public void moveBack()
    {
        game.tryMoveMovingPiece(new Vector3(0, 0, -1));
    }
    public void rotateUp()
    {
        game.tryRotateMovingPiece(TetriminoConfig.RotationType.up);
    }
    public void rotateDown()
    {
        game.tryRotateMovingPiece(TetriminoConfig.RotationType.down);
    }
    public void rotateLeft()
    {
        game.tryRotateMovingPiece(TetriminoConfig.RotationType.left);
    }
    public void rotateRight()
    {
        game.tryRotateMovingPiece(TetriminoConfig.RotationType.right);
    }
    public void rotateforward()
    {
        game.tryRotateMovingPiece(TetriminoConfig.RotationType.forward);
    }
    public void rotateBack()
    {
        game.tryRotateMovingPiece(TetriminoConfig.RotationType.back);
    }
    public void rotateTumble()
    {
        var relativePos = this.tetrisStage.InverseTransformVector(this.tetrisStage.position - this.uiCamera.transform.position);
        var relativePos2d = new Vector2(-relativePos.x, relativePos.z);
        var lineAngle = Vector2.Angle(relativePos2d, new Vector2(0, 1)) + angleOffset;
        label.text = "" + relativePos2d.x+", "+ relativePos2d.y + " + " + lineAngle;
        if (lineAngle < angleStops[0])
        {
            game.tryRotateMovingPiece(TetriminoConfig.RotationType.left);
        }else if (lineAngle < angleStops[1])
        {
            game.tryRotateMovingPiece(TetriminoConfig.RotationType.back);
        }
        else if (lineAngle < angleStops[2])
        {
            game.tryRotateMovingPiece(TetriminoConfig.RotationType.right);
        }
        else
        {
            game.tryRotateMovingPiece(TetriminoConfig.RotationType.forward);
        }
    }

    void Update()
    {
        //moveArrowsGroup.rotation = Quaternion.AngleAxis(syncRotationTransform.eulerAngles.y, syncRotationTransform.up);
        //rotateArrowsGroup.rotation = Quaternion.AngleAxis(syncRotationTransform.eulerAngles.y, syncRotationTransform.up);
    }

}
