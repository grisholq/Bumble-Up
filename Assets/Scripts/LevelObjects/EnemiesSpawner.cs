using Zenject;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] [Range(0, 1f)] private float _spawnChance;
    [SerializeField] private GameObject _enemyPrefab;

    [Inject] private Ladder _ladder;
    [Inject] private DiContainer _container;

    private void Start()
    {
        _ladder.NewStepSpawned += SpawnEnemyWithChance;
    }

    private void SpawnEnemyWithChance(Step step)
    {
        if(Flip())
        {
            Spawn(step);
        }
    }

    private void Spawn(Step step)
    {
        var position = step.GetRandomPositionOnSurface();
        var enemyInstance = _container.InstantiatePrefab(_enemyPrefab);
        enemyInstance.transform.position = position;
    }

    private bool Flip()
    {
        return Random.Range(0, 1f) < _spawnChance;
    }
}
