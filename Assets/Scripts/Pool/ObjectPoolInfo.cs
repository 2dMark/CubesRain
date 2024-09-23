using System;

public class ObjectPoolInfo : IObjectPoolInformable
{
    private float _totalObjectsAmount = 0;
    private float _createdObjectsAmount = 0;
    private float _activeObjectsAmount = 0;

    public event Action<float> ObjectGeted;
    public event Action<float> ObjectCreated;
    public event Action<float> ActiveObjectsAmountChanged;

    public float TotalObjectsAmount
    {
        get
        {
            return _totalObjectsAmount;
        }
        set
        {
            _totalObjectsAmount = value;

            ObjectGeted?.Invoke(_totalObjectsAmount);
        }
    }

    public float CreatedObjectsAmount
    {
        get
        {
            return _createdObjectsAmount;
        }
        set
        {
            _createdObjectsAmount = value;

            ObjectCreated?.Invoke(_createdObjectsAmount);
        }
    }

    public float ActiveObjectsAmount
    {
        get
        {
            return _activeObjectsAmount;
        }
        set
        {
            _activeObjectsAmount = value;

            ActiveObjectsAmountChanged?.Invoke(_activeObjectsAmount);
        }
    }
}