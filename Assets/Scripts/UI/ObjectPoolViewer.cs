using TMPro;
using UnityEngine;

public class ObjectPoolViewer : MonoBehaviour
{
    [SerializeField] private string _poolName = "pool";
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text GetedObjectsAmount;
    [SerializeField] private TMP_Text _createdObjectsAmount;
    [SerializeField] private TMP_Text _activeObjectsAmount;

    private IObjectPoolInformable _poolInfo;

    private void OnValidate()
    {
        _name.text = _poolName;
    }

    private void OnEnable()
    {
        RefreshText();

        _poolInfo.ObjectGeted += SetGetedObjectsAmount;
        _poolInfo.ObjectCreated += SetCreatedObjectsAmount;
        _poolInfo.ActiveObjectsAmountChanged += SetActiveObjectsAmount;
    }

    private void OnDisable()
    {
        _poolInfo.ObjectGeted -= SetGetedObjectsAmount;
        _poolInfo.ObjectCreated -= SetCreatedObjectsAmount;
        _poolInfo.ActiveObjectsAmountChanged -= SetActiveObjectsAmount;
    }

    public void Initialize(IObjectPoolInformable poolInfo)
    {
        _poolInfo = poolInfo;
    }

    private void SetGetedObjectsAmount(float value)
        => GetedObjectsAmount.text = $"Geted: {value}";

    private void SetCreatedObjectsAmount(float value)
        => _createdObjectsAmount.text = $"Created: {value}";

    private void SetActiveObjectsAmount(float value)
        => _activeObjectsAmount.text = $"Active: {value}";

    private void RefreshText()
    {
        SetGetedObjectsAmount(_poolInfo.GetedObjectsAmount);
        SetCreatedObjectsAmount(_poolInfo.CreatedObjectsAmount);
        SetActiveObjectsAmount(_poolInfo.ActiveObjectsAmount);
    }
}