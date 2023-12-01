using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TrapTimerView : MonoBehaviour
{
    [SerializeField]
    private Trap _trap;
    [SerializeField]
    private Image _bar;
    
    private void Update()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        _bar.fillAmount = _trap.Timer / _trap.MaxValue;
    }
}