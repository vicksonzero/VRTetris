using UnityEngine;
using System.Collections;
using System.Linq;

public class BTetrisGameTitle: BTetrisGame {

    [Header("Title screen")]
    public Transform backgroundTetriminoGroup;

    [Tooltip("In seconds")]
    public float changeBGInterval = 30;

    private string prevName = "";

    protected override void Awake() { }
    protected override IEnumerator tick()
    {
        yield return new WaitForSeconds(changeBGInterval);
        while (true)
        {
            Destroy(this.movingPiece.gameObject);
            this.movingPiece = getNextBrick();
            yield return new WaitForSeconds(changeBGInterval);
        }
    }

    public override BTetrisTransform getNextBrick()
    {
        TetriminoConfig randomBrick;
        do
        {
            randomBrick = builder.randomBrickConfig();

        } while (randomBrick.name == prevName);
        print(randomBrick.name);
        prevName = randomBrick.name;
        return builder.forGroup(backgroundTetriminoGroup).createBrick(randomBrick, new Vector3(0,0,0) + randomBrick.center);
    }
}
