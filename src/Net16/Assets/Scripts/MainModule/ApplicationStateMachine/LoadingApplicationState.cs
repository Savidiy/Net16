using UnityEngine;

namespace MainModule
{
    public sealed class LoadingApplicationState : IState, IApplicationState
    {
        private readonly ApplicationStateMachine _applicationStateMachine;
        private readonly InitialProgressData _initialProgressData;
        private readonly Mailbox _mailbox;
        private readonly MailFactory _mailFactory;
        private readonly IUIFactory _uiFactory;

        public LoadingApplicationState(ApplicationStateMachine applicationStateMachine, InitialProgressData initialProgressData,
            Mailbox mailbox, MailFactory mailFactory, IUIFactory uiFactory)
        {
            _applicationStateMachine = applicationStateMachine;
            _initialProgressData = initialProgressData;
            _mailbox = mailbox;
            _mailFactory = mailFactory;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            Debug.Log("Loading application");

            FillInitialProgress();
            _uiFactory.CreateUIRoot();

            _applicationStateMachine.EnterToState<HubApplicationState>();
        }

        private void FillInitialProgress()
        {
            foreach (MailId startMail in _initialProgressData.StartMails)
            {
                Mail mail = _mailFactory.CreateMail(startMail);
                _mailbox.AddMail(mail);
            }
        }
    }
}