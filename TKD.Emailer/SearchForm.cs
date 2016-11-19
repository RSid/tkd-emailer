using System;
using System.Linq;
using System.Windows.Forms;
using TKD.Emailer.Services;

namespace TKD.Emailer
{
    public partial class SearchForm : Form
    {
        private readonly DbService m_dbService;
        private const string SelectSql = @"SELECT pp.id, pp.fname as First_Name, pp.lname as Last_Name, pp.email, pp.NextRank 
FROM personalprofiles pp 
WHERE email LIKE '%@%' ";

        public SearchForm()
        {
            m_dbService = new DbService();
            
            InitializeComponent();
        }
        
        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var sql = SelectSql;

            sql = ApplyGenderSelectors(sql);

            sql += " ORDER BY lName";
            var grid = m_dbService.Search(sql);
            grid.Dock = DockStyle.Fill;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            resultsPanel.Controls.Add(grid);
        }

        private string ApplyGenderSelectors(string sql)
        {
            var checkedGenderButton = GenderPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked);

            string selectedGenderStrings = null;
            if (checkedGenderButton.Name == "FemaleRadioButton")
            {
                selectedGenderStrings = "'F', 'Female', 'Fenmale'";
            }
            if (checkedGenderButton.Name == "MaleRadioButton")
            {
                selectedGenderStrings = "'M', 'Male'";
            }

            if (selectedGenderStrings != null)
            {
                sql += $" AND sex IN ({selectedGenderStrings})";
            }
            return sql;
        }
    }
}
