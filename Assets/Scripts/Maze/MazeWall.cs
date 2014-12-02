using UnityEngine;
using System.Collections;

public class MazeWall : MazeCellEdge
{
    #region PublicVariables
    public Transform wall;
    #endregion

    #region PrivateVariables

    #endregion

    #region PublicMethods
    public override void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        base.Initialize(cell, otherCell, direction);
        wall.GetComponent<Renderer>().material = cell.room.settings.wallMaterial;
    }
    #endregion

    #region PrivateMethods
    #endregion


    
	
}
