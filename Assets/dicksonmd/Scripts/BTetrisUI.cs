using UnityEngine;
using System.Collections;

public class BTetrisUI : MonoBehaviour {

    public BTetrisGame game;

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

}
