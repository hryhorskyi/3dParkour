using System.Collections;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField]
    private Trap _trap;
    [SerializeField]
    private float _damageInterval = 0.2f;
    [SerializeField]
    private int _damage = 10;
    
    private float _timer;
    
    private void Start()
    {
        _timer = _damageInterval;
    }
    
    public void OnTriggerStay(Collider other)
    {
        if(!_trap.IsActive)
            return;

        _timer -= Time.deltaTime;
        if(_timer > 0f)
            return;

        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
            health.TakeDamage(_damage);
        _timer = _damageInterval;
    }
}