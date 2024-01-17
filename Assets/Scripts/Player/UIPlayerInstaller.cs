using UnityEngine;
using Zenject;

public class UIPlayerInstaller : MonoInstaller
{
    [SerializeField] private UIJumpForceView uiJumpForceView;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UIJumpForceModel>().AsSingle();
        Container.BindInstance(uiJumpForceView).AsSingle();
    }
}