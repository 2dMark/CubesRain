using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Bomb : SpawningObject
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public override event Action<SpawningObject> Returned;

    protected override void OnEnable()
    {
        base.OnEnable();

        StartCoroutine(Exploding());
    }

    private IEnumerator Exploding()
    {
        float explodeTime = RandomTimerValue;
        WaitForSeconds timer = new(explodeTime);

        _renderer.material.DOFade(0, explodeTime);

        yield return timer;

        Returned?.Invoke(this);

        Explode();
    }

    private void Explode()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider target in targets)
            if (target.TryGetComponent(out SpawningObject item))
                item.AddExplosionForce
                    (_explosionForce, transform.position, _explosionRadius);
    }
}