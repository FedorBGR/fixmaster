using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace fixmaster
{
    internal class DBconnection
    {
        static string DBconnect = "server = localhost; user = root; password = root; database = fixdb";
        static public MySqlDataAdapter msDataAdapter;
        static public MySqlConnection myconnect;
        static public MySqlCommand msCommand;


        public static bool ConnectionDB()
        {
            try
            {
                myconnect = new MySqlConnection(DBconnect);
                myconnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = myconnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CloseDB()
        {
            myconnect.Close();
        }

        public MySqlConnection getConnection()
        {
            return myconnect;
        }

    }
}
