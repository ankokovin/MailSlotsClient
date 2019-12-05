namespace MailSlots
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lblMailSlot = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.tb_messages = new System.Windows.Forms.RichTextBox();
            this.cbMailSlot = new System.Windows.Forms.ComboBox();
            this.bLoadMailSlots = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(274, 99);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 26);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(86, 103);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(181, 20);
            this.tbMessage.TabIndex = 1;
            // 
            // lblMailSlot
            // 
            this.lblMailSlot.AutoSize = true;
            this.lblMailSlot.Location = new System.Drawing.Point(12, 15);
            this.lblMailSlot.Name = "lblMailSlot";
            this.lblMailSlot.Size = new System.Drawing.Size(60, 26);
            this.lblMailSlot.TabIndex = 2;
            this.lblMailSlot.Text = "Выберите \r\nмэйлслот";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(274, 56);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 26);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(7, 106);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Сообщение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите имя\r\nпользователя";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(86, 53);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(181, 20);
            this.nameTb.TabIndex = 0;
            this.nameTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tb_messages
            // 
            this.tb_messages.Location = new System.Drawing.Point(10, 137);
            this.tb_messages.Name = "tb_messages";
            this.tb_messages.Size = new System.Drawing.Size(355, 166);
            this.tb_messages.TabIndex = 4;
            this.tb_messages.Text = "";
            // 
            // cbMailSlot
            // 
            this.cbMailSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMailSlot.FormattingEnabled = true;
            this.cbMailSlot.Location = new System.Drawing.Point(86, 15);
            this.cbMailSlot.Name = "cbMailSlot";
            this.cbMailSlot.Size = new System.Drawing.Size(182, 21);
            this.cbMailSlot.TabIndex = 5;
            // 
            // bLoadMailSlots
            // 
            this.bLoadMailSlots.Location = new System.Drawing.Point(275, 13);
            this.bLoadMailSlots.Name = "bLoadMailSlots";
            this.bLoadMailSlots.Size = new System.Drawing.Size(90, 37);
            this.bLoadMailSlots.TabIndex = 6;
            this.bLoadMailSlots.Text = "Загрузить список";
            this.bLoadMailSlots.UseVisualStyleBackColor = true;
            this.bLoadMailSlots.Click += new System.EventHandler(this.bLoadMailSlots_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 315);
            this.Controls.Add(this.bLoadMailSlots);
            this.Controls.Add(this.cbMailSlot);
            this.Controls.Add(this.tb_messages);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblMailSlot);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label lblMailSlot;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.RichTextBox tb_messages;
        private System.Windows.Forms.ComboBox cbMailSlot;
        private System.Windows.Forms.Button bLoadMailSlots;
    }
}

