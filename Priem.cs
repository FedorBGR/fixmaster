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
                    MessageBox.Show("Такой товар уже есть в базе!", "Дубликат записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxClientname.Text == EditName && textBoxClientcontact.Text == EditContact && comboBoxClassclient.Text == EditClass)
            {
                if (textBoxClientname.Text != "" && textBoxClientcontact.Text != "" && comboBoxClassclient.Text != "" )
                {
                    EditId = textBoxIdclient.Text;
                    EditName = textBoxClientname.Text;
                    EditContact = textBoxClientcontact.Text;
                    EditClass = comboBoxClassclient.Text;
                    if (ClientClass.EditClient(textBoxIdclient.Text, textBoxClientcontact.Text, comboBoxClassclient.Text, textBoxClientname.Text))
                    {
                        MessageBox.Show("Данные Клиента успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClientClass.GetClient();
                        textBoxClientname.Text = "";
                        textBoxClientcontact.Text = "";
                        comboBoxClassclient.Text = "";
                        textBoxIdclient.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (ClientClass.EditClient(textBoxIdclient.Text, textBoxClientcontact.Text, comboBoxClassclient.Text, textBoxClientname.Text))
                {
                    MessageBox.Show("Данные товара успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClientClass.GetClient();
                    textBoxClientname.Text = "";
                    textBoxClientcontact.Text = "";
                    comboBoxClassclient.Text = "";
                    textBoxIdclient.Text = "";

                }
                else
                {
                    if (textBoxClientname.Text != "" && textBoxClientcontact.Text != "" && comboBoxClassclient.Text != "")
                    {
                        EditId = textBoxIdclient.Text;
                        EditName = textBoxClientname.Text;
                        EditContact = textBoxClientcontact.Text;
                        EditClass = comboBoxClassclient.Text;
                        if (ClientClass.EditClient(textBoxIdclient.Text, textBoxClientcontact.Text, comboBoxClassclient.Text, textBoxClientname.Text))
                        {
                            MessageBox.Show("Данные Клиента успешно изменены", "Данные изменены", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClientClass.GetClient();
                            textBoxClientname.Text = "";
                            textBoxClientcontact.Text = "";
                            comboBoxClassclient.Text = "";
                            textBoxIdclient.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при редактировании записи", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля", "Поля не заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
