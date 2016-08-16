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
            _userFeedbackRemoteReceiver.Tell(new Messages.TellUserFeedback(userFeedback));
        }

        public Task<Messages.UserFeedbackCollectionResponse> AskUserFeedbackCollection()
        {
            return _userFeedbackRemoteReceiver.Ask<Messages.UserFeedbackCollectionResponse>(new Messages.UserFeedbackCollectionRequest());
        }
    }
}