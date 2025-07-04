using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLane { get; private set; }
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        UpdateAndDisplayScore(0);
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
}
