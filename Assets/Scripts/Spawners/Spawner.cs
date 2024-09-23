using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected SpawningObject _prefab;

    protected ObjectPool<SpawningObject> _objectPool;

    public IObjectPoolInformable PoolInfo => _objectPool.PoolInfo;

    protected virtual void Awake()
    {
        _objectPool = new(_prefab, transform);
    }

    public virtual void Spawn(Vector3 position, out SpawningObject instance)
    {
        instance = _objectPool.GetObject();
        instance.transform.position = position;

        instance.Returned += Return;

        instance.gameObject.SetActive(true);
    }

    protected void Return(SpawningObject instance)
    {
        instance.Returned -= Return;

        _objectPool.PutObject(instance);
    }
}