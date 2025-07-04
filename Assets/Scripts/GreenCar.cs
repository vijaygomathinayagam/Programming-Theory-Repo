using UnityEngine;

public class GreenCar : CarMovement
{
  protected override void handleMovement()
  {
    if (laneHelper.GetLaneNumberForPos(transform.position.x) == gameManager.currentLane)
    {
      laneHelper.CheckAndChangeToRandomNearestLane(this.gameObject);
    }
  }
}
