namespace fixmaster
{
    public partial class Form1 : Form
    {
        static public string loginActive;
        static public string whois;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBconnection.ConnectionDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Autorization.Autorization1(textBox1.Text.Trim(), textBox2.Text.Trim());
                switch (Autorization.Role)
                {
                    case null:
                        {
                            MessageBox.Show("Такого пользователя не существует!", "Проверьте правильность введенных данных!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    case "Приемщик":
                        {
                            loginActive = textBox1.Text.Trim();
                            whois = "Приемщик";
                            Autorization.User = textBox1.Text.Trim();
                            MessageBox.Show("Добро пожаловать в меню приема заказов", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Priem priem = new Priem();
                            priem.Show();
                            break;
                        }
                    case "Исполнитель":
                        {
                            loginActive = textBox1.Text.Trim();
                            whois = "Исполнитель";
                            Autorization.User = textBox1.Text.Trim();
                            MessageBox.Show("Добро пожаловать в меню исполниеля", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Work work = new Work();
                            work.Show();
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Заполнение полей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}