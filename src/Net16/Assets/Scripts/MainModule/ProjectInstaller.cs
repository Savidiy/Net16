using Zenject;

namespace MainModule
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ApplicationStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HackingApplicationState>().AsSingle();

            Container.BindInterfacesAndSelfTo<TickInvoker>().AsSingle();
        }
    }
}