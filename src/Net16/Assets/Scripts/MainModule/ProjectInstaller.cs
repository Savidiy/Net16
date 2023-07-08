using Zenject;

namespace MainModule
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ApplicationStateMachine>().AsSingle();
            Container.Bind<HackingApplicationState>().AsSingle();

            Container.BindInterfacesAndSelfTo<TickInvoker>().AsSingle();
        }
    }
}