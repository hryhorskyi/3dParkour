using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNameBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelNameText;
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private float _fadeTime = 0.4f;
    [SerializeField]
    private float _startDelayTime = 0.5f;
    [SerializeField]
    private float _readDelayTime = 1f;

    private IEnumerator Start()
    {
        _levelNameText.text = SceneManager.GetActiveScene().name;
        _canvasGroup.alpha = 0;

        yield return new WaitForSeconds(_startDelayTime);
        
        for(int i = 0; i <= 20; i++)
        {
            yield return new WaitForSeconds(_fadeTime / 21);
            _canvasGroup.alpha = i * 5f / 100;
        }
        
        yield return new WaitForSeconds(_readDelayTime);
        
        for(int i = 20; i >= 0; i--)
        {
            yield return new WaitForSeconds(_fadeTime / 21);
            _canvasGroup.alpha = i * 5f / 100;
        }
    }
}