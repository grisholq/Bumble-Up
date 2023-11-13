using UnityEngine;
using Zenject;

public class CommonInstaller : MonoInstaller
{
    [SerializeField] private StepsPool _pool;
    [SerializeField] private PlayerBall _ball;
    [SerializeField] private Ladder _ladder;
    [SerializeField] private Progress _progress;
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private MenuWindow _menuWindow;
    [SerializeField] private SwipeInput _input;

    public override void InstallBindings()
    {
        Container.Bind<StepsPool>().FromInstance(_pool).AsSingle();
        Container.Bind<PlayerBall>().FromInstance(_ball).AsSingle();
        Container.Bind<Ladder>().FromInstance(_ladder).AsSingle();
        Container.Bind<Progress>().FromInstance(_progress).AsSingle();
        Container.Bind<ScoreUI>().FromInstance(_scoreUI).AsSingle();
        Container.Bind<MenuWindow>().FromInstance(_menuWindow).AsSingle();
        Container.Bind<SwipeInput>().FromInstance(_input).AsSingle();
    }
}