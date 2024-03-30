using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixmaster 
{
    internal class ProductClass: DBconnection
    {
        static public DataTable dtProduct = new DataTable();

        static public void GetProduct()
        {
            try
            {
                msCommand.CommandText = "SELECT idproduct AS 'Код изделия', productname AS 'Название изделия', productdes AS 'Описание поломки' FROM product";
                dtProduct.Clear();
                msDataAdapter.SelectCommand = DBconnection.msCommand;
                msDataAdapter.Fill(dtProduct);
            }

            catch
            {
                MessageBox.Show("Ошибка при получении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public bool addProduct(string productname, string productdes)
        {
            try
            {
                msCommand.CommandText = "INSERT INTO product VALUES (null , '" + productname + "', '" + productdes + "')";
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

        static public bool EditProduct(string idproduct, string productname, string productdes)
        {
            try
            {
                msCommand.CommandText = "UPDATE product SET idproduct = '" + idproduct + "', productname = '" + productname + "', productdes = '" + productdes + "' WHERE idproduct = '" + idproduct + "'";


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

        static public void deleteProduct(string idproduct)
        {
            try
            {
                msCommand.CommandText = "DELETE FROM product WHERE idproduct = '" + idproduct + "'";
                msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
