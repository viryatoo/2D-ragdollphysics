using UnityEngine;
using Zenject;

public class AIRiderInstaller : MonoInstaller
{
    [SerializeField] private WheelSettings wheelSettings;
    [SerializeField] private PlayerInputSettings playerInputSettings;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private AIBreakAction breakAction;

    public override void InstallBindings()
    {
        Container.BindInstance(playerInputSettings).AsSingle();
        Container.BindInterfacesAndSelfTo<AIInput>().AsSingle();
        Container.BindInstance(wheelSettings).AsSingle();
        Container.BindInstance(playerMovement).AsSingle();
        Container.Bind<IRiderBreakAction>().FromInstance(breakAction).AsSingle();
    }
}