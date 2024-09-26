using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]

public class CubeSpawner : Spawner
{
    [SerializeField] private float _spawnDelay = 1f;

    private Collider _collider;

    public event Action<Cube> Spawned;

    private void OnEnable()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds spawnTime = new(_spawnDelay);

        while (enabled)
        {
            Spawn(GetRandomPosition(), out SpawningObject cube);

            Spawned?.Invoke((Cube)cube);

            yield return spawnTime;
        }
    }

    public override void Initialize()
    {
        _collider = GetComponent<Collider>();

        _objectPool = new(_prefab, transform);
    }

    private Vector3 GetRandomPosition()
    {
        float randomCoordinateX = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float randomCoordinateZ = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);

        return new(randomCoordinateX, transform.position.y, randomCoordinateZ);
    }
}