using UnityEngine;

public class RedCar : CarMovement
{
  protected override void handleMovement()
  {
    int carLane = laneHelper.GetLaneNumberForPos(transform.position.x);
    int playerCarLane = laneHelper.GetLaneNumberForPos(player.transform.position.x);
    if (Mathf.Abs(carLane - playerCarLane) == 1)
    { 
      laneHelper.CheckAndChangeGameObjectToLane(this.gameObject, playerCarLane);
    }
  }
}
