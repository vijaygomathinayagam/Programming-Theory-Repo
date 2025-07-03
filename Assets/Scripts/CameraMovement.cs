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
        Vector3 cameraPos = new(player.transform.position.x, 4.2f, -7.8f);
        transform.position = cameraPos;
    }
}
