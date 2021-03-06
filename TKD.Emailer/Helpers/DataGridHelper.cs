﻿using System.Linq;
using System.Windows.Forms;

namespace TKD.Emailer.Helpers
{
    public static class DataGridHelper
    {
        /// <summary>
        /// Datagridview column name constants
        /// </summary>
        internal const string FirstNameColumnName = "First_Name";
        internal const string LastNameColumnName = "Last_Name";
        internal const string EmailColumnName = "Email";

        /// <summary>
        /// From http://stackoverflow.com/questions/13436553/how-to-get-cell-value-of-datagridview-by-column-name
        /// cred Patrick Quirk
        /// </summary>
        /// <param name="CellCollection"></param>
        /// <param name="HeaderText"></param>
        /// <returns></returns>
        public static object GetCellValueFromColumnHeader(this DataGridViewCellCollection CellCollection, string HeaderText)
        {
            return CellCollection.Cast<DataGridViewCell>().First(c => c.OwningColumn.HeaderText == HeaderText).Value;
        }

        public static DataGridView GetDataGridViewFromPanelByName(this Panel panel, string gridName)
        {
            var control = panel.Controls.Find(gridName, true);
            var grid = (DataGridView)control.FirstOrDefault();
            return grid;
        }

        public static void ChangeCheckBoxColumnValue(this DataGridView grid, bool checkBoxValue)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Cells[SearchForm.SelectedColumnName].Value = checkBoxValue;
            }
        }
    }
}
