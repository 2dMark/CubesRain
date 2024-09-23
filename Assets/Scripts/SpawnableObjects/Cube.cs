using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : SpawningObject
{
    private bool _isTimerStart;

    public override event Action<SpawningObject> Returned;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTimerStart == false)
            if (collision.collider.TryGetComponent(out Platform _))
            {
                SetRandomColor();
                StartCoroutine(StartTimer());
            }
    }

    private IEnumerator StartTimer()
    {
        _isTimerStart = true;

        WaitForSeconds timer = new(RandomTimerValue);

        yield return timer;

        Returned?.Invoke(this);

        _isTimerStart = false;
    }

    private void SetRandomColor() => _renderer.material.color = Random.ColorHSV();
}