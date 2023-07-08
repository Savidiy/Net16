using Zenject;

namespace MainModule
{
    public class ProjectInstaller : MonoInstaller
    {
        public InitialProgressData InitialProgressData;
        public MailStaticDataLibrary MailStaticDataLibrary;
        public WindowConfigsData WindowConfigsData;
        
        public override void InstallBindings()
        {
            Container.BindInstance(InitialProgressData).AsSingle();
            Container.Bind<IMailStaticDataProvider>().FromInstance(MailStaticDataLibrary).AsSingle();
            Container.Bind<IWindowConfigProvider>().FromInstance(WindowConfigsData).AsSingle();
            
            Container.Bind<ApplicationStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HackingApplicationState>().AsSingle();

            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            
            Container.Bind<MailFactory>().AsSingle();
            Container.Bind<Mailbox>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TickInvoker>().AsSingle();
        }
    }
}