using System.Linq;
using System.Windows.Forms;

namespace TKD.Emailer.Helpers
{
    public static class DataGridHelper
    {
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
    }
}
