using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubePool))]
[RequireComponent(typeof(Collider))]

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _spawnTime;

    private float _startDelay = .1f;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnerWork());
    }

    private IEnumerator SpawnerWork()
    {
        WaitForSeconds spawnTime = new(_spawnTime);
        WaitForSeconds startDelay = new(_startDelay);

        yield return startDelay;

        while (enabled)
        {
            Spawn();

            yield return spawnTime;
        }
    }

    private void Spawn()
    {
        Cube cube = _cubePool.Get();

        cube.transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        float randomCoordinateX = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float randomCoordinateZ = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);
        Vector3 randomPosition = new(randomCoordinateX, transform.position.y, randomCoordinateZ);

        return randomPosition;
    }
}