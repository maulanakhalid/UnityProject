using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText; // gunakan TextMeshProUGUI jika pakai TMP

    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
