using UnityEngine;

public class EnemyBox : Figure
{
    [SerializeField] private float _jumpTime = 1;

    private RepeatTimer _jumpTimer;

    protected override void Init()
    {
        base.Init();
        _jumpTimer = new RepeatTimer(_jumpTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBall ball))
        {
            ball.Die();
        }
    }

    private void Update()
    {
        if(_jumpTimer.DoneWithReset)
        {
            MakeJumpDown();
        }
    }
}