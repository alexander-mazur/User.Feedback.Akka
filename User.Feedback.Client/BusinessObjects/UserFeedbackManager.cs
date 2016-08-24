using System;
using System.Configuration;
using System.Threading.Tasks;

using Akka.Actor;

using User.Feedback.Client.Actors;
using User.Feedback.Common;
using User.Feedback.Common.Messages;

namespace User.Feedback.Client.BusinessObjects
{
    public class UserFeedbackManager : IUserFeedbackManager
    {
        private readonly ActorSelection _userFeedbackRemoteActor;
        private readonly IActorRef _userFeedbackUpdateActor;

        public UserFeedbackManager(ActorSystem actorSystem)
        {
            _userFeedbackRemoteActor = actorSystem.ActorSelection(ConfigurationManager.AppSettings["UserFeedbackReceiver"]);
            _userFeedbackUpdateActor = actorSystem.ActorOf(Props.Create(() => new UserFeedbackUpdateActor(this)), "UserFeedbackUpdate");
        }

        public void TellUserFeedback(UserFeedback userFeedback)
        {
            _userFeedbackRemoteActor.Tell(new TellUserFeedbackMessage(userFeedback));
        }

        public Task<ReplyUserFeedbacksMessage> AskUserFeedbackCollection()
        {
            return _userFeedbackRemoteActor.Ask<ReplyUserFeedbacksMessage>(new RequestUserFeedbacksMessage());
        }

        public void SubscribeToUserFeedbackUpdates()
        {
            _userFeedbackRemoteActor.Tell(new SubscribeToUserFeedbackUpdateMessage(_userFeedbackUpdateActor));
        }

        public void UnsubscribeFromUserFeedbackUpdates()
        {
            _userFeedbackRemoteActor.Tell(new UnsubscribeFromUserFeedbackUpdateMessage(_userFeedbackUpdateActor));
        }

        public void RaiseUserFeedbackUpdate(UserFeedback userFeedback)
        {
            UserFeedbackUpdated?.Invoke(this, userFeedback);
        }

        public event EventHandler<UserFeedback> UserFeedbackUpdated;
    }
}