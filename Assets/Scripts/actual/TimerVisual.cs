using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerVisual : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    [SerializeField] private Timer _timer;



    public void UpdateTimerVisual()
    {
        _timerText.text = $"Время: {GetFormattedTime(_timer.GetTime())}";
    }



    private string GetFormattedTime(float time)
    {
        return Mathf.Round(time).ToString();
    }
}
