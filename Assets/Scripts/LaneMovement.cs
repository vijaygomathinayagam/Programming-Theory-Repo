using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject LaneSeperatorPrefab;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("generateLanes", Constants.LaneGenerateDelay, Constants.LaneGenerateInterval);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateLanes()
    {
        if (gameManager.isGameActive) { 
            for (int i = 0; i < Constants.LaneSeperatorXPosArr.Length; i++)
            {
                Vector3 laneSeparatorPosition = new Vector3(Constants.LaneSeperatorXPosArr[i], Constants.LaneSeperatorYPos,
                    Constants.LaneSeperatorZPos);

                Instantiate(LaneSeperatorPrefab, laneSeparatorPosition, LaneSeperatorPrefab.transform.rotation);
            }
        }
    }
}
