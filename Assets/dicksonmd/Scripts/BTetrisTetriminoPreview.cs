using UnityEngine;
using System.Collections;
using System.Linq;

public class BTetrisTetriminoPreview : BTetrisGame {

    public int startShape = 0;
    public string[] forceBricks;

    private int forceBricksProgress = 0;

    public override BTetrisTransform getNextBrick()
    {
        forceBricksProgress = forceBricksProgress % forceBricks.Length;
        var configName = forceBricks[forceBricksProgress++];
        print(configName);
        var newBrick = this.builder.createBrick(configName, new Vector3(width / 2, height, depth / 2));

        var shapeIndex = Mathf.Min(startShape, newBrick.tetriminoConfig.config.Length-1);
        newBrick.setRotation(shapeIndex);

        return newBrick;
    }
}
