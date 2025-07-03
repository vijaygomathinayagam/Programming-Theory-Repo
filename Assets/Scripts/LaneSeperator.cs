using UnityEngine;

public class LaneSeperator : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < Constants.LaneSeperatorZLowerBound)
        {
            Destroy(gameObject);
            return;
        }
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
