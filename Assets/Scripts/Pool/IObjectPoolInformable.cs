using System;

public interface IObjectPoolInformable
{
    public event Action<float> ObjectGeted;
    public event Action<float> ObjectCreated;
    public event Action<float> ActiveObjectsAmountChanged;

    public float TotalObjectsAmount { get;}

    public float CreatedObjectsAmount { get;}

    public float ActiveObjectsAmount { get;}
}