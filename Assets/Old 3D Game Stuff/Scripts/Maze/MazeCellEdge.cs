using UnityEngine;
using System.Collections;

public abstract class MazeCellEdge : MonoBehaviour
{
    #region PublicVariables
    public MazeCell cell, otherCell;
    public MazeDirection direction;
    #endregion

    #region PrivateVariables

    #endregion

    #region PublicMethods
    public virtual void OnPlayerEntered() { }
    public virtual void OnPlayerExited() { }
    public virtual void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        this.cell = cell;
        this.otherCell = otherCell;
        this.direction = direction;
        cell.SetEdge(direction, this);
        transform.parent = cell.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = direction.ToRotation();
    }
    #endregion

    #region PrivateMethods
    #endregion

}
