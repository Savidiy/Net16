using Zenject;

namespace MainModule
{
    public class ProjectInstaller : MonoInstaller
    {
        public InitialProgressData InitialProgressData;
        public MailsStaticData MailsStaticData;
        
        public override void InstallBindings()
        {
            Container.BindInstance(InitialProgressData).AsSingle();
            Container.Bind<IMailsStaticDataProvider>().FromInstance(MailsStaticData).AsSingle();
            
            Container.Bind<ApplicationStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HackingApplicationState>().AsSingle();

            Container.Bind<MailFactory>().AsSingle();
            Container.Bind<Mailbox>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TickInvoker>().AsSingle();
        }
    }
}