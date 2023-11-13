using TMPro;
using Zenject;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Inject] private Progress _progress;

    private void Start()
    {
        _progress.OnScoreChange += UpdateScore;
    }

    private void UpdateScore(int score)
    {
        _text.text = score.ToString();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
