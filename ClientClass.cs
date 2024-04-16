using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fixmaster
{
    internal class ClientClass : DBconnection
    {
        static public DataTable dtClient = new DataTable();
        

        static public void GetClient()
        {
            try
            {
                msCommand.CommandText = "SELECT idclient AS 'Код клиента', clientname AS 'Имя', clientcontact AS 'Контактные данные', idclassclient AS 'Код класса' FROM client";
                dtClient.Clear();
                msDataAdapter.SelectCommand = DBconnection.msCommand;
                msDataAdapter.Fill(dtClient);
            }

            catch 
            {
                MessageBox.Show("Ошибка при получении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public bool addClient(string clientname, string clientcontact, string idclassclient)
        {
            try
            {
                msCommand.CommandText = "INSERT INTO client VALUES (null , '" + clientname + "', '" + clientcontact + "', '" +idclassclient+ "')";
                if (msCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool EditClient(string idclient, string clientcontact, string idclassclient, string clientname)
        {
            try
            {
                msCommand.CommandText = "UPDATE client SET idclient = '" + idclient + "', clientcontact = '" + clientcontact + "', clientname = '" + clientname + "', idclassclient = '" + idclassclient + "' WHERE idclient = '" + idclient + "'";
                

                if (msCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при редактировании записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public void deleteClient(string idclient)
        {
            try
            {
                msCommand.CommandText = "DELETE FROM client WHERE idclient = '" + idclient + "'";
                msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void searchClient(string ClientSearch)
        {
            try
            {
                msCommand.CommandText = @"SELECT idclient AS 'Код клиента', clientname AS 'Имя', clientcontact AS 'Контактные данные', idclassclient AS 'Код класса' FROM client WHERE concat (idclient, clientname, clientcontact) LIKE '%" + ClientSearch + "%' ";
                dtClient.Clear();
                msDataAdapter.SelectCommand = DBconnection.msCommand;
                msDataAdapter.Fill(dtClient);
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске", "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
