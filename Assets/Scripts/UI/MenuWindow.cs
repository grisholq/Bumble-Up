using TMPro;
using Zenject;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _maxScore;

    [Inject] private Progress _progress;

    public void Show()
    {
        gameObject.SetActive(true);
        DisplayScoreData();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void DisplayScoreData()
    {
        _currentScore.text = _progress.Score.ToString();
        _maxScore.text = "max: " + _progress.MaxScore.ToString();
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
