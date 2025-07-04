using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameManager gameManager;
    protected LaneHelper laneHelper;
    [SerializeField]
    private MeshRenderer redLightFront;

    [SerializeField]
    private MeshRenderer redLightSide;

    [SerializeField]
    private MeshRenderer redLightRear;
    [SerializeField]
    private MeshRenderer whiteLight;
    [SerializeField]
    private MeshRenderer blueLightFront;
    [SerializeField]
    private MeshRenderer blueLightSide;
    [SerializeField]
    private MeshRenderer blueLightRear;
    [SerializeField]
    private Material redLightMaterial;
    [SerializeField]
    private Material blueLightMaterial;
    [SerializeField]
    private Material whiteLightMaterial;
    [SerializeField]
    private Material noLightMaterial;

    private List<Material> noLightMaterials = new List<Material>();
    private List<Material> redLightMaterials = new List<Material>();
    private List<Material> whiteLightMaterials = new List<Material>();
    private List<Material> blueLightMaterials = new List<Material>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        laneHelper = GameObject.Find("Game Manager").GetComponent<LaneHelper>();
        noLightMaterials.Add(noLightMaterial);
        redLightMaterials.Add(redLightMaterial);
        blueLightMaterials.Add(blueLightMaterial);
        whiteLightMaterials.Add(whiteLightMaterial);
        StartCoroutine(startSiren());
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

    private IEnumerator startSiren()
    {
        while (true)
        {
            turnOffSirenLight();
            redLightRear.SetMaterials(redLightMaterials);
            redLightSide.SetMaterials(redLightMaterials);
            redLightFront.SetMaterials(redLightMaterials);
            yield return new WaitForSeconds(Constants.SirenLightDuration);

            turnOffSirenLight();
            blueLightRear.SetMaterials(blueLightMaterials);
            blueLightFront.SetMaterials(blueLightMaterials);
            blueLightSide.SetMaterials(blueLightMaterials);
            whiteLight.SetMaterials(whiteLightMaterials);
            yield return new WaitForSeconds(Constants.SirenLightDuration);
        }
    }

    private void turnOffSirenLight()
    {
        redLightFront.SetMaterials(noLightMaterials);
        redLightSide.SetMaterials(noLightMaterials);
        redLightRear.SetMaterials(noLightMaterials);
        whiteLight.SetMaterials(noLightMaterials);
        blueLightFront.SetMaterials(noLightMaterials);
        blueLightSide.SetMaterials(noLightMaterials);
        blueLightRear.SetMaterials(noLightMaterials);
    }
}
