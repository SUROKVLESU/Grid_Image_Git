using UnityEngine;

public class CubicKangeFilled
{
    public int LeftX;
    public int LeftY;
    public int RightX;
    public int RightY;
    public CubicKangeFilled(Vector2Int upperLeft, Vector2Int lowerRight)
    {
        LeftX = upperLeft.x;
        LeftY = upperLeft.y;
        RightX = lowerRight.x;
        RightY = lowerRight.y;
    }
}
