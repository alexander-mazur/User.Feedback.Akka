using System.Threading.Tasks;
using Akka.Actor;
using User.Feedback.Common;

namespace User.Feedback.Client.BusinessObjects
{
    public class UserFeedbackBusinessLogicManager : IUserFeedbackBusinessLogicManager
    {
        private readonly ActorSelection _userFeedbackRemoteReceiver;

        public UserFeedbackBusinessLogicManager(ActorSelection userFeedbackRemoteReceiver)
        {
            _userFeedbackRemoteReceiver = userFeedbackRemoteReceiver;
        }

        public void TellUserFeedback(UserFeedback userFeedback)
        {
            _userFeedbackRemoteReceiver.Tell(new TellUserFeedbackMessage(userFeedback));
        }

        public Task<ReplyUserFeedbacksMessage> AskUserFeedbackCollection()
        {
            return _userFeedbackRemoteReceiver.Ask<ReplyUserFeedbacksMessage>(new RequestUserFeedbacksMessage());
        }
    }
}