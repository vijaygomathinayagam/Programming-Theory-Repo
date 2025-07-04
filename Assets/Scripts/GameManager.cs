using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLane { get; private set; }
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject gameover;
    private int score;
    public bool isGameActive { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        UpdateAndDisplayScore(0);
        isGameActive = true;
        Camera.main.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCurrentLane(int lane)
    {
        currentLane = lane;
    }

    public void UpdateAndDisplayScore(int value)
    {
        score += value;
        scoreText.text = $"Score: {score}";
    }

    public void UpdateAndDisplayGameover()
    {
        isGameActive = false;
        GameObject.Find("Player").GetComponent<PlayerController>().GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<AudioSource>().Stop();
        gameover.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(Constants.MenuSceneOrder);
    }
}
