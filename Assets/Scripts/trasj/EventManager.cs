using UnityEngine;


public class EventManager : MonoBehaviour
{
    private OnClickToolButtons onClickToolButtons;
    private Locker locker;
    private GameTimer gameTimer;
    private Game game;

    private void Awake()
    {
        onClickToolButtons = GameObject.FindFirstObjectByType<OnClickToolButtons>();
        locker = GameObject.FindFirstObjectByType<Locker>();
        gameTimer = GameObject.FindFirstObjectByType<GameTimer>();
        game = GameObject.FindFirstObjectByType<Game>();

        onClickToolButtons.pinsChangedEvent += locker.OnPinsChangedEvent;
    }


}

