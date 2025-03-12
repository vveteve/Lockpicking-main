using UnityEngine;
using UnityEngine.UI;

public class Game2 : MonoBehaviour
{
    [SerializeField] private GameObject loosePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gamePanel;

    [SerializeField] private Button tool1;
    [SerializeField] private Button tool2;
    [SerializeField] private Button tool3;

    [SerializeField] private Button startButton;

    [SerializeField] private Text pin1;
    [SerializeField] private Text pin2;
    [SerializeField] private Text pin3;

    [SerializeField] private Text tool1Text;
    [SerializeField] private Text tool2Text;
    [SerializeField] private Text tool3Text;

    [SerializeField] private Text time;
    [SerializeField] private Text startButtonText;

    [SerializeField] private int[] tool1Changes = { 1, 1, 1 };
    [SerializeField] private int[] tool2Changes = { -1, -1, -1 };
    [SerializeField] private int[] tool3Changes = { 0, -1, 1 };
    [SerializeField] private float roundTime = 60f;


    private int winNum;
    private bool gameStarted = false;
    private float currentTime;



    private void Start()
    {
        Application.targetFrameRate = 60;

        PrepareRound();

        tool1Text.text = $"| {tool1Changes[0].ToString()} | {tool1Changes[1].ToString()} | {tool1Changes[2].ToString()} |";
        tool2Text.text = $"| {tool2Changes[0].ToString()} | {tool2Changes[1].ToString()} | {tool2Changes[2].ToString()} |";
        tool3Text.text = $"| {tool3Changes[0].ToString()} | {tool3Changes[1].ToString()} | {tool3Changes[2].ToString()} |";
    }

    private void Update()
    {
        if (!gameStarted || currentTime < 0)
            return;

        time.text = $"Âðåìÿ: {Mathf.Round(currentTime).ToString()}";
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            gamePanel.SetActive(false);
            loosePanel.SetActive(true);
            gameStarted = false;
        }
    }

    private void PrepareRound()
    {
        gameStarted = false;

        loosePanel.SetActive(false);
        winPanel.SetActive(false);
        gamePanel.SetActive(true);

        startButton.interactable = true;
        startButtonText.color = new Color(0, 0, 0, 0.9490196f);
        startButtonText.text = "ÍÀ×ÀÒÜ";

        currentTime = roundTime;
        time.text = $"Âðåìÿ: {Mathf.Round(currentTime).ToString()}";

        winNum = Random.Range(3, 11);

        pin1.text = "0";
        pin2.text = "0";
        pin3.text = "0";
    }

    public void OnStartGamePress()
    {
        gameStarted = true;
        startButtonText.text = $"{winNum}";
        startButtonText.color = new Color(1, 0, 0.9114361f);
        startButton.interactable = false;
    }


    public void OnTool1Press()
    {
        if (!gameStarted || currentTime < 0)
            return;
        pin1.text = (int.Parse(pin1.text) + tool1Changes[0]).ToString();
        pin2.text = (int.Parse(pin2.text) + tool1Changes[1]).ToString();
        pin3.text = (int.Parse(pin3.text) + tool1Changes[2]).ToString();

        CheckPins();
    }

    public void OnTool2Press()
    {
        if (!gameStarted || currentTime < 0)
            return;
        pin1.text = (int.Parse(pin1.text) + tool2Changes[0]).ToString();
        pin2.text = (int.Parse(pin2.text) + tool2Changes[1]).ToString();
        pin3.text = (int.Parse(pin3.text) + tool2Changes[2]).ToString();

        CheckPins();
    }

    public void OnTool3Press()
    {
        if (!gameStarted || currentTime < 0)
            return;
        pin1.text = (int.Parse(pin1.text) + tool3Changes[0]).ToString();
        pin2.text = (int.Parse(pin2.text) + tool3Changes[1]).ToString();
        pin3.text = (int.Parse(pin3.text) + tool3Changes[2]).ToString();

        CheckPins();
    }

    public void OnAgainButtonPress()
    {
        PrepareRound();
    }

    private void CheckPins()
    {
        if (int.Parse(pin1.text) < 0)
            pin1.text = "0";
        if (int.Parse(pin2.text) < 0)
            pin2.text = "0";
        if (int.Parse(pin3.text) < 0)
            pin3.text = "0";

        if (int.Parse(pin1.text) > 10)
            pin1.text = "10";
        if (int.Parse(pin2.text) > 10)
            pin2.text = "10";
        if (int.Parse(pin3.text) > 10)
            pin3.text = "10";

        if (int.Parse(pin1.text) == winNum && int.Parse(pin2.text) == winNum && int.Parse(pin3.text) == winNum)
        {
            gamePanel.SetActive(false);
            winPanel.SetActive(true);
            gameStarted = false;
        }

    }
}
