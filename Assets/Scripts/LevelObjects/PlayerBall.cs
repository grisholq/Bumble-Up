using Zenject;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBall : Figure
{
    [SerializeField] private Transform _cameraLookPoint;
    [SerializeField] private ParticleSystem _deathParticles;

    [Inject] private SwipeInput _input;

    public event UnityAction JumpedUp;
    public event UnityAction Died;


    void Update()
    {
        if(_input.Click)
        {
            MakeJumpForward();
        }
        else if(_input.SwipeLeft) 
        {
            MakeMoveToLeft();
        }
        else if (_input.SwipeRight)
        {
            MakeMoveToRight();
        }
    }

    public void Die()
    {
        SpawnParticelsOnDeath();
        Destroy(gameObject);
        Died?.Invoke();
    }

    public override void MakeJumpForward()
    {
        base.MakeJumpForward();
        JumpedUp?.Invoke();
        UpdateCameraLookPosition();
    }

    private void UpdateCameraLookPosition()
    {
        Vector3 position = _cameraLookPoint.position;
        position.y = _currentTarget.y;
        position.z = _currentTarget.z;
        _cameraLookPoint.position = position;
    }

    private void SpawnParticelsOnDeath()
    {
        var particles = Instantiate(_deathParticles);
        particles.transform.parent = transform.parent;
        particles.transform.position = transform.position;
        particles.Play();
    }
}
