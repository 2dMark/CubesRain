using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CubePool))]
[RequireComponent (typeof(Collider))]

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _spawnTime;

    private Coroutine _coroutine;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(SpawnerWork());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private void Spawn()
    {
        float randomCoordinateX = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float randomCoordinateZ = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);
        Vector3 randomPosition = new(randomCoordinateX, transform.position.y, randomCoordinateZ);
        Cube cube = _cubePool.Get();

        cube.transform.position = randomPosition;
    }

    private IEnumerator SpawnerWork()
    {
        WaitForSeconds spawnTime = new(_spawnTime);

        yield return spawnTime;

        while (enabled)
        {
            Spawn();

            yield return spawnTime;
        }
    }
}