using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject redCarPrefab;
    [SerializeField]
    private GameObject blueCarPrefab;
    [SerializeField]
    private GameObject greenCarPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnASetOfCars", Constants.SpawnCarsDelay, Constants.SpawnCarsInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnASetOfCars()
    {
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0: spawnSingleCar(); break;
            case 1: spawnTwoCars(); break;
            case 2: spawnThreeCars(); break;
        }
    }

    private void spawnSingleCar()
    {
        Vector3 carSpawnPos = new Vector3(getRandomXPos(), redCarPrefab.transform.position.y,
            Constants.SpawnCarZPos);
        GameObject carPrefab = getRandomPrefab(); 
        Instantiate(carPrefab, carSpawnPos, carPrefab.transform.rotation);
    }

    private void spawnTwoCars()
    {
        int twoCarsSpawnType = Random.Range(0, 3);
        switch (twoCarsSpawnType)
        {
            case 0:
                spawnTwoCarsWithSelectedLanes(0, 1);
                break;
            case 1:
                spawnTwoCarsWithSelectedLanes(2, 3);
                break;
            case 2:
                spawnTwoCarsWithSelectedLanes(Random.Range(0, 2), Random.Range(2, 4));
                break;
        }
    }

    private void spawnTwoCarsWithSelectedLanes(int lane1, int lane2)
    {
        GameObject carPrefab1 = getRandomPrefab();
        GameObject carPrefab2 = getRandomPrefab();
        Vector3 carSpawnPos1 = new Vector3(Constants.CarsSpawnXPosArr[lane1], redCarPrefab.transform.position.y,
            Constants.SpawnCarZPos);
        Vector3 carSpawnPos2 = new Vector3(Constants.CarsSpawnXPosArr[lane2], redCarPrefab.transform.position.y,
            Constants.SpawnCarZPos);
        Instantiate(carPrefab1, carSpawnPos1, carPrefab1.transform.rotation);
        Instantiate(carPrefab2, carSpawnPos2, carPrefab2.transform.rotation);
    }

    private void spawnThreeCars()
    {
        int randomIndex = Random.Range(0, Constants.CarsSpawnXPosArr.Length);
        for (int i = 0; i < Constants.CarsSpawnXPosArr.Length; i++)
        {
            if (i == randomIndex)
            {
                continue;
            }
            Vector3 carSpawnPos = new Vector3(Constants.CarsSpawnXPosArr[i], redCarPrefab.transform.position.y,
            Constants.SpawnCarZPos);
            GameObject carPrefab = getRandomPrefab();
            Instantiate(carPrefab, carSpawnPos, carPrefab.transform.rotation);
        }
    }

    private float getRandomXPos()
    {
        int randomIndex = Random.Range(0, Constants.CarsSpawnXPosArr.Length);
        return Constants.CarsSpawnXPosArr[randomIndex];
    }

    private GameObject getRandomPrefab()
    {
        GameObject[] prefabArr = { redCarPrefab, blueCarPrefab, greenCarPrefab };
        int randomIndex = Random.Range(0, prefabArr.Length);
        return prefabArr[randomIndex];
    }
}
