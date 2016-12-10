using System;
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

        private const string ResultsGridName = "SearchResultsGrid";
        private const string SelectedColumnName = "Selected";
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            var checkedGenderButtonName = GenderPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Name;

            var checkedRankButtonName = RankPanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Name;

            var selectedCategoryValue = CategoryPanel.Controls.OfType<ComboBox>()
                .Single().SelectedValue as int?;

            var ageCategoryButtonName = AgePanel.Controls.OfType<RadioButton>()
                .First(radio => radio.Checked).Name;

            var sql = m_searchService.BuildSql(checkedRankButtonName, checkedGenderButtonName,
                selectedCategoryValue, ageCategoryButtonName);
            var grid = m_searchService.Search(sql);

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

            foreach (DataGridViewRow row in resultsGrid.Rows)
            {
                row.Cells[SelectedColumnName].Value = selectAll;
            }
        }
    }
}
