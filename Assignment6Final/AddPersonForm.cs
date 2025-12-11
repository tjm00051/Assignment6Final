using System;
using System.Windows.Forms;

namespace Assignment6Final
{
    public partial class AddPersonForm : Form
    {
        public Person CreatedPerson { get; private set; }

        public AddPersonForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CreatedPerson = new Person
            {
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
