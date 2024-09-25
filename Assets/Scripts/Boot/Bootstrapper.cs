using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Cube Spawner")]
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private ObjectPoolViewer _cubePoolViewer;
    [Header("Bomb Spawner")]
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private ObjectPoolViewer _bombPoolViewer;

    private void Awake()
    {
        _cubeSpawner.Initialize();
        _bombSpawner.Initialize();
        _cubePoolViewer.Initialize(_cubeSpawner.PoolInfo);
        _bombPoolViewer.Initialize(_bombSpawner.PoolInfo);
    }
}