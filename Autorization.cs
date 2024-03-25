using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fixmaster
{
    internal class Autorization
    {
        static public string User, Name, Role;


        static public void Autorization1(string login, string password)
        {
            try
            {
                DBconnection.msCommand.CommandText = @"SELECT rolename from role , executor WHERE login = '" + login + "' and password = '" + password + "' and executor.idrole = role.idrole ";
                Object result = DBconnection.msCommand.ExecuteScalar();
                if (result != null)
                {
                    Role = result.ToString();
                    User = login;
                }
                else
                {
                    Role = null;
                    Name = null;
                }
            }
            catch
            {
                Role = User = null;
                MessageBox.Show("Ошибка при входе");
            }
        }
        static public string Famil(string login)
        {
            try
            {
                DBconnection.msCommand.CommandText = @"SELECT executorname FROM fixdb.executor WHERE login = '" + User + "'";
                Object result = DBconnection.msCommand.ExecuteScalar();
                Name = result.ToString();
                return Name;
            }
            catch
            {
                return null;
            }
        }
    }
}
