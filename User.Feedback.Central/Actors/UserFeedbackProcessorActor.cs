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

            Receive<TellUserFeedbackMessage>(tellUserFeedback => ProcessTellUserFeedbackMessage(tellUserFeedback));

            Receive<RequestUserFeedbacksMessage>(request => ProcessRequestUserFeedbacksMessage(request));
        }

        private void ProcessTellUserFeedbackMessage(TellUserFeedbackMessage tellUserFeedbackMessage)
        {
            _persistenceActor.Tell(tellUserFeedbackMessage);
        }

        private void ProcessRequestUserFeedbacksMessage(RequestUserFeedbacksMessage message)
        {
            _persistenceActor.Forward(message);
        }
    }
}
