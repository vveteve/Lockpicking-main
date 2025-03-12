using UnityEngine;
using UnityEngine.UI;

public class OnClickToolButtons : MonoBehaviour
{
    public int[] tool1Adds;
    public int[] tool2Adds;
    public int[] tool3Adds;

    private Text pin1Text;
    private Text pin2Text;
    private Text pin3Text;

    private Button tool1;
    private Button tool2;
    private Button tool3;

    

    public delegate void PinChanged(Text[] pins);
    public PinChanged pinsChangedEvent;

    private void Awake()
    {
        pin1Text = GameObject.Find("Canvas/GamePanel/Pin1/Text").GetComponent<Text>();
        pin2Text = GameObject.Find("Canvas/GamePanel/Pin2/Text").GetComponent<Text>();
        pin3Text = GameObject.Find("Canvas/GamePanel/Pin3/Text").GetComponent<Text>();

        tool1 = GameObject.Find("Canvas/GamePanel/Tool1").GetComponent<Button>();
        tool2 = GameObject.Find("Canvas/GamePanel/Tool2").GetComponent<Button>();
        tool3 = GameObject.Find("Canvas/GamePanel/Tool3").GetComponent<Button>();

        tool1.onClick.AddListener(OnClickTool1);
        tool2.onClick.AddListener(OnClickTool2);
        tool3.onClick.AddListener(OnClickTool3);
    }

    
    private void OnClickTool1()
    {
        OnClickTool(tool1Adds);
    }

    private void OnClickTool2()
    {
        OnClickTool(tool2Adds);
    }

    private void OnClickTool3()
    {
        OnClickTool(tool3Adds);
    }

    private void OnClickTool(int[] tool)
    {
        int pin1Int = System.Convert.ToInt32(pin1Text.text);
        int pin2Int = System.Convert.ToInt32(pin2Text.text);
        int pin3Int = System.Convert.ToInt32(pin3Text.text);

        pin1Int += tool[0];
        pin2Int += tool[1];
        pin3Int += tool[2];

        pin1Text.text = pin1Int.ToString();
        pin2Text.text = pin2Int.ToString();
        pin3Text.text = pin3Int.ToString();

        pinsChangedEvent(new Text[] { pin1Text, pin2Text, pin3Text });
    }

    
}
