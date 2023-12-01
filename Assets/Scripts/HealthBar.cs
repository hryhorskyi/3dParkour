using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health _health;
    [SerializeField]
    private Image _bar;

    private void Start()
    {
        _health.Updated += UpdateView;
        UpdateView();
    }
    
    private void OnDestroy()
    {
        _health.Updated -= UpdateView;
    }

    private void UpdateView()
    {
        _bar.fillAmount = (float)_health.Value / _health.Max;
    }
}