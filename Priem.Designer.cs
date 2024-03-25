namespace fixmaster
{
    partial class Priem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.ClientPage = new System.Windows.Forms.TabPage();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonIzm = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxClassclient = new System.Windows.Forms.ComboBox();
            this.textBoxClientcontact = new System.Windows.Forms.TextBox();
            this.textBoxClientname = new System.Windows.Forms.TextBox();
            this.textBoxIdclient = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl2.SuspendLayout();
            this.ClientPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.ClientPage);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1904, 1041);
            this.tabControl2.TabIndex = 0;
            // 
            // ClientPage
            // 
            this.ClientPage.Controls.Add(this.buttonSave);
            this.ClientPage.Controls.Add(this.buttonIzm);
            this.ClientPage.Controls.Add(this.buttonDelete);
            this.ClientPage.Controls.Add(this.buttonAdd);
            this.ClientPage.Controls.Add(this.label4);
            this.ClientPage.Controls.Add(this.label3);
            this.ClientPage.Controls.Add(this.label2);
            this.ClientPage.Controls.Add(this.label1);
            this.ClientPage.Controls.Add(this.comboBoxClassclient);
            this.ClientPage.Controls.Add(this.textBoxClientcontact);
            this.ClientPage.Controls.Add(this.textBoxClientname);
            this.ClientPage.Controls.Add(this.textBoxIdclient);
            this.ClientPage.Controls.Add(this.dataGridView1);
            this.ClientPage.Location = new System.Drawing.Point(4, 24);
            this.ClientPage.Name = "ClientPage";
            this.ClientPage.Padding = new System.Windows.Forms.Padding(3);
            this.ClientPage.Size = new System.Drawing.Size(1896, 1013);
            this.ClientPage.TabIndex = 0;
            this.ClientPage.Text = "Клиент";
            this.ClientPage.UseVisualStyleBackColor = true;
            this.ClientPage.Click += new System.EventHandler(this.ClientPage_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(803, 678);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(153, 34);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonIzm
            // 
            this.buttonIzm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonIzm.Location = new System.Drawing.Point(803, 609);
            this.buttonIzm.Name = "buttonIzm";
            this.buttonIzm.Size = new System.Drawing.Size(153, 34);
            this.buttonIzm.TabIndex = 11;
            this.buttonIzm.Text = "Изменить";
            this.buttonIzm.UseVisualStyleBackColor = true;
            this.buttonIzm.Click += new System.EventHandler(this.buttonIzm_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.Location = new System.Drawing.Point(803, 550);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(153, 34);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(803, 491);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(153, 34);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(303, 690);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Код класса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(249, 634);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Контактные данные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(361, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(303, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Код Клиента";
            // 
            // comboBoxClassclient
            // 
            this.comboBoxClassclient.FormattingEnabled = true;
            this.comboBoxClassclient.Location = new System.Drawing.Point(408, 688);
            this.comboBoxClassclient.Name = "comboBoxClassclient";
            this.comboBoxClassclient.Size = new System.Drawing.Size(160, 23);
            this.comboBoxClassclient.TabIndex = 4;
            // 
            // textBoxClientcontact
            // 
            this.textBoxClientcontact.Location = new System.Drawing.Point(408, 632);
            this.textBoxClientcontact.Name = "textBoxClientcontact";
            this.textBoxClientcontact.Size = new System.Drawing.Size(160, 23);
            this.textBoxClientcontact.TabIndex = 3;
            // 
            // textBoxClientname
            // 
            this.textBoxClientname.Location = new System.Drawing.Point(408, 571);
            this.textBoxClientname.Name = "textBoxClientname";
            this.textBoxClientname.Size = new System.Drawing.Size(160, 23);
            this.textBoxClientname.TabIndex = 2;
            // 
            // textBoxIdclient
            // 
            this.textBoxIdclient.Location = new System.Drawing.Point(408, 508);
            this.textBoxIdclient.Name = "textBoxIdclient";
            this.textBoxIdclient.Size = new System.Drawing.Size(160, 23);
            this.textBoxIdclient.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(408, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(900, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1896, 1013);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Priem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tabControl2);
            this.Name = "Priem";
            this.Text = "Priem";
            this.Load += new System.EventHandler(this.Priem_Load);
            this.tabControl2.ResumeLayout(false);
            this.ClientPage.ResumeLayout(false);
            this.ClientPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabControl tabControl2;
        private TabPage ClientPage;
        private TabPage tabPage4;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxClassclient;
        private TextBox textBoxClientcontact;
        private TextBox textBoxClientname;
        private TextBox textBoxIdclient;
        private Button buttonSave;
        private Button buttonIzm;
        private Button buttonDelete;
        private Button buttonAdd;
    }
}