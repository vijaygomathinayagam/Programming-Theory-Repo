using UnityEngine;

public class CarMovement : Vehicle
{
    private float reducedCarSpeedFromAmbulance;
    private bool isMovementHandled;
    protected LaneHelper laneHelper;
    protected GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reducedCarSpeedFromAmbulance = Random.Range(Constants.CarSpeedLowerReduction, Constants.CarSpeedUpperReduction);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        laneHelper = GameObject.Find("Game Manager").GetComponent<LaneHelper>();
        player = GameObject.Find("Player");
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (transform.position.z < Constants.CarSeperatorZLowerBound)
            {
                gameManager.UpdateAndDisplayScore(Constants.CarCrossScore);
                Destroy(gameObject);
                return;
            }
            transform.position += Vector3.back * reducedCarSpeedFromAmbulance * Time.deltaTime;
            checkAndHandleMovement();
        }
    }

    private void checkAndHandleMovement()
    {
        if (isMovementHandled)
        {
            return;
        }
        float distanceFromPlayer = transform.position.z - player.transform.position.z;
        if (distanceFromPlayer >= Constants.MovementHandleLimitEnd
            && distanceFromPlayer <= Constants.MovementHandleLimitStart)
        {
            isMovementHandled = true;
            handleMovement();
        }
    }

    protected virtual void handleMovement() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.UpdateAndDisplayGameover();
        }
    }
}
