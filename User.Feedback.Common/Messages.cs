using System.Collections.Generic;

namespace User.Feedback.Common
{
    public class TellUserFeedbackMessage
    {
        public UserFeedback UserFeedback { get; private set; }

        public TellUserFeedbackMessage(UserFeedback userFeedback)
        {
            UserFeedback = userFeedback;
        }
    }

    public class RequestUserFeedbacksMessage { }

    public class ReplyUserFeedbacksMessage
    {
        public IList<UserFeedback> UserFeedbacks { get; private set; }

        public ReplyUserFeedbacksMessage(IList<UserFeedback> userFeedbacks)
        {
            UserFeedbacks = userFeedbacks;
        }
    }
}

