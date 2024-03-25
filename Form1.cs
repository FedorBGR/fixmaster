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
                            MessageBox.Show("������ ������������ �� ����������!", "��������� ������������ ��������� ������!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    case "��������":
                        {
                            loginActive = textBox1.Text.Trim();
                            whois = "��������";
                            Autorization.User = textBox1.Text.Trim();
                            MessageBox.Show("����� ���������� � ���� ������ �������", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Priem priem = new Priem();
                            priem.Show();
                            break;
                        }
                    case "�����������":
                        {
                            loginActive = textBox1.Text.Trim();
                            whois = "�����������";
                            Autorization.User = textBox1.Text.Trim();
                            MessageBox.Show("����� ���������� � ���� ����������", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Work work = new Work();
                            work.Show();
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("��������� ��� ����!", "���������� �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}