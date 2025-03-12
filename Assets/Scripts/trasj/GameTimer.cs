using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Text timerText;
    public float levelTime { get; private set; }
    public float currentTime { get; private set; }

    public delegate void TimeOut();
    public TimeOut timeOutEvent;

    private void Awake()
    {
        levelTime = 60;
        currentTime = 60;
        timerText = GameObject.Find("Canvas/GamePanel/Timer/Text").GetComponent<Text>();
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = Mathf.Round(currentTime).ToString();
        }
        else
        {
            timeOutEvent();
        }
    }

    //public string FormateTime(float time)
    //{
    //    // 00:00
    //    string timeString = time.ToString();
    //    float minutes = Mathf.Round(time / 60);
    //    float seconds;

    //    return time;
    //}

}
