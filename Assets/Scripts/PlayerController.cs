using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameManager gameManager;
    protected LaneHelper laneHelper;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        laneHelper = GameObject.Find("Game Manager").GetComponent<LaneHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontalInput * Time.deltaTime * speed;
        checkBounds();
        checkLane();
    }

    private void checkBounds()
    {
        if (transform.position.x < Constants.PlayerLeftBound)
        {
            transform.position = new Vector3(Constants.PlayerLeftBound, Constants.PlayerYPos, 0);
        }
        else if (transform.position.x > Constants.PlayerRightBound)
        {
            transform.position = new Vector3(Constants.PlayerRightBound, Constants.PlayerYPos, 0);
        }
    }

    private void checkLane()
    {
        gameManager.setCurrentLane(laneHelper.GetLaneNumberForPos(transform.position.x));
    }
}
