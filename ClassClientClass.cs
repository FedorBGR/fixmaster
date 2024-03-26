using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixmaster
{
    internal class ClassClientClass : DBconnection
    {
        static public DataTable dtClientClass = new DataTable();

        static public void GetClientClass()
        {
            try
            {
                msCommand.CommandText = "SELECT idclientclass AS 'Код класса', clientclassname AS 'Название класса' FROM clientclass";
                dtClientClass.Clear();
                msDataAdapter.SelectCommand = DBconnection.msCommand;
                msDataAdapter.Fill(dtClientClass);
            }

            catch
            {
                MessageBox.Show("Ошибка при получении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
