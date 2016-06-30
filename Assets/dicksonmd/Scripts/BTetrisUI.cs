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
    public void moveFront()
    {
        game.tryMoveMovingPiece(new Vector3(0, 0, 1));
    }
    public void moveBack()
    {
        game.tryMoveMovingPiece(new Vector3(0, 0, -1));
    }
}
