using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private WheelSettings wheelSettings;
    [SerializeField] private PlayerInputSettings playerInputSettings;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerBreakAction playerBreakAction;
    
    public override void InstallBindings()
    {
        Container.BindInstance(playerInputSettings).AsSingle();
        Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        Container.BindInstance(wheelSettings).AsSingle();
        Container.BindInstance(new ScoreCalculator()).AsSingle();
        Container.BindInstance(playerMovement).AsSingle();
        Container.Bind<IRiderBreakAction>().FromInstance(playerBreakAction).AsSingle();
    }
}