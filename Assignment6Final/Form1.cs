using System;
using System.Linq;
using System.Windows.Forms;

namespace Assignment6Final
{
    public partial class Form1 : Form
    {
        private readonly IPersonDataSource _dataSource;

        public Form1(IPersonDataSource dataSource)
        {
            InitializeComponent();
            _dataSource = dataSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            personBindingSource.DataSource = _dataSource.GetPeople(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var dlg = new AddPersonForm();
            if (dlg.ShowDialog() == DialogResult.OK && dlg.CreatedPerson != null)
            {
                _dataSource.Add(dlg.CreatedPerson);
                _dataSource.SaveChanges();
                RefreshGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (personBindingSource.Current is Person p)
            {
                _dataSource.Delete(p);
                _dataSource.SaveChanges();
                RefreshGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            personBindingSource.EndEdit();
            _dataSource.SaveChanges();
            RefreshGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
