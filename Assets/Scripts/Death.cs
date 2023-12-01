using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField]
    private Health _health;
    [SerializeField]
    private float _dieLowerY;

    private void Start()
    {
        _health.Updated += TryDieByHealth;
    }
    
    private void OnDestroy()
    {
        _health.Updated -= TryDieByHealth;
    }

    private void Update()
    {
        TryDieByPosition();
    }

    private void TryDieByPosition()
    {
        if(transform.position.y < _dieLowerY)
        {
            Restart();
        }
    }

    private void TryDieByHealth()
    {
        if(_health.Value <= 0)
        {
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}