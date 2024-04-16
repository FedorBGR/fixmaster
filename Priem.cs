using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;


namespace fixmaster
{
    public partial class Priem : Form
    {
        public Priem()
        {
            InitializeComponent();
        }

        private void ClientPage_Click(object sender, EventArgs e)
        {

        }

        private void Priem_Load(object sender, EventArgs e)
        {
            textBox_cena_zakaza.Enabled = false;
            buttonAddvzakaz.Enabled = false;
            button_save.Enabled = false;
            textBox_id_zakaz.Enabled = false;
            DataIntoComboxClcon();
            DataIntocomboBoxIdproduct();
            DataIntoComboxPrj();
            DataIntoComboxIdTovar();
            DataIntoComboxj();
            DataIntoComboxIdclient();
            DataIntoComboxExecutor();
            textBoxj.Visible = false;
            comboBoxj.Visible = false;
            comboBoxPrj.Visible = false;
            string surname = Autorization.Famil(textBox_fam.Text);
            textBox_fam.Text = surname;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientClass.GetClient();
            dataGridView1.DataSource = ClientClass.dtClient;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClassClientClass.GetClientClass();
            dataGridView2.DataSource = ClassClientClass.dtClientClass;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PartClass.GetPart();
            dataGridView3.DataSource = PartClass.dtPart;
            dataGridView8.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView8.DataSource = PartClass.dtPart;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductClass.GetProduct();
            dataGridView4.DataSource = ProductClass.dtProduct;

            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OrderClass.GetZakaz();
            dataGridView5.DataSource = OrderClass.dtZakaz;
            DataIntoComboxClientClass();
            textBoxCln.Enabled = false;
            textBoxPrd.Enabled = false;
            textBoxPrn.Enabled = false;
            buttonAddvzakaz.Visible = false;
            button_vzakaz.Visible = false;
        }

        private void DataIntoComboxIdTovar()
        {
            string sql = @"SELECT idparts FROM parts";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox_id_tovar.Items.Add(reader["idparts"].ToString());
                }
            }
        }

        private void DataIntoComboxj()
        {
            string sql = @"SELECT idparts FROM parts";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxj.Items.Add(reader["idparts"].ToString());
                }
            }
        }

        private void DataIntocomboBoxIdproduct()
        {
            string sql = @"SELECT productname FROM product";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxIdproduct.Items.Add(reader["productname"].ToString());
                }
            }
        }

        private void DataIntoComboxPrj()
        {
            string sql = @"SELECT idproduct FROM product";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxPrj.Items.Add(reader["idproduct"].ToString());
                }
            }
        }

        private void DataIntoComboxClcon()
        {
            string sql = @"SELECT clientcontact FROM client";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxClcon.Items.Add(reader["clientcontact"].ToString());
                }
            }
        }

        private void DataIntoComboxIdclient()
        {
            string sql = @"SELECT clientname FROM client";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxIdclient.Items.Add(reader["clientname"].ToString());
                }
            }
        }

        private void DataIntoComboxClientClass()
        {
            string sql = @"SELECT idclientclass FROM clientclass";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxClassclient.Items.Add(reader["idclientclass"].ToString());
                }
            }
        }

        private void DataIntoComboxExecutor()
        {
            string sql = @"SELECT executorname FROM executor";
            DBconnection.msCommand.CommandText = sql;
            using (var reader = DBconnection.msCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxExecutor.Items.Add(reader["executorname"].ToString());
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxClientname.Text != "" && textBoxClientcontact.Text != "" && comboBoxClassclient.Text != "")
            {
                string sql = @"SELECT idclient FROM client WHERE clientname = '" + textBoxClientname + "' and clientcontact = '" + textBoxClientcontact + "'";
                DBconnection.msCommand.CommandText = sql;
                Object result = DBconnection.msCommand.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("Такой клиент уже есть в базе!", "Дубликат записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClientname.Text = "";
                    textBoxClientcontact.Text = "";
                }
                else
                {
                    if (ClientClass.addClient(textBoxClientname.Text, textBoxClientcontact.Text, comboBoxClassclient.Text))
                    {
                        MessageBox.Show("Клиент успешно добавлен в базу.", "Клиент внесен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClientClass.GetClient();
                        textBoxIdclient.Text = "";
                        textBoxClientname.Text = "";
                        textBoxClientcontact.Text = "";
                        comboBoxClassclient.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Клиент не был добавлен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните обязательные полня!", "Полня не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DialogResult del = MessageBox.Show("Вы действительно хотите удалить клиента?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (del == DialogResult.Yes)
                {
                    ClientClass.deleteClient(delete);
                    ClientClass.GetClient();
                    dataGridView1.DataSource = ClientClass.dtClient;
                    MessageBox.Show("Клиент удален", "Удаление завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении", "Не удалось удалить запись", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public string EditId, EditName, EditContact, EditClass;
        static public string EditIdP, EditNameP, EditDesP, EditColP, EditCostP;
        static public string EditIdPr, EditNamePr, EditDesPr;
        static public string EditClCon, EditIdOr, EditIdclient, EditIdProduct, EditOrderDate, EditOrderStatus, EditIdExecutor, EditIdParts, EditRepairCost, EditOrderCol, EditClientName, EditProductName, EditProductDes;

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSavePart_Click(object sender, EventArgs e)
        {
            if (textBoxPartname.Text != "" && textBoxPartdes.Text != "" && textBoxPartcol.Text != "" && textBoxPartcost.Text != "")
            {
                EditIdP = textBoxIdpart.Text;
                EditNameP = textBoxPartname.Text;
                EditDesP = textBoxPartdes.Text;
                EditColP = textBoxPartcol.Text;
                EditCostP = textBoxPartcost.Text;

                if (PartClass.EditPart(textBoxIdpart.Text, textBoxPartname.Text, textBoxPartdes.Text, textBoxPartcol.Text, textBoxPartcost.Text))
                {
                    MessageBox.Show("Данные успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PartClass.GetPart();
                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBoxPartname.Text = "";
                textBoxPartdes.Text = "";
                textBoxPartcol.Text = "";
                textBoxPartcost.Text = "";
                textBoxIdpart.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonIzmProduct_Click(object sender, EventArgs e)
        {
            EditIdPr = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            EditNamePr = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            EditDesPr = dataGridView4.CurrentRow.Cells[2].Value.ToString();


            textBoxIdProduct.Text = EditIdPr;
            textBoxProductname.Text = EditNamePr;
            textBoxProductDes.Text = EditDesPr;

        }

        private void button_izm_Click(object sender, EventArgs e)
        {
            EditIdOr = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            EditIdclient = dataGridView5.CurrentRow.Cells[4].Value.ToString();
            EditIdProduct = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            EditOrderDate = dataGridView5.CurrentRow.Cells[10].Value.ToString();
            EditOrderStatus = dataGridView5.CurrentRow.Cells[11].Value.ToString();
            EditIdExecutor = dataGridView5.CurrentRow.Cells[9].Value.ToString();
            EditIdParts = dataGridView5.CurrentRow.Cells[7].Value.ToString();
            EditRepairCost = dataGridView5.CurrentRow.Cells[12].Value.ToString();
            EditOrderCol = dataGridView5.CurrentRow.Cells[8].Value.ToString();
            EditClientName = dataGridView5.CurrentRow.Cells[5].Value.ToString();
            EditProductName = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            EditProductDes = dataGridView5.CurrentRow.Cells[3].Value.ToString();
            EditClCon = dataGridView5.CurrentRow.Cells[6].Value.ToString() ;

            comboBoxIdclient.Text = EditClientName;
            comboBoxIdproduct.Text = EditProductName;
            textBoxPrd.Text = EditProductDes;
            textBox_id_zakaz.Text = EditIdOr;
            comboBox_id_tovar.Text = EditIdParts;
            textBoxCln.Text = EditIdclient;
            comboBox_satus.Text = EditOrderStatus;
            comboBoxExecutor.Text = EditIdExecutor;
            textBoxPrn.Text = EditIdProduct;
            textBox_cena_zakaza.Text = EditRepairCost;
            textBox_zakaz_col.Text = EditOrderCol;
            comboBoxClcon.Text = EditClCon;
            comboBoxIdclient.Enabled = false;
            textBox_fam.Enabled = false;
            textBox_zakaz_col.Enabled = false;
            comboBoxIdproduct.Enabled = false;
            button_save.Enabled = true;
            comboBoxExecutor.Enabled=false;
            comboBox_id_tovar.Enabled = false;
            comboBoxj.Enabled = false;
        }


        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSearchOrder.Text != "")
                {
                    string ZakazSearch = textBoxSearchOrder.Text;
                    OrderClass.searchZakaz(ZakazSearch);

                    if (dataGridView5.RowCount == 0)
                    {
                        MessageBox.Show("Номер заказа не обнаружен", "Товар не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchOrder.Text = "";
                        OrderClass.GetZakaz();
                        ProductClass.GetProduct();
                    }


                }

                else
                {
                    MessageBox.Show("Введите данные в поле поиска", "Нет данных для поиска", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске", "Search ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBoxSearchClient.Text != "")
                {
                    string ClientSearch = textBoxSearchClient.Text;
                    ClientClass.searchClient(ClientSearch);

                    if (dataGridView1.RowCount == 0)
                    {
                        MessageBox.Show("Не нашлость совпадений", "Клиент не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchClient.Text = "";
                        ClientClass.GetClient();
                    }


                }

                else
                {
                    MessageBox.Show("Введите данные в поле поиска", "Нет данных для поиска", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске", "Search ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPartsS.Text != "")
                {
                    string PartSearch = textBoxPartsS.Text;
                    PartClass.searchParts(PartSearch);

                    if (dataGridView3.RowCount == 0)
                    {
                        MessageBox.Show("Деталь не обнаружена", "Товар не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchOrder.Text = "";
                        PartClass.GetPart();
                    }


                }

                else
                {
                    MessageBox.Show("Введите данные в поле поиска", "Нет данных для поиска", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при поиске", "Search ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            string OrderNumber = dataGridView5.CurrentRow.Cells[0].Value.ToString().Trim();
            string ClientContact = dataGridView5.CurrentRow.Cells[6].Value.ToString().Trim();
            string Clientname = dataGridView5.CurrentRow.Cells[5].Value.ToString().Trim();
            string IdProduct = dataGridView5.CurrentRow.Cells[1].Value.ToString().Trim();
            string ProductName = dataGridView5.CurrentRow.Cells[2].Value.ToString().Trim();
            string ProductDes = dataGridView5.CurrentRow.Cells[3].Value.ToString().Trim();
            string IdEx = dataGridView5.CurrentRow.Cells[9].Value.ToString().Trim();
            string RepairCost = dataGridView5.CurrentRow.Cells[12].Value.ToString().Trim();

            string fileName = $"check_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            string filePath = Path.Combine("C:\\Users\\Федор\\Desktop\\check", fileName);

            Document doc = new Document();
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                // Открываем документ для записи
                doc.Open();

                // Выбираем шрифт, поддерживающий кириллицу
                BaseFont baseFont = BaseFont.CreateFont(@"D:\fonts\Шрифты от Облачного\ARIAL.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);


                // Добавляем текст и информацию о заказе в документ
                Paragraph paragraph = new Paragraph();
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = font; // Устанавливаем выбранный шрифт
                paragraph.Add($"_______________________________________________________________________\n");
                paragraph.Add($"\n");
                paragraph.Add($"Номер заказа: {OrderNumber}\n");
                paragraph.Add($"Контакты клиента: {ClientContact} Имя клиента: {Clientname}\n");
                paragraph.Add($"Название изделия: {ProductName}\n");
                paragraph.Add($"Описание поломки: {ProductDes}\n");
                paragraph.Add($"Исполнитель: {IdEx}\n");
                paragraph.Add($"Итоговая сумма: {RepairCost} Руб.\n");
                paragraph.Add($"\n");
                paragraph.Add($"Подпись_________\n");
                paragraph.Add($"\n");
                paragraph.Add($"_______________________________________________________________________\n");

                doc.Add(paragraph);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании чека: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрываем документ после завершения работы с ним
                doc.Close();
            }

            // Отображаем сообщение об успешном сохранении чека
            MessageBox.Show($"Чек успешно сохранен по пути: {filePath}", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe", filePath);
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            this.Close();
            var newForm = new Priem();
            newForm.ShowDialog();
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_id_zakaz.Text != "" && comboBox_id_tovar.Text != "" && comboBoxIdclient.Text != "" && comboBoxIdproduct.Text != "" && textBox_cena_zakaza.Text != "" && textBox_zakaz_col.Text != "" && comboBox_satus.Text != "")
            {
                 

                string l = @"SELECT clientname FROM client WHERE idclient = '" + textBoxCln.Text + "'";
                DBconnection.msCommand.CommandText = l;
                Object resultl = DBconnection.msCommand.ExecuteScalar();
                string pn = @"SELECT productname FROM product WHERE idproduct = '" + textBoxPrn.Text + "'";
                DBconnection.msCommand.CommandText = pn;
                Object resultpn = DBconnection.msCommand.ExecuteScalar();
                string pd = @"SELECT productdes FROM product WHERE idproduct = '" + textBoxPrn.Text + "'";
                DBconnection.msCommand.CommandText = pd;
                Object resultpd = DBconnection.msCommand.ExecuteScalar();

                if (EditClientName == comboBoxIdclient.Text &&
                 EditProductName == comboBoxIdproduct.Text &&
                 EditProductDes == textBoxPrd.Text &&
                EditIdOr == textBox_id_zakaz.Text &&
                 EditIdParts == comboBox_id_tovar.Text &&
                 EditIdclient == textBoxCln.Text &&
                EditOrderStatus == comboBox_satus.Text &&
                EditIdExecutor == comboBoxExecutor.Text &&
                EditIdProduct == textBoxPrn.Text &&
                EditRepairCost == textBox_cena_zakaza.Text &&
                EditOrderCol == textBox_zakaz_col.Text &&
                EditClCon == comboBoxClcon.Text)
                {
                    if (OrderClass.EditZakaz(int.Parse(textBox_id_zakaz.Text), comboBox_satus.Text, comboBoxClcon.Text))
                    {
                        MessageBox.Show("Данные заказа успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderClass.GetZakaz();
                        PartClass.GetPart();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (OrderClass.EditZakaz(int.Parse(textBox_id_zakaz.Text), comboBox_satus.Text, comboBoxClcon.Text))
                    {
                        MessageBox.Show("Данные заказа успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderClass.GetZakaz();
                        PartClass.GetPart();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            comboBoxIdclient.Enabled = true;
            textBox_fam.Enabled = true;
            textBox_zakaz_col.Enabled = true;
            comboBoxIdproduct.Enabled = true;
            comboBoxExecutor.Enabled = true;
            comboBox_id_tovar.Enabled = true;
            comboBoxj.Enabled = true;
            comboBoxClcon.Enabled = true;
            textBox_id_zakaz.Text = "";
            comboBox_id_tovar.Text = "";
            comboBoxIdclient.Text = "";
            comboBox_satus.Text = "";
            textBox_fam.Text = "";
            comboBoxIdproduct.Text = "";
            textBox_cena_zakaza.Text = "";
            textBox_zakaz_col.Text = "";
            textBoxCln.Text = "";
            textBoxPrn.Text = "";
            textBoxPrd.Text = "";
            comboBoxClcon.Text = "";
            comboBoxExecutor.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox_satus.Enabled = false;
            EditIdOr = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            EditIdParts = dataGridView5.CurrentRow.Cells[6].Value.ToString();
            EditRepairCost = dataGridView5.CurrentRow.Cells[7].Value.ToString();
            EditOrderCol = dataGridView5.CurrentRow.Cells[8].Value.ToString();
            EditIdProduct = dataGridView5.CurrentRow.Cells[2].Value.ToString();

            textBox_id_zakaz.Text = EditIdOr;
            buttonAddvzakaz.Enabled = true;
            textBoxj.Visible = true;
            comboBoxj.Visible = true;
            comboBoxPrj.Visible = true;
            textBox_zakaz_col.Text = "";
            comboBoxIdclient.Enabled = false;
            textBox_fam.Enabled = false;
        }

        private void button_deletezakaz_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = dataGridView5.CurrentRow.Cells[0].Value.ToString();
                DialogResult del = MessageBox.Show("Вы действительно хотите удалить этот заказ?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (del == DialogResult.Yes)
                {
                    string a = $"SELECT idparts, ordercol FROM fixdb.order WHERE idorder = '{delete}'";
                    DBconnection.msCommand.CommandText = a;

                    // Получаем результаты запроса
                    DataTable tempTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(DBconnection.msCommand))
                    {
                        adapter.Fill(tempTable);
                    }

                    // Перебираем результаты и обновляем данные в таблице "tovar"
                    foreach (DataRow row in tempTable.Rows)
                    {
                        string[] idArray = row["idparts"].ToString().Split(';');
                        string[] colArray = row["ordercol"].ToString().Split(';');
                        

                        for (int i = 0; i < idArray.Length; i++)
                        {
                            int idxz = Convert.ToInt32(idArray[i]);
                            int coli = Convert.ToInt32(colArray[i]);

                            DBconnection.msCommand.CommandText = $"UPDATE parts SET partscol = partscol + {coli} WHERE idparts = {idxz}";
                            DBconnection.msCommand.ExecuteNonQuery();
                        }
                    }

                    // Удаляем заказ после восстановления количества товаров
                    OrderClass.deleteZakaz(delete);
                    OrderClass.GetZakaz();
                    PartClass.GetPart();
                    dataGridView5.DataSource = OrderClass.dtZakaz;
                    MessageBox.Show("Заказ удален", "Удаление завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Не удалось удалить запись", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveProduct_Click(object sender, EventArgs e)
        {
            if (textBoxProductname.Text != "" && textBoxProductDes.Text != "")
            {
                EditIdPr = textBoxIdProduct.Text;
                EditNamePr = textBoxProductname.Text;
                EditDesPr = textBoxProductDes.Text;

                if (ProductClass.EditProduct(textBoxIdProduct.Text, textBoxProductname.Text, textBoxProductDes.Text))
                {
                    MessageBox.Show("Данные успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductClass.GetProduct();
                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBoxIdProduct.Text = "";
                textBoxProductname.Text = "";
                textBoxProductDes.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                DialogResult del = MessageBox.Show("Вы действительно хотите удалить этот продукт?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (del == DialogResult.Yes)
                {
                    ProductClass.deleteProduct(delete);
                    ProductClass.GetProduct();
                    dataGridView4.DataSource = ProductClass.dtProduct;
                    MessageBox.Show("Успешное удаление", "Удаление завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении", "Не удалось удалить запись", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idt1 = Convert.ToString(comboBoxj.Text);
            comboBox_id_tovar.Text = idt1;
            int zkc1 = Convert.ToInt32(textBoxj.Text);
            textBox_zakaz_col.Text = zkc1.ToString();
            string prd1 = Convert.ToString(comboBoxPrj.Text);
            comboBoxIdproduct.Text = prd1;
            string col_do = @"SELECT partscol FROM parts WHERE idparts = '" + comboBox_id_tovar.Text + "'";
            DBconnection.msCommand.CommandText = col_do;
            Object resultcoldo = DBconnection.msCommand.ExecuteScalar();
            string a = @"SELECT idparts FROM fixdb.order WHERE idorder = '" + textBox_id_zakaz.Text + "'";
            DBconnection.msCommand.CommandText = a;
            Object result1 = DBconnection.msCommand.ExecuteScalar();
            string b = @"SELECT repaircost FROM fixdb.order WHERE idorder = '" + textBox_id_zakaz.Text + "'";
            DBconnection.msCommand.CommandText = b;
            Object result2 = DBconnection.msCommand.ExecuteScalar();
            string c = @"SELECT ordercol FROM fixdb.order WHERE idorder = '" + textBox_id_zakaz.Text + "'";
            DBconnection.msCommand.CommandText = c;
            Object result3 = DBconnection.msCommand.ExecuteScalar();
            string v = @"SELECT partscost FROM parts WHERE idparts = '" + comboBox_id_tovar.Text + "'";
            DBconnection.msCommand.CommandText = v;
            Object result = DBconnection.msCommand.ExecuteScalar();
            string p = @"SELECT idproduct FROM fixdb.order WHERE idorder - '" + textBox_id_zakaz.Text + "'";
            DBconnection.msCommand.CommandText = p;
            Object result4 = DBconnection.msCommand.ExecuteScalar();

            if (result != null && result1 != null && result2 != null && result3 != null && result4 != null)
            {
                int j = Convert.ToInt32(textBoxj.Text);
                int price = Convert.ToInt32(result);
                int x = price;
                int y = Convert.ToInt32(textBoxj.Text);
                int z = x * y;
                textBox_cena_zakaza.Text = z.ToString();

                string colvo = result3.ToString();
                string colvo_posle = colvo + ";" + textBoxj.Text;
                textBox_zakaz_col.Text = colvo_posle.ToString();

                int price2 = Convert.ToInt32(result2);
                int price_posle = price2 + z;
                textBox_cena_zakaza.Text = price_posle.ToString();

                string id_tov = result1.ToString();
                comboBox_id_tovar.Text = id_tov + ";" + comboBoxj.Text;

                string id_pr = result4.ToString();
                comboBoxIdproduct.Text = id_pr + ";" + comboBoxPrj.Text;
            }

            if (textBox_id_zakaz.Text == EditIdOr)
            {


                if (textBox_id_zakaz.Text != "" && comboBox_id_tovar.Text != "" && textBox_cena_zakaza.Text != "" && textBox_zakaz_col.Text != "")
                {
                    EditIdOr = textBox_id_zakaz.Text;
                    int j = Convert.ToInt32(textBoxj.Text);
                    if (Convert.ToInt32(resultcoldo) > j)
                    {

                        if (OrderClass.addTovartoZakaz(int.Parse(textBox_id_zakaz.Text), comboBoxIdproduct.Text, comboBox_id_tovar.Text, int.Parse(textBox_cena_zakaza.Text), textBox_zakaz_col.Text))
                        {
                            int col_col = Convert.ToInt32(resultcoldo) - j;
                            string Obnovtov = @"UPDATE parts SET partscol = '" + col_col + "' WHERE idparts = '" + comboBoxj.Text + "'";
                            DBconnection.msCommand.CommandText = Obnovtov;
                            Object resultobnov = DBconnection.msCommand.ExecuteScalar();
                            MessageBox.Show("Добавление в заказ успешно.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OrderClass.GetZakaz();
                            PartClass.GetPart();
                            ClientClass.GetClient();



                            textBox_cena_zakaza.Text = "";
                            comboBox_id_tovar.Text = "";
                            comboBoxIdclient.Text = "";
                            textBox_zakaz_col.Text = "";
                            comboBox_satus.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Товара на складе недостаточно", "Товара недостаточно", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Ошибка при добавлении в заказ", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                    }
                    else
                    {
                        MessageBox.Show("Товара на складе недостаточно", "Товара недостаточно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (OrderClass.addTovartoZakaz(int.Parse(textBox_id_zakaz.Text), comboBoxIdproduct.Text, comboBox_id_tovar.Text, int.Parse(textBox_cena_zakaza.Text), textBox_zakaz_col.Text))
                {
                    int j = Convert.ToInt32(textBoxj.Text);
                    if (Convert.ToInt32(resultcoldo) > j)
                    {

                        if (OrderClass.addTovartoZakaz(int.Parse(textBox_id_zakaz.Text), comboBoxIdproduct.Text, comboBox_id_tovar.Text, int.Parse(textBox_cena_zakaza.Text), textBox_zakaz_col.Text))
                        {
                            int col_col = Convert.ToInt32(resultcoldo) - j;
                            string Obnovtov = @"UPDATE parts SET partscol = '" + col_col + "' WHERE idparts = '" + comboBoxj.Text + "'";
                            DBconnection.msCommand.CommandText = Obnovtov;
                            Object resultobnov = DBconnection.msCommand.ExecuteScalar();
                            MessageBox.Show("Добавление в заказ успешно.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OrderClass.GetZakaz();
                            PartClass.GetPart();


                            textBox_cena_zakaza.Text = "";
                            comboBox_id_tovar.Text = "";
                            comboBoxIdclient.Text = "";
                            textBox_zakaz_col.Text = "";
                            comboBox_satus.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Товара на складе недостаточно", "Товара недостаточно", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Ошибка при добавлении в заказ", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {


                    if (textBox_id_zakaz.Text != "" && comboBox_id_tovar.Text != "" && textBox_cena_zakaza.Text != "" && textBox_zakaz_col.Text != "")
                    {
                        EditIdOr = textBox_id_zakaz.Text;
                        int j = Convert.ToInt32(textBoxj.Text);
                        if (Convert.ToInt32(resultcoldo) > j)
                        {

                            if (OrderClass.addTovartoZakaz(int.Parse(textBox_id_zakaz.Text), comboBoxIdproduct.Text, comboBox_id_tovar.Text, int.Parse(textBox_cena_zakaza.Text), textBox_zakaz_col.Text))
                            {
                                int col_col = Convert.ToInt32(resultcoldo) - j;
                                string Obnovtov = @"UPDATE parts SET partscol = '" + col_col + "' WHERE idparts = '" + comboBoxj.Text + "'";
                                DBconnection.msCommand.CommandText = Obnovtov;
                                Object resultobnov = DBconnection.msCommand.ExecuteScalar();
                                MessageBox.Show("Добавление в заказ успешно.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                OrderClass.GetZakaz();
                                PartClass.GetPart();


                                textBox_cena_zakaza.Text = "";
                                comboBox_id_tovar.Text = "";
                                comboBoxIdclient.Text = "";
                                textBox_zakaz_col.Text = "";
                                comboBox_satus.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Товара на складе недостаточно", "Товара недостаточно", MessageBoxButtons.OK, MessageBoxIcon.Warning); MessageBox.Show("Ошибка при добавлении в заказ", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                        }
                        else
                        {
                            MessageBox.Show("Товара на складе недостаточно", "Товара недостаточно", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            textBoxj.Visible = false;
            comboBoxj.Visible = false;
            buttonAddvzakaz.Enabled = false;
            buttonAddvzakaz.Enabled = false;
            comboBox_satus.Enabled = true;
        }

        private void button_addZakaz_Click(object sender, EventArgs e)
        {
            string col_do = @"SELECT partscol FROM parts WHERE idparts = '" + comboBox_id_tovar.Text + "'";
            DBconnection.msCommand.CommandText = col_do;
            Object resultcoldo = DBconnection.msCommand.ExecuteScalar();
            string v = @"SELECT partscost FROM parts WHERE idparts = '" + comboBox_id_tovar.Text + "'";
            DBconnection.msCommand.CommandText = v;
            Object result = DBconnection.msCommand.ExecuteScalar();
            string l = @"SELECT idclient FROM client WHERE clientname = '" + comboBoxIdclient.Text + "' and clientcontact = '"+ comboBoxClcon.Text +"'";
            DBconnection.msCommand.CommandText = l;
            Object resultl = DBconnection.msCommand.ExecuteScalar();
            string pn = @"SELECT idproduct FROM product WHERE productname = '" + comboBoxIdproduct.Text + "'";
            DBconnection.msCommand.CommandText = pn;
Object resultpn = DBconnection.msCommand.ExecuteScalar();
            string pd = @"SELECT productdes FROM product WHERE productname = '" + comboBoxIdproduct.Text + "'";
            DBconnection.msCommand.CommandText = pd;
            Object resultpd = DBconnection.msCommand.ExecuteScalar();
            
            if (result != null)
            {
                int price = Convert.ToInt32(result);
                int x = price;
                int y = Convert.ToInt32(textBox_zakaz_col.Text);
                int z = x * y;
                textBox_cena_zakaza.Text = z.ToString();
            }
            if (comboBox_id_tovar.Text != "" && comboBoxIdclient.Text != "" && comboBoxIdproduct.Text != ""  && textBox_zakaz_col.Text != "" && comboBoxExecutor.Text != "" && comboBox_satus.Text != "")
            {
                int y = Convert.ToInt32(textBox_zakaz_col.Text);

                if (Convert.ToInt32(resultcoldo) >= y)
                {

                    if (OrderClass.addZakaz(Convert.ToString(resultl), Convert.ToString(resultpn), comboBox_satus.Text, comboBoxExecutor.Text, comboBox_id_tovar.Text, Convert.ToInt32(textBox_cena_zakaza.Text), textBox_zakaz_col.Text, comboBoxIdclient.Text, comboBoxIdproduct.Text, resultpd.ToString(), comboBoxClcon.Text))
                    {
                        int col_col = Convert.ToInt32(resultcoldo) - y;
                        string Obnovtov = @"UPDATE parts SET partscol = '" + col_col + "' WHERE idparts = '" + comboBox_id_tovar.Text + "'";
                        DBconnection.msCommand.CommandText = Obnovtov;
                        Object resultobnov = DBconnection.msCommand.ExecuteScalar();
                        MessageBox.Show("Заказ успешно добавлен в базу.", "Заказ внесен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderClass.GetZakaz();
                        PartClass.GetPart();


                        textBox_cena_zakaza.Text = "";
                        comboBox_id_tovar.Text = "";
                        comboBoxIdproduct.Text = "";
                        comboBoxIdclient.Text = "";
                        textBox_zakaz_col.Text = "";
                        comboBox_satus.Text = "";
                        comboBoxExecutor.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Заказ не был добавлен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                else
                {
                    MessageBox.Show("Деталей на складе недостаточно", "Деталей не хватает", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Заполните обязательные полня!", "Полня не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxIdclient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDeletePart_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                DialogResult del = MessageBox.Show("Вы действительно хотите удалить деталь?", "Подтвердите удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (del == DialogResult.Yes)
                {
                    PartClass.deletePart(delete);
                    PartClass.GetPart();
                    dataGridView3.DataSource = PartClass.dtPart;
                    MessageBox.Show("Успешное удаление", "Удаление завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении", "Не удалось удалить запись", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (textBoxProductname.Text != "" && textBoxProductDes.Text != "")
            {
                
                    if (ProductClass.addProduct(textBoxProductname.Text, textBoxProductDes.Text))
                    {
                        MessageBox.Show("Товар успешно добавлен в базу.", "Товар внесен внесен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductClass.GetProduct();
                        textBoxIdProduct.Text = "";
                    textBoxProductname.Text = "";
                    textBoxProductDes.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Товар не был добавлен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
            else
            {
                MessageBox.Show("Заполните обязательные полня!", "Полня не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            if (textBoxPartname.Text != "" && textBoxPartdes.Text != "" && textBoxPartcol.Text != "" && textBoxPartcost.Text != "")
            {
                string sql = @"SELECT idparts FROM parts WHERE partsname = '" + textBoxPartname + "' and partsdescription = '" + textBoxPartdes + "'";
                DBconnection.msCommand.CommandText = sql;
                Object result = DBconnection.msCommand.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("Такой товар уже есть в базе!", "Дубликат записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClientname.Text = "";
                    textBoxClientcontact.Text = "";
                }
                else
                {
                    if (PartClass.addPart(textBoxPartname.Text, textBoxPartdes.Text, textBoxPartcol.Text, textBoxPartcost.Text))
                    {
                        MessageBox.Show("Деталь успешно добавлена в базу.", "Деталь внесена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PartClass.GetPart();
                        textBoxPartcost.Text = "";
                        textBoxPartname.Text = "";
                        textBoxPartdes.Text = "";
                        textBoxPartcol.Text = "";
                        textBoxIdpart.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Деталь не была внесена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните обязательные полня!", "Полня не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonIzmPart_Click(object sender, EventArgs e)
        {
            EditIdP = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            EditNameP = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            EditDesP = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            EditColP = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            EditCostP = dataGridView3.CurrentRow.Cells[4].Value.ToString();


            textBoxIdpart.Text = EditIdP;
            textBoxPartname.Text = EditNameP;
            textBoxPartdes.Text = EditDesP;
            textBoxPartcol.Text = EditColP;
            textBoxPartcost.Text = EditCostP;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxClientname.Text != "" && textBoxClientcontact.Text != "" && comboBoxClassclient.Text != "")
            {
                EditId = textBoxIdclient.Text;
                EditName = textBoxClientname.Text;
                EditContact = textBoxClientcontact.Text;
                EditClass = comboBoxClassclient.Text;

                if (ClientClass.EditClient(textBoxIdclient.Text, textBoxClientcontact.Text, comboBoxClassclient.Text, textBoxClientname.Text))
                {
                    MessageBox.Show("Данные успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClientClass.GetClient();
                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBoxClientname.Text = "";
                textBoxClientcontact.Text = "";
                comboBoxClassclient.Text = "";
                textBoxIdclient.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonIzm_Click(object sender, EventArgs e)
        {
            EditId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            EditContact = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            EditClass = dataGridView1.CurrentRow.Cells[3].Value.ToString();


            textBoxIdclient.Text = EditId;
            textBoxClientname.Text = EditName;

            textBoxClientcontact.Text = EditContact;

            comboBoxClassclient.Text = EditClass;

        }


    }
}
