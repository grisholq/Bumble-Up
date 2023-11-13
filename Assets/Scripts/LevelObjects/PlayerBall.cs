using Zenject;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBall : Figure
{
    [SerializeField] private Transform _cameraLookPoint;
    [SerializeField] private ParticleSystem _deathParticles;

    [Inject] private SwipeInput _swipeInput;

    public event UnityAction JumpedUp;
    public event UnityAction Died;


    void Update()
    {
        if (_swipeInput.Click || Input.GetKeyDown(KeyCode.Space))
        {
            MakeJumpForward();
        }
        else if(_swipeInput.SwipeLeft || Input.GetKeyDown(KeyCode.A))   
        {
            MakeMoveToLeft();
        }
        else if (_swipeInput.SwipeRight || Input.GetKeyDown(KeyCode.D))
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
