using Zenject;

public class UIViewInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<BottomCenterView>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}
