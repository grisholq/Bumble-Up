using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Figure : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] protected Transform _visual;
    [SerializeField] private float _jumpPower = 2;
    [SerializeField] private float _jumpDuration = 1;
    [SerializeField] private float _sideJumpPower= 1;
    [SerializeField] private float _sideJumpDuration = 1;

    protected Vector3 _currentTarget;
    private Sequence CurrentSequence
    {
        set
        {
            _currentSequence.Kill();
            _currentSequence = value;
        }
    }

    private Sequence _currentSequence;

    private void Start()
    {
        Init();      
    }

    protected virtual void Init()
    {
        _currentTarget = _transform.position;
    }

    public virtual void MakeJumpForward()
    {
        _currentTarget += Vector3.forward + Vector3.up;
        CurrentSequence = _transform.DOJump(_currentTarget, _jumpPower, 1, _jumpDuration);
    }

    public virtual void MakeJumpDown()
    {
        _currentTarget += Vector3.back + Vector3.down;
        CurrentSequence = _transform.DOJump(_currentTarget, _jumpPower, 1, _jumpDuration);
    }

    public virtual void MakeMoveToRight()
    {
        _currentTarget += Vector3.right;
        CurrentSequence = _transform.DOJump(_currentTarget, _sideJumpPower, 1, _sideJumpDuration);
    }

    public virtual void MakeMoveToLeft()
    {
        _currentTarget += Vector3.left;
        CurrentSequence = _transform.DOJump(_currentTarget, _sideJumpPower, 1, _sideJumpDuration);
    }
}