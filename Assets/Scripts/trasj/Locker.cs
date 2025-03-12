using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    private Text pin1Text;
    private Text pin2Text;
    private Text pin3Text;

  

    private int correctPinNum;

    public delegate void AllPinsCorrect();
    public AllPinsCorrect allPinsCorrectEventl;


    private void Awake()
    {
        correctPinNum = Random.Range(2, 11);
        Debug.Log($"correctPinNum == {correctPinNum}");
    }


    public void OnPinsChangedEvent(Text[] pins)
    {
        for (int i = 0; i < pins.Length; i++) 
        {
            if (System.Convert.ToInt32(pins[i].text) == correctPinNum)
                continue;
            else
                return;
        }
        allPinsCorrectEventl();
    }
}
