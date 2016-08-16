using System.Collections.Generic;

namespace User.Feedback.Common
{
    public class Messages
    {
        public class UserFeedbackCollectionRequest { }

        public class TellUserFeedback
        {
            public UserFeedback UserFeedback { get; private set; }

            public TellUserFeedback(UserFeedback userFeedback)
            {
                UserFeedback = userFeedback;
            }
        }

        public class UserFeedbackCollectionResponse
        {
            public IList<UserFeedback> UserFeedbackCollection { get; private set; }

            public UserFeedbackCollectionResponse(IList<UserFeedback> userFeedbackCollection)
            {
                UserFeedbackCollection = userFeedbackCollection;
            }
        }
    }
}

