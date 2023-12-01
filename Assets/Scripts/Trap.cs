using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private float _interval = 1f;
    [SerializeField]
    private float _activeDuration = 0.5f;

    public float Timer { get; private set; }
    public bool IsActive { get; private set; }
    public float MaxValue => IsActive ? _activeDuration : _interval;

    public event Action StateChanged;

    private void Awake()
    {
        Timer = 0f;
        IsActive = false;
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if(Timer < _interval)
            return;

        IsActive = !IsActive;
        StateChanged?.Invoke();

        Timer = IsActive ? _interval - _activeDuration : 0f;
    }
}