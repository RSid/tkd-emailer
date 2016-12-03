using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKD.Emailer
{
    public partial class ComposeEmail : Form
    {
        public ComposeEmail()
        {
            InitializeComponent();
        }

        private void saveMessageAndPickRecipients_Click(object sender, EventArgs e)
        {
            Visible = false;

            var subjectValue = subject.Text;
            var bodyValue = body.Text;
            var newForm = new SearchForm(subjectValue, bodyValue)
            {
                Visible = true
            };

            newForm.Visible = true;
        }
    }
}
