using System;
using System.Drawing;
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
            StyleResultsGrid(grid);
            
            resultsPanel.Controls.Add(grid);
        }

        private void StyleResultsGrid(DataGridView grid)
        {
            AddSelectorColumn(grid);

            grid.AllowUserToResizeColumns = true;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = true;
            grid.Name = "SearchResultsGrid";
            grid.MultiSelect = true;
            grid.Dock = DockStyle.Fill;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void AddSelectorColumn(DataGridView grid)
        {
            var selectorColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Selected",
                Width = 60,
                HeaderText = string.Empty,
                Selected = false
            };

            grid.Columns.Add(selectorColumn);

            var checkbox = new CheckBox
            {
                Size = new Size(45, 15),
                BackColor = Color.Transparent,
                Padding = new Padding(0),
                Margin = new Padding(0),
                Name = "SelectAll",
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "All"
            };

            grid.Controls.Add(checkbox);
            DataGridViewHeaderCell header = grid.Columns[selectorColumn.Index].HeaderCell;
            checkbox.Location = new Point(
                header.ContentBounds.Left + (header.ContentBounds.Right - header.ContentBounds.Left + checkbox.Size.Width) / 2,
                header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + checkbox.Size.Height) / 2
            );
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
