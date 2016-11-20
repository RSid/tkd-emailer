using System;
using System.Linq;
using System.Windows.Forms;
using TKD.Emailer.Services;

namespace TKD.Emailer
{
    public partial class SearchForm : Form
    {
        private readonly DbService m_dbService;
        private const string SelectSql = @"SELECT personalprofiles.id, 
    personalprofiles.fname as First_Name, 
    personalprofiles.lname as Last_Name, 
    personalprofiles.email, 
    personalprofiles.NextRank,
    ranks.rorder as NextRankOrder 
FROM personalprofiles  
    INNER JOIN ranks ON personalprofiles.NextRank=ranks.name
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
            sql = ApplyRankSelectors(sql);

            sql += " ORDER BY lName";
            var grid = m_dbService.Search(sql);
            grid.Dock = DockStyle.Fill;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            resultsPanel.Controls.Add(grid);
        }

        private string ApplyRankSelectors(string sql)
        {
            var checkedRankButton = RankPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked);

            string rankFilterString = null;
            if (checkedRankButton.Name == "ColorBeltsRadioButton")
            {
                rankFilterString = " AND rorder < 11";
            }
            if (checkedRankButton.Name == "BlackBeltsRadioButton")
            {
                rankFilterString = " AND rorder > 10";
            }
            if (rankFilterString !=null)
            {
                sql += rankFilterString;
            }

            return sql;
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
