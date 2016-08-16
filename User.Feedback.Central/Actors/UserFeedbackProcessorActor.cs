using System.Threading.Tasks;
using Akka.Actor;
using User.Feedback.Common;

namespace User.Feedback.Central.Actors
{
    public class UserFeedbackProcessorActor : ReceiveActor
    {
        private readonly IActorRef _persistenceActor;

        public UserFeedbackProcessorActor(IActorRef persistenceActor)
        {
            _persistenceActor = persistenceActor;

            Receive<Messages.TellUserFeedback>(tellUserFeedback => ProcessUserFeedback(tellUserFeedback));

            Receive<Messages.UserFeedbackCollectionRequest>(request => ProcessUserFeedbackCollectionRequest(request));
        }

        private void ProcessUserFeedback(Messages.TellUserFeedback tellUserFeedback)
        {
            _persistenceActor.Tell(tellUserFeedback);
        }

        private void ProcessUserFeedbackCollectionRequest(Messages.UserFeedbackCollectionRequest request)
        {
            _persistenceActor.Forward(request);
        }
    }
}
