using Zenject;
using UnityEngine;
using DG.Tweening;

public class LoseHandler : MonoBehaviour
{
    [Inject] private ScoreUI _score;
    [Inject] private MenuWindow _menuWindow;
    [Inject] private PlayerBall _ball;
    [Inject] private Progress _progress;

    private void Start()
    {
        _ball.Died += HandleLoseDelay;
    }

    private void HandleLoseDelay()
    {
        DOVirtual.DelayedCall(1, HandleLose);
    }

    private void HandleLose()
    {
        _score.Hide();
        _menuWindow.Show();
        _progress.SaveMaxScore();
    }
}
