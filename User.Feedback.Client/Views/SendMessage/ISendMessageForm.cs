using System;
using User.Feedback.Client.BusinessObjects;

namespace User.Feedback.Client.Views.SendMessage
{
    public interface ISendMessageForm
    {
        string Message { get; set; }

        event EventHandler MessageSent;

        void Close();
    }
}