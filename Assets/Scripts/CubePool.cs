using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new(_prefab, transform);
    }

    public Cube Get()
    {
        Cube cube = _pool.GetObject();

        cube.TimerEnded += Put;

        cube.gameObject.SetActive(true);

        return cube;
    }

    public void Put(Cube cube)
    {
        cube.TimerEnded -= Put;

        _pool.PutObject(cube);
    }
}