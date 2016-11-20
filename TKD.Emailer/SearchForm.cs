using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TKD.Emailer.Models;
using TKD.Emailer.Services;
using static TKD.Emailer.Helpers.DataGridHelper;

namespace TKD.Emailer
{
    public partial class SearchForm : Form
    {
        private readonly DbService m_dbService;
        private const string ResultsGridName = "SearchResultsGrid";
        private const string SelectedColumnName = "Selected";
        private const string FirstNameColumnName = "First_Name";
        private const string LastNameColumnName = "Last_Name";
        private const string EmailColumnName = "Email";

        private static readonly string SelectSql = $@"SELECT personalprofiles.id, 
    personalprofiles.fname as {FirstNameColumnName}, 
    personalprofiles.lname as {LastNameColumnName}, 
    personalprofiles.email as {EmailColumnName}, 
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

            AddSendEmailButton();
            StyleResultsGrid(grid);
            resultsPanel.Controls.Add(grid);
        }

        private void SendResultsToSelectedButton_Click(object sender, EventArgs e)
        {
            var resultsGrid = resultsPanel.GetDataGridViewFromPanelByName(ResultsGridName);
           
            var selectedRecipients = new List<EmailRecipientDTO>();
            foreach (DataGridViewRow row in resultsGrid.Rows)
            {
                var boolValue = row.Cells[SelectedColumnName].Value as bool?;
                if (boolValue != null && boolValue.Value)
                {
                    var firstName = row.Cells.GetCellValueFromColumnHeader(FirstNameColumnName) as string;
                    var lastName = row.Cells.GetCellValueFromColumnHeader(LastNameColumnName) as string;
                    var email = row.Cells.GetCellValueFromColumnHeader(EmailColumnName) as string;
                    var recipient = new EmailRecipientDTO(firstName, lastName, email);
                    selectedRecipients.Add(recipient);
                }
            }
        }

        private void AddSendEmailButton()
        {
            var sendButton = new Button
            {
                Name = "SendResultsToSelected",
                Text = "Send to selected recipients"
            };
            sendButton.Click += SendResultsToSelectedButton_Click;
            SendEmailToSelectedPanel.Controls.Add(sendButton);
        }

        private void StyleResultsGrid(DataGridView grid)
        {
            AddSelectorColumn(grid);

            grid.AllowUserToResizeColumns = true;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = true;
            grid.Name = ResultsGridName;
            grid.MultiSelect = true;
            grid.Dock = DockStyle.Fill;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void AddSelectorColumn(DataGridView grid)
        {
            var selectorColumn = new DataGridViewCheckBoxColumn
            {
                Name = SelectedColumnName,
                Width = 60,
                HeaderText = string.Empty,
                Selected = false,
                FalseValue = false,
                TrueValue = true
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
