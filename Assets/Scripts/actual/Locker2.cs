using UnityEngine;
using UnityEngine.Events;

public class Locker2 : MonoBehaviour
{
    [SerializeField] private LockerVisual _lockerVisual;

    [SerializeField] private Pin _pin1;
    [SerializeField] private Pin _pin2;
    [SerializeField] private Pin _pin3;

    [SerializeField] private UnityEvent _onLockerUnlocked;

    public void ShiftPins(int offset1,  int offset2, int offset3)
    {
        _pin1.ShiftPosition(offset1);
        _pin2.ShiftPosition(offset2);
        _pin3.ShiftPosition(offset3);

        _lockerVisual.UpdateLockerVisual();


        if (!IsUnlocked())
            return;

        _onLockerUnlocked?.Invoke();
    }

    public void SetPinsUnlockPosition(int pos1, int pos2, int pos3)
    {
        _pin1.ChangeUnlockPosition(pos1);
        _pin2.ChangeUnlockPosition(pos2);
        _pin3.ChangeUnlockPosition(pos3);
    }

    public int[] GetPinsPositions()
    {
        return new int[3] { _pin1.GetPosition(), _pin2.GetPosition(), _pin3.GetPosition() };
    }

    public void ChangePinsPositions(int pos1, int pos2, int pos3)
    {
        _pin1.ChangePosition(pos1);
        _pin2.ChangePosition(pos2);
        _pin3.ChangePosition(pos3);
    }

    public bool IsUnlocked()
    {
        return _pin1.IsUnlocked() && _pin2.IsUnlocked() && _pin3.IsUnlocked();
    }
}
