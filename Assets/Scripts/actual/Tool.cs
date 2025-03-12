using UnityEngine;


public class Tool : MonoBehaviour
{
    [SerializeField] private Locker2 _locker;

    [SerializeField, Range(-1, 1)] private int _offset1;
    [SerializeField, Range(-1, 1)] private int _offset2;
    [SerializeField, Range(-1, 1)] private int _offset3;

    public void OnClickToolButton()
    {
        _locker.ShiftPins(_offset1, _offset2, _offset3);
    }

    public int[] GetOffsets()
    {
        return new int[] { _offset1, _offset2, _offset3 }; 
    }
}