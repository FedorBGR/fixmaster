using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientClass.GetClient();
            dataGridView1.DataSource = ClientClass.dtClient;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClassClientClass.GetClientClass();
            dataGridView2.DataSource = ClassClientClass.dtClientClass;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PartClass.GetPart();
            dataGridView3.DataSource = PartClass.dtPart;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductClass.GetProduct();
            dataGridView4.DataSource = ProductClass.dtProduct;
            DataIntoComboxClientClass();
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if ( textBoxClientname.Text != "" && textBoxClientcontact.Text != "" && comboBoxClassclient.Text != "")
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
