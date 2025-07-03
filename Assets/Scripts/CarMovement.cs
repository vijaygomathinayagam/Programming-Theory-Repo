using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float reducedCarSpeedFromAmbulance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reducedCarSpeedFromAmbulance = Random.Range(Constants.CarSpeedLowerReduction, Constants.CarSpeedUpperReduction);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < Constants.CarSeperatorZLowerBound)
        {
            Destroy(gameObject);
            return;
        }
        transform.position += Vector3.back * reducedCarSpeedFromAmbulance * Time.deltaTime;
    }
}
