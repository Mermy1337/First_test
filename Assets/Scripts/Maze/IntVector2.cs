using UnityEngine;
using System.Collections;

[System.Serializable]
public struct IntVector2
{
    #region PublicVariables

    public int x, z;

    public IntVector2(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
   
    #endregion


    #region PrivateVariables

    #endregion

    #region PublicMethods
    

    public static IntVector2 operator +(IntVector2 a, IntVector2 b)
    {
        a.x += b.x;
        a.z += b.z;
        return a;
    }
    #endregion

    #region PrivateMethods
    #endregion



    
}
