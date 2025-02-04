using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeUiManager : MonoBehaviour
{
    public static SnakeUiManager instance;
    public TextMeshProUGUI scoreTmp;
    public GameObject gameOverPannel;
    public int score;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreTmp.text = score.ToString();
    }
    public void UpdateScore(int amount)
    {
        score += amount;
        scoreTmp.text = score.ToString();
    }
    public void GameOver()
    {
        gameOverPannel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("SnakeGame");
    }
}
