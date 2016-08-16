using System.Collections.Generic;
using Akka.Actor;
using User.Feedback.Common;

namespace User.Feedback.Central.Actors
{
    public class UserFeedbackPersistenceActor : ReceiveActor
    {
        private readonly IList<UserFeedback> _userFeedbacks = new List<UserFeedback>();

        public UserFeedbackPersistenceActor()
        {
            Receive<Messages.TellUserFeedback>(tellUserFeedback => _userFeedbacks.Add(tellUserFeedback.UserFeedback));

            Receive<Messages.UserFeedbackCollectionRequest>(request =>
                                                            {
                                                                var result = new Messages.UserFeedbackCollectionResponse(_userFeedbacks);
                                                                Sender.Tell(result, Self);
                                                            });
        }
    }
}
