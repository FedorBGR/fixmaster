using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixmaster
{
    internal class PartClass : DBconnection
    {

        static public DataTable dtPart = new DataTable();


        static public void GetPart()
        {
            try
            {
                msCommand.CommandText = "SELECT idparts AS 'Код детали', partsname AS 'Название детали', partsdescription AS 'Описание детали', partscol AS 'Кол-во, ШТ.', partscost AS 'Цена, РУБ.' FROM parts";
                dtPart.Clear();
                msDataAdapter.SelectCommand = DBconnection.msCommand;
                msDataAdapter.Fill(dtPart);
            }

            catch
            {
                MessageBox.Show("Ошибка при получении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public bool addPart(string partsname, string partsdescription, string partscol, string partscost)
        {
            try
            {
                msCommand.CommandText = "INSERT INTO parts VALUES (null , '" + partsname + "', '" + partsdescription + "', '" + partscol + "', '" + partscost + "')";
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

        static public bool EditPart(string idparts, string partsname, string partsdescription, string partscol, string partscost)
        {
            try
            {
                msCommand.CommandText = "UPDATE parts SET idparts = '" + idparts + "', partsname = '" + partsname + "', partsdescription = '" + partsdescription + "', partscol = '" + partscol + "', partscost = '" + partscost + "' WHERE idparts = '" + idparts + "'";


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

        static public void deletePart(string idparts)
        {
            try
            {
                msCommand.CommandText = "DELETE FROM parts WHERE idparts = '" + idparts + "'";
                msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
