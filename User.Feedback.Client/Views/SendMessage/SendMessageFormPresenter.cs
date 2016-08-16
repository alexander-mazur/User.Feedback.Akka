using System;
using System.Windows.Forms;

using User.Feedback.Client.Actors;
using User.Feedback.Client.Properties;
using User.Feedback.Common;

namespace User.Feedback.Client.Views.SendMessage
{
    public class SendMessageFormPresenter
    {
        public ISendMessageForm View { get; }

        public SendMessageFormPresenter(ISendMessageForm view)
        {
            View = view;

            View.MessageSent += OnMessageSent;
        }

        private void OnMessageSent(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(View.Message))
            {
                MessageBox.Show(Resources.SendMessageFormPresenter_EmptyMessageError, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserFeedbackClientActorSystem.Instance.UserFeedbackManager.TellUserFeedback(new UserFeedback(View.Message, DateTime.Now));

            View.Message = string.Empty;
        }
    }
}