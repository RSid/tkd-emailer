using System.IO;
using System.Windows.Forms;

namespace TKD.Emailer
{
    public class Config
    {
        public static string ConnectionString => GetConnectionString();

        private static string GetConnectionString()
        {
            string fileLocation = null;
            try
            {
                var objstream = new StreamReader("C:\\Program Files (x86)\\TKD.Emailer\\dbLocation.ini");
                fileLocation = objstream.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + " You will need to add it with the filepath to the db as the first and only line.");
            }

            return @"Provider=Microsoft.Jet.OLEDB.4.0;"
                   + $@"Data source= {fileLocation};"
                   + @"Jet OLEDB:Database Password=05398;";
        }
    }
}