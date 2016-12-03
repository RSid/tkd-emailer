using System;
using System.Windows.Forms;

namespace TKD.Emailer
{
    public partial class ComposeEmail : Form
    {
        public bool CanSendEmail = true;

        public ComposeEmail()
        {
            InitializeComponent();
        }

        private void saveMessageAndPickRecipients_Click(object sender, EventArgs e)
        {
            Visible = false;

            var subjectValue = subject.Text;
            var bodyValue = body.Text;

            var emailIsEmpty = string.IsNullOrEmpty(subjectValue) && string.IsNullOrEmpty(bodyValue);

            if (emailIsEmpty)
            {
                CanSendEmail = false;
                var warningDialog = MessageBox.Show(
                    "You have not included an email subject or body! Please add one.",
                    "Empty email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);

                if (warningDialog == DialogResult.OK)
                {
                    Visible = true;
                }
            }

            if ((string.IsNullOrEmpty(subjectValue) || string.IsNullOrEmpty(bodyValue))
                && !emailIsEmpty)
            {
                var warningDialog = MessageBox.Show(
                    "Either your email subject or body is empty! Are you sure you want to proceed?",
                    "Missing fields",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if(warningDialog == DialogResult.No)
                {
                    Visible = true;
                    return;
                }
            }

            if (CanSendEmail)
            {
                var newForm = new SearchForm(subjectValue, bodyValue)
                {
                    Visible = true
                };

                newForm.Visible = true;
            }
        }
    }
}
