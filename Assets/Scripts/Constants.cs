using UnityEngine;
using UnityEngine.Android;

public class Constants : MonoBehaviour
{
    public static readonly int GameSceneOrder = 1;
    public static readonly float LaneSeperatorYPos = 0.1f;
    public static readonly float LaneSeperatorZPos = 150.0f;
    public static readonly float LaneSeperatorZLowerBound = -10.0f;
    public static readonly float[] LaneSeperatorXPosArr = { -6.515f, 0, 6.515f };
    public static readonly float MainCameraYPos = 4.2f;
    public static readonly float MainCameraZPos = -7.8f;
    public static readonly float LaneGenerateDelay = 0.0f;
    public static readonly float LaneGenerateInterval = .25f;
    public static readonly float SpawnCarsDelay = 3.0f;
    public static readonly float SpawnCarsInterval = 1.5f;
    public static readonly float SpawnCarZPos = 250.0f;
    public static readonly float CarSeperatorZLowerBound = -10.0f;
    public static readonly float CarSpeedUpperReduction = 150.0f;
    public static readonly float CarSpeedLowerReduction = 80.0f;
    public static readonly float PlayerLeftBound = -13.03f;
    public static readonly float PlayerRightBound = 13.03f;
    public static readonly float PlayerYPos = 0.156f;
    public static readonly float[] CarsSpawnXPosArr = { -10.66f, -3.48f, 2.7f, 10.3f };
}
