using System;
using User.Feedback.Client.Actors;

namespace User.Feedback.Client.Views.ViewMessages
{
    public class ViewMessagesFormPresenter
    {
        public IViewMessagesForm View { get; }

        public ViewMessagesFormPresenter(IViewMessagesForm view)
        {
            View = view;

            View.MessagesRequested += OnMessagesRequested;
        }

        private void OnMessagesRequested(object sender, EventArgs e)
        {
            UserFeedbackClientActorSystem.Instance.UserFeedbackManager.AskUserFeedbackCollection().ContinueWith(task =>
            {
                View.UserFeedbacks = task.Result.UserFeedbackCollection;
            });
        }
    }
}