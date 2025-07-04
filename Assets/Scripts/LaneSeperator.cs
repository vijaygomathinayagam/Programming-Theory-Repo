using UnityEngine;

public class LaneSeperator : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float Speed => speed;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (transform.position.z < Constants.LaneSeperatorZLowerBound)
            {
                Destroy(gameObject);
                return;
            }
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }
}
