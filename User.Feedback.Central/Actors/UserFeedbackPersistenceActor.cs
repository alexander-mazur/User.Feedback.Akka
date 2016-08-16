﻿using System.Collections.Generic;
using Akka.Actor;
using User.Feedback.Common;

namespace User.Feedback.Central.Actors
{
    public class UserFeedbackPersistenceActor : ReceiveActor
    {
        private readonly IList<UserFeedback> _userFeedbacks = new List<UserFeedback>();

        public UserFeedbackPersistenceActor()
        {
            Receive<TellUserFeedbackMessage>(tellUserFeedback => _userFeedbacks.Add(tellUserFeedback.UserFeedback));

            Receive<RequestUserFeedbacksMessage>(request =>
            {
                var result = new ReplyUserFeedbacksMessage(_userFeedbacks);
                Sender.Tell(result, Self);
            });
        }
    }
}
