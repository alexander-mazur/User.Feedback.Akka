using System;
using System.Collections.Generic;

using User.Feedback.Common;

namespace User.Feedback.Client.Views.ViewMessages
{
    public interface IViewMessagesForm
    {
        event EventHandler MessagesRequested;

        IList<UserFeedback> UserFeedbacks { get; set; }
    }
}