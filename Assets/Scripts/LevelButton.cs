using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private string _targetLevel;

    public void Start()
    {
        _button.onClick.AddListener(GoToLevel);
    }
    
    public void OnDestroy()
    {
        _button.onClick.RemoveListener(GoToLevel);
    }

    private void GoToLevel()
    {
        SceneManager.LoadScene(_targetLevel);
    }
}