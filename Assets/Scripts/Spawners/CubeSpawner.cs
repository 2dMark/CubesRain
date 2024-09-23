using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]

public class CubeSpawner : Spawner
{
    [SerializeField] private float _spawnTime;

    private Collider _collider;

    public event Action<Cube> Spawned;

    protected override void Awake()
    {
        base.Awake();

        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds spawnTime = new(_spawnTime);

        while (enabled)
        {
            Spawn(GetRandomPosition(), out SpawningObject cube);

            Spawned?.Invoke((Cube)cube);

            yield return spawnTime;
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomCoordinateX = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float randomCoordinateZ = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);

        return new(randomCoordinateX, transform.position.y, randomCoordinateZ);
    }
}