using Zenject;

namespace MainModule
{
    public class ProjectInstaller : MonoInstaller
    {
        public InitialProgressData InitialProgressData;
        public MailStaticDataLibrary MailStaticDataLibrary;
        public WindowConfigsData WindowConfigsData;
        public FilesStaticDataLibrary FilesStaticDataLibrary;
        public LinksStaticDataLibrary LinksStaticDataLibrary;
        
        public override void InstallBindings()
        {
            Container.BindInstance(InitialProgressData).AsSingle();
            Container.Bind<IMailStaticDataProvider>().FromInstance(MailStaticDataLibrary).AsSingle();
            Container.Bind<IWindowConfigProvider>().FromInstance(WindowConfigsData).AsSingle();
            Container.Bind<IFileStaticDataProvider>().FromInstance(FilesStaticDataLibrary).AsSingle();
            Container.Bind<ILinkStaticDataProvider>().FromInstance(LinksStaticDataLibrary).AsSingle();
            
            Container.Bind<ApplicationStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HubApplicationState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HackingApplicationState>().AsSingle();

            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            
            Container.Bind<Inventory>().AsSingle();
            Container.Bind<AttachmentTypeTextProvider>().AsSingle();
            Container.Bind<MailFactory>().AsSingle();
            Container.Bind<Mailbox>().AsSingle();
            Container.Bind<TextTagFilter>().AsSingle();
        }
    }
}