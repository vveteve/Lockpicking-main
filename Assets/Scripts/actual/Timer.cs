using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTimeOver;

    private float _timeLeft;
    private bool _onPause = true; 



    public void UpdateTimer()
    {
        if (_onPause)
            return;


        _timeLeft -= 1 * Time.deltaTime;

        if (!IsTimeOver())
            return;


        _timeLeft = 0;
        StopTimer();
        _onTimeOver?.Invoke();
    }



    public void StopTimer()
    {
        _onPause = true;
    }

    public void StartTimer()
    {
        _onPause = false;
    }

    public bool IsTimeOver()
    {
        return _timeLeft <= 0;
    }

    public void SetTime(float time)
    {
        _timeLeft = time;
    }

    public float GetTime()
    {
        return _timeLeft;
    }
}
