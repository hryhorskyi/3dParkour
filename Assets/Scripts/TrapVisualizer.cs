using System;
using UnityEngine;

public class TrapVisualizer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _flameEffects;
    [SerializeField]
    private Trap _trap;

    private void Start()
    {
        _trap.StateChanged += UpdateView;
    }
    
    private void OnDestroy()
    {
        _trap.StateChanged -= UpdateView;
    }

    private void UpdateView()
    {
        if(_trap.IsActive)
            ShowFlames();
        else
            HideFlames();
    }

    private void ShowFlames()
    {
        foreach(GameObject flameEffect in _flameEffects)
            flameEffect.SetActive(true);
    }

    private void HideFlames()
    {
        foreach(GameObject flameEffect in _flameEffects)
            flameEffect.SetActive(false);
    }
}