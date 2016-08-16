using System;
using System.Configuration;

using Akka.Actor;
using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Actors
{
    public class UserFeedbackClientActorSystem : IDisposable, IUserFeedbackClientActorSystem
    {
        public static UserFeedbackClientActorSystem Instance = new UserFeedbackClientActorSystem();

        private UserFeedbackClientActorSystem()
        {
            Initialize();
        }

        public ActorSystem ActorSystem { get; private set; }

        public IUserFeedbackBusinessLogicManager UserFeedbackManager { get; private set; }

        private void Initialize()
        {
            ActorSystem = ActorSystem.Create("User-Feedback-Client"); ;

            var userFeedbackRemoteReceiver = ActorSystem.ActorSelection(ConfigurationManager.AppSettings["UserFeedbackReceiver"]);

            UserFeedbackManager = new UserFeedbackBusinessLogicManager(userFeedbackRemoteReceiver);
        }

        public void Dispose()
        {
            ActorSystem.Terminate();
        }
    }
}
