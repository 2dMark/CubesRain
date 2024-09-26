using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private void OnEnable()
    {
        _cubeSpawner.Spawned += AddListener;
    }

    private void OnDisable()
    {
        _cubeSpawner.Spawned -= AddListener;
    }

    public override void Initialize() => _objectPool = new(_prefab, transform);

    private void AddListener(SpawningObject cube) => cube.Returned += SpawnOnCubePosition;

    private void SpawnOnCubePosition(SpawningObject cube)
    {
        cube.Returned -= SpawnOnCubePosition;

        Spawn(cube.transform.position, out SpawningObject _);
    }
}