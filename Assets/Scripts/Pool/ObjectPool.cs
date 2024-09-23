using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _container;
    private Queue<T> _pool = new();
    private ObjectPoolInfo _poolInfo = new();

    public ObjectPool(T prefab, Transform container)
    {
        _pool = new();
        _poolInfo = new();
        _prefab = prefab;
        _container = container;
    }

    public IObjectPoolInformable PoolInfo => _poolInfo;

    public T GetObject()
    {
        _poolInfo.TotalObjectsAmount++;
        _poolInfo.ActiveObjectsAmount++;

        if (_pool.Count == 0)
        {
            T instance = Object.Instantiate(_prefab, _container);

            _poolInfo.CreatedObjectsAmount++;

            return instance;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T instance)
    {
        _pool.Enqueue(instance);
        instance.gameObject.SetActive(false);

        _poolInfo.ActiveObjectsAmount--;
    }
}