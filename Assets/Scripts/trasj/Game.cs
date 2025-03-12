using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    GameTimer gameTimer;

    private GameObject endPanel;
    private GameObject gamePanel;
    private Text endText;
    private Text timeText;

   

    private void Awake()
    {
        gameTimer = GameObject.FindFirstObjectByType<GameTimer>();
        endPanel = GameObject.Find("Canvas/EndPanel");
        gamePanel = GameObject.Find("Canvas/GamePanel");
        endText = GameObject.Find("Canvas/EndPanel/EndText").GetComponent<Text>();
        timeText = GameObject.Find("Canvas/EndPanel/TimeText").GetComponent<Text>();
    }

    private void Start()
    {
        endPanel.SetActive(false);
    }

    public void OnOpenLockerEvent()
    {
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        endText.text = "Вы взломали замок";
        timeText.text = $"Время: {gameTimer.currentTime}";
    }

    public void OnTimeOutEvent()
    {
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        endText.text = "Время вышло";
        timeText.text = $"Время: {gameTimer.levelTime}";
    }

}

