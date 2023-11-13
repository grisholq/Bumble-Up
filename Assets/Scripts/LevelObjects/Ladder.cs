using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Ladder : MonoBehaviour
{
    [SerializeField] private Vector3 _stepOffset;
    [SerializeField] private List<Step> _initSteps;

    [Inject] private StepsPool _pool;
    [Inject] private PlayerBall _ball;

    public event UnityAction<Step> NewStepSpawned;

    private LinkedList<Step> _steps;
    private Vector3 _stepPosition;

    private void Start()
    {
        _steps = new LinkedList<Step>();

        foreach (var step in _initSteps)
        {
            _steps.AddLast(step);
        }

        _stepPosition = _steps.Last.Value.transform.position;

        _ball.JumpedUp += NextStep;
    }

    public void NextStep()
    {
        DestroyFirstStep();
        AddStepToEnd();
    }

    public void DestroyFirstStep()
    {
        var firstStep = _steps.First.Value;
        _steps.RemoveFirst();
        _pool.Release(firstStep.gameObject);
    }

    public void AddStepToEnd()
    {
        var newStep = _pool.Get().GetComponent<Step>();
        _steps.AddLast(newStep);
        PositionNewStep(newStep);
        NewStepSpawned?.Invoke(newStep);
    }

    private void PositionNewStep(Step step)
    {
        _stepPosition += _stepOffset;
        step.transform.position = _stepPosition;
    }
}