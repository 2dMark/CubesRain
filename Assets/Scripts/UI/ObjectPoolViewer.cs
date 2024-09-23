using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectPoolViewer : MonoBehaviour
{
    [SerializeField] private string _poolname = "pool";
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _totalObjectsAmount;
    [SerializeField] private TMP_Text _createdObjectsAmount;
    [SerializeField] private TMP_Text _activeObjectsAmount;

    private void OnValidate()
    {
        _name.text = _poolname;
    }

    private void OnEnable()
    {
        StartCoroutine(StartOnEnableWithDelay());

        //RefreshText();

        //_spawner.PoolInfo.ObjectGeted += SetTotalObjectsAmount;
        //_spawner.PoolInfo.ObjectCreated += SetCreatedObjectsAmount;
        //_spawner.PoolInfo.ActiveObjectsAmountChanged += SetActiveObjectsAmount;
    }

    private void OnDisable()
    {
        _spawner.PoolInfo.ObjectGeted -= SetTotalObjectsAmount;
        _spawner.PoolInfo.ObjectCreated -= SetCreatedObjectsAmount;
        _spawner.PoolInfo.ActiveObjectsAmountChanged -= SetActiveObjectsAmount;
    }

    private IEnumerator StartOnEnableWithDelay()
    {
        yield return null;

        RefreshText();

        _spawner.PoolInfo.ObjectGeted += SetTotalObjectsAmount;
        _spawner.PoolInfo.ObjectCreated += SetCreatedObjectsAmount;
        _spawner.PoolInfo.ActiveObjectsAmountChanged += SetActiveObjectsAmount;
    }

    private void SetTotalObjectsAmount(float value)
        => _totalObjectsAmount.text = $"Total: {value}";

    private void SetCreatedObjectsAmount(float value)
        => _createdObjectsAmount.text = $"Created: {value}";

    private void SetActiveObjectsAmount(float value)
        => _activeObjectsAmount.text = $"Active: {value}";

    private void RefreshText()
    {
        SetTotalObjectsAmount(_spawner.PoolInfo.TotalObjectsAmount);
        SetCreatedObjectsAmount(_spawner.PoolInfo.CreatedObjectsAmount);
        SetActiveObjectsAmount(_spawner.PoolInfo.ActiveObjectsAmount);
    }
}