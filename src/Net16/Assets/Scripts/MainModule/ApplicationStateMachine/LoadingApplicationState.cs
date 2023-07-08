using UnityEngine;

namespace MainModule
{
    public sealed class LoadingApplicationState : IState, IApplicationState
    {
        private readonly ApplicationStateMachine _applicationStateMachine;
        private readonly InitialProgressData _initialProgressData;
        private readonly Mailbox _mailbox;
        private readonly MailFactory _mailFactory;

        public LoadingApplicationState(ApplicationStateMachine applicationStateMachine, InitialProgressData initialProgressData,
            Mailbox mailbox, MailFactory mailFactory)
        {
            _applicationStateMachine = applicationStateMachine;
            _initialProgressData = initialProgressData;
            _mailbox = mailbox;
            _mailFactory = mailFactory;
        }

        public void Enter()
        {
            Debug.Log("Loading application");
            
            foreach (MailId startMail in _initialProgressData.StartMails)
            {
                Mail mail = _mailFactory.CreateMail(startMail);
                _mailbox.AddMail(mail);
            }
            
            _applicationStateMachine.EnterToState<HubApplicationState>();
        }
    }
}