using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject LaneSeperatorPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("generateLanes", Constants.LaneGenerateDelay, Constants.LaneGenerateInterval);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateLanes()
    {

        for (int i = 0; i < Constants.LaneSeperatorXPosArr.Length; i++)
        {
            Vector3 laneSeparatorPosition = new Vector3(Constants.LaneSeperatorXPosArr[i], Constants.LaneSeperatorYPos,
                Constants.LaneSeperatorZPos);

            Instantiate(LaneSeperatorPrefab, laneSeparatorPosition, LaneSeperatorPrefab.transform.rotation);
        }
    }
}
