using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject gameOverPannel;
    public TextMeshProUGUI swordLeft;
    public TextMeshProUGUI point;
    public int swordCount;
    public int score;
    public Log log;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InitCount();
        score = 0;
        point.text = score.ToString();
       
    }
    void Update()
    {
        if (swordCount == 0)
        {
            log.LogChange();
            score++;
            point.text = score.ToString();
            InitCount();
        }
    }
    private void InitCount()
    {
        swordCount = Random.Range(1, 15);
        swordLeft.text = swordCount.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SwordReels");
    }
}
