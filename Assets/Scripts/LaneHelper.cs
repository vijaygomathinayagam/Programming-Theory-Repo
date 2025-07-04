using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class LaneHelper : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public int GetLaneNumberForPos(float xPos)
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

    public void CheckAndChangeToRandomNearestLane(GameObject carObject)
    {
        if (Constants.LaneSeperatorXPosArr.Length == 0)
        {
            return;
        }

        int carLane = GetLaneNumberForPos(carObject.transform.position.x);
        if (carLane == 1)
        {
            CheckAndChangeGameObjectToLane(carObject, 2);
        }
        else if (carLane == Constants.LaneSeperatorXPosArr.Length + 1)
        {
            CheckAndChangeGameObjectToLane(carObject, carLane - 1);
        }
        else
        {
            if (!CheckAndChangeGameObjectToLane(carObject, carLane - 1))
            {
                CheckAndChangeGameObjectToLane(carObject, carLane + 1);
            }
        }
    }

    public bool CheckAndChangeGameObjectToLane(GameObject carObject, int lane)
    {
        GameObject[] carObjects = GameObject.FindGameObjectsWithTag(Constants.CarTag);
        foreach (GameObject otherCarObject in carObjects)
        {
            if (otherCarObject == carObject)
            {
                continue;
            }
            if (GetLaneNumberForPos(otherCarObject.transform.position.x) == lane && isZAxisColliding(otherCarObject, carObject))
            {
                return false;
            }
        }
        StartCoroutine(changeGameObjectToLane(carObject, lane));
        return true;
    }

    private bool isZAxisColliding(GameObject carObject1, GameObject carObject2)
    {
        float carObject1FrontZPos = carObject1.transform.position.z + carObject1.GetComponent<BoxCollider>().size.z / 2;
        float carObject1RearZPos = carObject1.transform.position.z - carObject1.GetComponent<BoxCollider>().size.z / 2;
        float carObject2FrontZPos = carObject2.transform.position.z + carObject2.GetComponent<BoxCollider>().size.z / 2;
        float carObject2RearZPos = carObject2.transform.position.z - carObject2.GetComponent<BoxCollider>().size.z / 2;

        return (carObject1FrontZPos <= carObject2FrontZPos && carObject1FrontZPos >= carObject2RearZPos)
            || (carObject1RearZPos <= carObject2FrontZPos && carObject1RearZPos >= carObject2RearZPos);
    }

    private IEnumerator changeGameObjectToLane(GameObject carObject2, int lane)
    {
        float waitTime = Constants.ChangeLaneTime / Constants.ChangeLaneSteps;
        float changeLaneDistance = Mathf.Abs(Constants.CarsSpawnXPosArr[lane - 1] - carObject2.transform.position.x);

        Vehicle car2Vehicle = carObject2.GetComponent<Vehicle>();
        for (int i = 0; i < Constants.ChangeLaneSteps; i++)
        {
            if (!gameManager.isGameActive)
            {
                break;
            }
            yield return new WaitForSeconds(waitTime);
            if (carObject2.transform.position.x > Constants.CarsSpawnXPosArr[lane - 1])
            {
                carObject2.transform.position += new Vector3(-(changeLaneDistance / Constants.ChangeLaneSteps), 0, 0);
                car2Vehicle.ShowLeftIndicator();
            }
            else
            {
                carObject2.transform.position += new Vector3(changeLaneDistance / Constants.ChangeLaneSteps, 0, 0);
                car2Vehicle.ShowLeftIndicator();
            }
        }
        car2Vehicle.TurnOffBothIndicator();
    }
}
