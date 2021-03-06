﻿using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly string m_subject;
        private readonly string m_body;
        private readonly SearchService m_searchService;
        private readonly EmailService m_emailService;
        private readonly DbService m_dbService;
        public static int MinAdult;
        public static string BlackBeltClubText = "Black Belt Club";
        public static string FoundersClubText = "Founders Club";
        public static string ChildrenText = "Children";
        public static string AdultsText = "Adults";
        public static string AgeRangeText = "Age Range (inclusive)";
        public static string BeltRangeText = "Belt Range";
        private const string RankMaximumSelector = "rankMaximumSelector";
        private const string RankMinimumSelector = "rankMinimumSelector";

        private const string ResultsGridName = "SearchResultsGrid";
        internal const string SelectedColumnName = "Selected";
        private const string CategorySelector = "CategorySelector";

        public const string AllConstant = "All";
        public const int NoneId = 0;

        public SearchForm(string subject, string body)
        {
            m_subject = subject;
            m_body = body;

            m_dbService = new DbService();
            m_searchService = new SearchService(m_dbService);
            m_emailService = new EmailService();
            InitializeComponent();

            CreateCategoryDropdown(m_dbService);
            MinAdult = GetMinimumAgeForAdults();

            CreateRankDropdowns(m_dbService);
        }

        private int GetMinimumAgeForAdults()
        {
            var schoolAdultMin = "SELECT adultmin FROM school";
            var adultMin = m_dbService.QueryDatabase(schoolAdultMin);
            var minByte = adultMin.Tables[0].Rows[0].Field<byte>("adultmin");
            return Convert.ToInt32(minByte);
        }

        private void CreateCategoryDropdown(DbService dbService)
        {
            var categories = dbService.GetCategories();
            var allRow = categories.NewRow();
            allRow["description"] = AllConstant;
            allRow["id"] = NoneId;
            categories.Rows.InsertAt(allRow,0);

            var categoryDropDown = new ComboBox()
            {
                DataSource = categories,
                DisplayMember = "description",
                ValueMember = "id",
                Location = new Point(0, 20),
                Name = CategorySelector,
                Size = new Size(100, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            CategoryPanel.Controls.Add(categoryDropDown);
        }

        private void CreateRankDropdowns(DbService dbService)
        {
            var toRanks = dbService.GetRankAndOrder();
            var fromRanks = dbService.GetRankAndOrder();
            var rankToLabel = new Label
            {
                Text = "To",
                Name = "rankToLabel",
                Location = new Point(13, 117),
                Size = new Size(100, 15)
            };
            var rankDropDownTo = new ComboBox()
            {
                DataSource = toRanks,
                DisplayMember = "name",
                ValueMember = "rorder",
                Location = new Point(13, 132),
                Name = RankMinimumSelector,
                Size = new Size(100, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            var rankFromLabel = new Label
            {
                Text = "From",
                Name = "rankFromLabel",
                Location = new Point(13, 154),
                Size = new Size(100, 15)
            };
            var rankDropDownFrom = new ComboBox()
            {
                DataSource = fromRanks,
                DisplayMember = "name",
                ValueMember = "rorder",
                Location = new Point(13, 169),
                Name = RankMaximumSelector,
                Size = new Size(100, 21),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            RankPanel.Controls.Add(rankToLabel);
            RankPanel.Controls.Add(rankDropDownTo);
            RankPanel.Controls.Add(rankFromLabel);
            RankPanel.Controls.Add(rankDropDownFrom);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ClearPriorResults();

            var checkedGenderButtonName = GenderPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Name;

            var checkedRankButtonName = RankPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Name;

            var selectedCategoryValue = CategoryPanel.Controls.OfType<ComboBox>()
                .Single().SelectedValue as int?;
            
            var ageCategoryButtonText = AgePanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Text;

            var clubMembershipButtonText = MembershipPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Text;

            int? ageMax;
            var ageMin = GetAgeMinAndMax(ageCategoryButtonText, out ageMax);

            int? rankMax;
            var rankMin = GetRankMinAndMax(checkedRankButtonName, out rankMax);
            
            var sql = m_searchService.BuildSql(checkedRankButtonName, 
                rankMin,
                rankMax,
                checkedGenderButtonName,
                selectedCategoryValue, 
                ageCategoryButtonText, 
                ageMin, 
                ageMax, 
                clubMembershipButtonText);
            var grid = m_searchService.Search(sql);

            AddSendEmailButton();
            StyleResultsGrid(grid);
            resultsPanel.Controls.Add(grid);
        }

        private int? GetRankMinAndMax(string checkedRankButtonName, out int? rankMax)
        {
            int? rankMin = null;
            rankMax = null;
            if (checkedRankButtonName == "beltRangeButton")
            {
                rankMin = Convert.ToInt32(RankPanel.Controls.OfType<ComboBox>()
                    .First(comboBox => comboBox.Name == RankMinimumSelector).SelectedValue);
                rankMax = Convert.ToInt32(RankPanel.Controls.OfType<ComboBox>()
                    .First(comboBox => comboBox.Name == RankMaximumSelector).SelectedValue);
            }
            return rankMin;
        }

        private int? GetAgeMinAndMax(string ageCategoryButtonText, out int? ageMax)
        {
            int? ageMin = null;
            ageMax = null;
            if (ageCategoryButtonText == AgeRangeText)
            {
                ageMin = Convert.ToInt32(AgePanel.Controls.OfType<NumericUpDown>()
                    .Single(numeric => numeric.Name == "ageMinInput")
                    .Value);
                ageMax = Convert.ToInt32(AgePanel.Controls.OfType<NumericUpDown>()
                    .Single(numeric => numeric.Name == "ageMaxInput")
                    .Value);
            }
            return ageMin;
        }

        private void ClearPriorResults()
        {
            var resultsGrid = resultsPanel.GetDataGridViewFromPanelByName(ResultsGridName);

            if (resultsGrid != null)
            {
                resultsPanel.Controls.Remove(resultsGrid);
            }
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

            var results = m_emailService.SendEmail(selectedRecipients, m_subject, m_body);

            if (results.Errors.Any())
            {
                var firstError = results.Errors.First();
                var dlgRes =  MessageBox.Show(
                    firstError.Message
                    + "exception message: " 
                        + firstError.FullException.Message,
                    firstError.FullException.GetType().ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);

                if (dlgRes == DialogResult.OK) { Application.Exit(); }
            }
        }

        private void AddSendEmailButton()
        {
            var sendButton = new Button
            {
                Name = "SendResultsToSelected",
                Text = "Send to selected recipients",
                Width = 150
            };
            sendButton.Click += SendResultsToSelectedButton_Click;
            SendEmailToSelectedPanel.Controls.Add(sendButton);
        }

        private void StyleResultsGrid(DataGridView grid)
        {
            AddSelectorColumn(grid);
            grid.CurrentCell = null;
            grid.CurrentCellChanged += SelectionChange;
            
            grid.AllowUserToResizeColumns = true;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = true;
            grid.Name = ResultsGridName;
            grid.Dock = DockStyle.Fill;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private static void SelectionChange(object sender, EventArgs e)
        {
            var grid = (DataGridView)sender;
            grid.ChangeCheckBoxColumnValue(false);

            var selectedCells = grid.SelectedCells;
            foreach (var selectedCell in selectedCells)
            {
                var cell = selectedCell as DataGridViewCell;
                var selectedRow = cell.OwningRow;
                var checkboxCellForRow = selectedRow.Cells[0];
                checkboxCellForRow.Selected = cell.Selected;
                checkboxCellForRow.Value = cell.Selected;
            }
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
            checkbox.Click += SelectAllCheckbox_Click;
            grid.Controls.Add(checkbox);
            DataGridViewHeaderCell header = grid.Columns[selectorColumn.Index].HeaderCell;
            checkbox.Location = new Point(
                header.ContentBounds.Left + (header.ContentBounds.Right - header.ContentBounds.Left + checkbox.Size.Width) / 2,
                header.ContentBounds.Top + (header.ContentBounds.Bottom - header.ContentBounds.Top + checkbox.Size.Height) / 2
            );
        }

        private void SelectAllCheckbox_Click(object sender, EventArgs e)
        {
            var resultsGrid = resultsPanel.GetDataGridViewFromPanelByName(ResultsGridName);

            var selectAll = ((CheckBox)sender).Checked;
            resultsGrid.ChangeCheckBoxColumnValue(selectAll);
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
