using System;
using System.Threading.Tasks;
using User.Feedback.Common;

namespace User.Feedback.Client.BusinessObjects
{
    public interface IUserFeedbackManager
    {
        void TellUserFeedback(UserFeedback userFeedback);

        Task<ReplyUserFeedbacksMessage> AskUserFeedbackCollection();

        void SubscribeToUserFeedbackUpdates();

        void UnsubscribeFromUserFeedbackUpdates();

        void RaiseUserFeedbackUpdate(UserFeedback userFeedback);

        event EventHandler<UserFeedback> UserFeedbackUpdated;
    }
}