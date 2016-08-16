using System;

using User.Feedback.Client.Views.SendMessage;
using User.Feedback.Client.Views.ViewMessages;

namespace User.Feedback.Client.Views.Main
{
    public class MainFormPresenter 
    {
        private ViewMessagesForm _viewMessagesForm;
        private SendMessageForm _sendMessageForm;

        public IMainForm View { get; }

        public ViewMessagesForm ViewMessagesForm => _viewMessagesForm ?? (_viewMessagesForm = new ViewMessagesForm());

        public SendMessageForm SendMessageForm => _sendMessageForm ?? (_sendMessageForm = new SendMessageForm());

        public MainFormPresenter(IMainForm view)
        {
            View = view;

            View.ShowSendMessageForm += OnShowSendMessageForm;
            View.ShowViewMessagesForm += OnShowViewMessagesForm;
        }

        private void OnShowViewMessagesForm(object sender, EventArgs e)
        {
            ViewMessagesForm.Show();
        }

        private void OnShowSendMessageForm(object sender, EventArgs e)
        {
            SendMessageForm.Show();
        }
    }
}