using UnityEngine;

public class LaneHelper : MonoBehaviour
{
    public static int GetLaneNumberForPos(float xPos)
    {
        for (int i = 0; i < Constants.LaneSeperatorXPosArr.Length; i++)
        {
            if (xPos <= Constants.LaneSeperatorXPosArr[i])
            {
                return i + 1;
            }
        }
        return Constants.LaneSeperatorXPosArr.Length + 1;
    }
}
