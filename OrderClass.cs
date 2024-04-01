using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace fixmaster
{
    internal class OrderClass: DBconnection
    {
        static public DataTable dtZakaz = new DataTable();

        static public void GetZakaz()
        {
            try
            {
                msCommand.CommandText = @"SELECT idorder AS 'Номер закзаа', idclient AS 'Код клиента', idproduct AS 'Код изделия', orderdate AS 'Дата оформления', orderstatus AS 'Статус выполнения', idexecutor AS 'Код исполнителя', idparts AS 'Код деталей', repaircost AS 'Цена выполения. Руб', ordercol AS 'Количесвто деталей' FROM fixdb.order";
                dtZakaz.Clear();
                msDataAdapter.SelectCommand = DBconnection.msCommand;
                msDataAdapter.Fill(dtZakaz);


            }
            catch
            {
                MessageBox.Show("Ошибка при получении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public bool addZakaz(int idclient, string idproduct, string orderstatus, int idexecutor, string idparts, int repaircost, string ordercol)
        {
            string v = msCommand.CommandText = "SELECT partscost FROM parts WHERE idparts = '" + idparts + "'";
            try
            {
                msCommand.CommandText = "INSERT INTO fixdb.order VALUES (null , '" + idclient + "', '" + idproduct + "', default , '" + orderstatus + "', '" + idexecutor + "', '" + idparts + "', '" + repaircost + "', '" + ordercol+ "')";
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

        static public bool addTovartoZakaz(int idorder, string idproduct, string idparts, int ordercost, string ordercol)
        {
            string v = msCommand.CommandText = "SELECT idproduct FROM fixdb.order WHERE idorder = '" + idorder + "'";
            string b = msCommand.CommandText = "SELECT ordercost FROM fixdb.order WHERE idorder = '" + idorder + "'";
            string c = msCommand.CommandText = "SELECT idparts FROM fixdb.order WHERE idorder = '" + idorder + "'";
            string g = msCommand.CommandText = "SELECT ordercol FROM fixdb.order WHERE idorder = '" + idorder + "'";

            try
            {
                msCommand.CommandText = "UPDATE fixdb.order SET idparts =  '" + idparts + "' , repaircost = '" + ordercost + "', idproduct = '" + idproduct + "', ordercol = '" + ordercol + "' WHERE idorder = '" + idorder + "'";

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
                MessageBox.Show("Ошибка при добавлении в заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool EditZakaz(int idorder, int idclient, string idproduct, string orderstatus, string idexecutor, string idparts)
        {
            try
            {
                msCommand.CommandText = "UPDATE fixdb.order SET idorder = '" + idorder + "', idclient = '" + idclient + "', idproduct = '" + idproduct + "', orderstatus = '" + orderstatus + "', idexecutor = '" + idexecutor + "', idparts = '" + idparts + "' WHERE idorder = '" + idorder + "'";
                //"UPDATE zakazy SET id_tovar = '" + id_tovar + "' , client_name = '" + client_name + "' , client_surname = '" + client_surname + "' , client_otch = '" + client_otch + "', id_empl = '" + id_empl + "', zakaz_ststus = '" +zakaz_status+ "' WHERE id_zakaz = '" + id_zakaz + "'";

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

        static public void deleteZakaz(string idorder)
        {
            try
            {
                

                string b = "SELECT ordercol FROM fixdb.order WHERE idorder = '" + idorder + "'";
                msCommand.CommandText = b;
                var bres = msCommand.ExecuteNonQuery();
                string bcol = bres.ToString();
                string[] col = bcol.Split(';');

                string n = "SELECT idparts FROM fixdb.order WHERE idorder = '" + idorder + "'";
                msCommand.CommandText = n;
                var nres = msCommand.ExecuteNonQuery();
                string nidparts = bres.ToString();
                string[] idp = nidparts.Split(';');

                for (int i = 0; i < idp.Length; i++)
                {


                    int coli = int.Parse(col[i]);

                    

                    int idpar = int.Parse(idp[i]);



                    msCommand.CommandText = $"update parts set partscol = partscol + {coli} where idparts = {idpar}";
                    msCommand.ExecuteNonQuery();
                }


                msCommand.CommandText = "DELETE FROM fixdb.order WHERE idorder = '" + idorder + "'";
                msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
