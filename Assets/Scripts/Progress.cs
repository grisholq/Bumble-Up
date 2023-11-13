using Zenject;
using UnityEngine;
using UnityEngine.Events;

public class Progress : MonoBehaviour
{
    [Inject] private PlayerBall _ball;

    public int Score { get; set; }

    public int MaxScore
    {
        get => PlayerPrefs.GetInt("MaxScore", 0);
        private set => PlayerPrefs.SetInt("MaxScore", value);
    }

    public event UnityAction<int> OnScoreChange;

    private void Start()
    {
        _ball.JumpedUp += AddScore;
        _ball.Died += SaveMaxScore;
    }

    public void AddScore()
    {
        Score++;
        OnScoreChange(Score);
    }

    public void SaveMaxScore()
    {
        MaxScore = Score;
    }
}