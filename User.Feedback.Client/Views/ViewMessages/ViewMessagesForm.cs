using System;
using System.Collections.Generic;
using System.Windows.Forms;

using User.Feedback.Client.BusinessObjects;
using User.Feedback.Common;

namespace User.Feedback.Client.Views.ViewMessages
{
    public partial class ViewMessagesForm : Form, IViewMessagesForm
    {
        public ViewMessagesFormPresenter Presenter { get; set; }

        public IList<UserFeedback> UserFeedbacks
        {
            get { return userFeedbackBindingSource.DataSource as IList<UserFeedback>; }
            set
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => UserFeedbacks = value));
                }
                else
                {
                    userFeedbackBindingSource.DataSource = value;
                }
            }
        }

        public ViewMessagesForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Presenter = new ViewMessagesFormPresenter(this);
        }

        public event EventHandler MessagesRequested
        {
            add { getMessagesButton.Click += value; }
            remove { getMessagesButton.Click += value; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
