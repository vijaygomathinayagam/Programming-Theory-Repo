using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = new(player.transform.position.x, Constants.MainCameraYPos, Constants.MainCameraZPos);
        transform.position = cameraPos;
    }
}
