using UnityEngine;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;
    
    [SerializeField] private Timer _timer;
    [SerializeField] private Locker2 _locker;
    [SerializeField] private TimerVisual _timerVisual;
    [SerializeField] private LockerVisual _lockerVisual;
    [SerializeField] private Button _startButton;
    [SerializeField] private Text _startButtonText;

    [SerializeField] private ToolVisual _toolVisual1;
    [SerializeField] private ToolVisual _toolVisual2;
    [SerializeField] private ToolVisual _toolVisual3;

    [SerializeField] private float _roundTime = 60f;
    [SerializeField] private Color _disabledTextColor;
    [SerializeField] private Color _enabledTextColor;


    private int _winNum;
    private bool _gameStarted = false;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        PrepareScene();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!_gameStarted)
            return;

        _timer.UpdateTimer();
        _timerVisual.UpdateTimerVisual();
    }


    
    public void StartGame()
    {
        _gameStarted = true;
        _timer.StartTimer();

        _winNum = Random.Range(3, 11);
        _locker.SetPinsUnlockPosition(_winNum, _winNum, _winNum);

        DisableStartButton();
        EnableTools();

    }

    public void OnAgainButtonPress()
    {
        PrepareScene();
    }

    public void OnWin()
    {
        EndGame();

        SetOneActivePanel(_winPanel);
    }

    public void OnLoss()
    {
        EndGame();

        SetOneActivePanel(_loosePanel);
    }



    private void EndGame()
    {
        _gameStarted = false;
        _timer.StopTimer();
    }
    
    private void SetOneActivePanel(GameObject panel)
    {
        _gamePanel.SetActive(false);
        _winPanel.SetActive(false);
        _loosePanel.SetActive(false);

        panel.SetActive(true);
    }

    private void PrepareScene()
    {
        _gameStarted = false;

        SetOneActivePanel(_gamePanel);

        _timer.SetTime(_roundTime);
        _locker.ChangePinsPositions(0,0,0);

        _toolVisual1.UpdateToolVisual();
        _toolVisual2.UpdateToolVisual();
        _toolVisual3.UpdateToolVisual();
        _timerVisual.UpdateTimerVisual();
        _lockerVisual.UpdateLockerVisual();

        EnableStartButton();
        DisableTools();

    }

    private void EnableStartButton()
    {
        _startButton.interactable = true;
        _startButtonText.text = "Õ¿◊¿“‹";
        _startButtonText.color = _enabledTextColor;
    }

    private void DisableStartButton()
    {
        _startButton.interactable = false;
        _startButtonText.text = $"{_winNum}";
        _startButtonText.color = _disabledTextColor;
    }

    private void DisableTools()
    {
        _toolVisual1.toolButton.interactable = false;
        _toolVisual2.toolButton.interactable = false;
        _toolVisual3.toolButton.interactable = false;

        _toolVisual1.toolText.color = _disabledTextColor;
        _toolVisual2.toolText.color = _disabledTextColor;
        _toolVisual3.toolText.color = _disabledTextColor;
    }

    private void EnableTools()
    {
        _toolVisual1.toolButton.interactable = true;
        _toolVisual2.toolButton.interactable = true;
        _toolVisual3.toolButton.interactable = true;

        _toolVisual1.toolText.color = _enabledTextColor;
        _toolVisual2.toolText.color = _enabledTextColor;
        _toolVisual3.toolText.color = _enabledTextColor;
    }
}
