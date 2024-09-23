using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public abstract class SpawningObject : MonoBehaviour
{
    [SerializeField] protected float _minTimerValue;
    [SerializeField] protected float _maxTimerValue;
    [SerializeField] protected Color _basicColor;

    protected Renderer _renderer;
    protected Rigidbody _rigidbody;

    public abstract event Action<SpawningObject> Returned;

    protected float RandomTimerValue => Random.Range(_minTimerValue, _maxTimerValue + 1);

    protected void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void OnEnable()
    {
        ResetVelocity();
        SetBasicColor();
    }

    public void AddExplosionForce
        (float explosionForce, Vector3 explosionPosition, float explosionRadius)
        => _rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);

    protected void ResetVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    protected void SetBasicColor() => _renderer.material.color = _basicColor;
}