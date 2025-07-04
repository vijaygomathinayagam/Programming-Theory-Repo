using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        gameManager.setCurrentLane(LaneHelper.GetLaneNumberForPos(transform.position.x));
        Debug.Log(LaneHelper.GetLaneNumberForPos(transform.position.x));
    }
}
