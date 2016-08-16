using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Actors
{
    public interface IUserFeedbackClientActorSystem
    {
        IUserFeedbackBusinessLogicManager UserFeedbackManager { get; }
    }
}