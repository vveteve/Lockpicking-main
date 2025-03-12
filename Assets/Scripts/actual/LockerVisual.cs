using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LockerVisual : MonoBehaviour
{
    [SerializeField] private Locker2 _locker;

    [SerializeField] private Text _pin1Text;
    [SerializeField] private Text _pin2Text;
    [SerializeField] private Text _pin3Text;


    public void UpdateLockerVisual()
    {
        int[] pinPoses = _locker.GetPinsPositions();

        _pin1Text.text = pinPoses[0].ToString();
        _pin2Text.text = pinPoses[1].ToString();
        _pin3Text.text = pinPoses[2].ToString();
    }
}