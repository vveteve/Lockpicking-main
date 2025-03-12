using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private int _unlockPos;
    [SerializeField] private int _maxPos;
    [SerializeField] private int _minPos;
    
    private int _currentPos;



    public bool IsUnlocked()
    {
        return _currentPos == _unlockPos;
    }

    public void ShiftPosition(int offset)
    {
        _currentPos = BoundPosition(_currentPos + offset);
    }

    public void ChangePosition(int pos)
    {
        _currentPos = BoundPosition(pos);
    }

    public void ChangeUnlockPosition(int position)
    {
        _unlockPos = BoundPosition(position);
    }

    public int GetPosition()
    {
        return _currentPos;
    }



    private int BoundPosition(int position)
    {
        if (position > _maxPos)
            position = _maxPos;

        if (position < _minPos)
            position = 0;

        return position;
    }
}

