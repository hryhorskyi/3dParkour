using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField]
    public int Max { get; private set; } = 100;

    public int Value { get; private set; }
    
    public event Action Updated;

    private void Awake()
    {
        Value = Max;
    }

    public void TakeDamage(int damage)
    {
        if(damage <= 0)
            return;

        Value -= damage;
        Updated?.Invoke();
    }
}