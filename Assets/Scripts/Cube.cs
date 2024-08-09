using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _minLifetime;
    [SerializeField] private float _maxLifetime;
    [SerializeField] private Color _basicColor = Color.white;

    public event Action<Cube> TimerEnded;

    private Renderer _renderer;
    private bool _isTimerStart;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        SetBasicColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform _))
            if (_isTimerStart == false)
            {
                _isTimerStart = true;

                SetRandomColor();
                StartCoroutine(Timer());

            }
    }

    private IEnumerator Timer()
    {
        WaitForSeconds timer = new(Random.Range(_minLifetime, _maxLifetime + 1));

        yield return timer;

        TimerEnded?.Invoke(this);

        _isTimerStart = false;
    }

    private void SetBasicColor() => _renderer.material.color = _basicColor;

    private void SetRandomColor() => _renderer.material.color = Random.ColorHSV();
}