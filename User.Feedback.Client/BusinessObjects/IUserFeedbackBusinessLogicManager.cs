using System.Threading.Tasks;
using User.Feedback.Common;

namespace User.Feedback.Client.BusinessObjects
{
    public interface IUserFeedbackBusinessLogicManager
    {
        void TellUserFeedback(UserFeedback userFeedback);

        Task<ReplyUserFeedbacksMessage> AskUserFeedbackCollection();
    }
}