
namespace BuyersAndOrders
{
    partial class SignUpForm
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
            this.textBoxPasswordSignUp = new System.Windows.Forms.TextBox();
            this.labelPasswordSignUp = new System.Windows.Forms.Label();
            this.textBoxLoginSignUp = new System.Windows.Forms.TextBox();
            this.labelLoginSignUp = new System.Windows.Forms.Label();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.labelWarningSignUp = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
            this.labelAdress = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPasswordSignUp
            // 
            this.textBoxPasswordSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPasswordSignUp.Location = new System.Drawing.Point(112, 185);
            this.textBoxPasswordSignUp.Name = "textBoxPasswordSignUp";
            this.textBoxPasswordSignUp.Size = new System.Drawing.Size(518, 30);
            this.textBoxPasswordSignUp.TabIndex = 7;
            // 
            // labelPasswordSignUp
            // 
            this.labelPasswordSignUp.AutoSize = true;
            this.labelPasswordSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPasswordSignUp.Location = new System.Drawing.Point(327, 136);
            this.labelPasswordSignUp.Name = "labelPasswordSignUp";
            this.labelPasswordSignUp.Size = new System.Drawing.Size(105, 29);
            this.labelPasswordSignUp.TabIndex = 6;
            this.labelPasswordSignUp.Text = "Пароль";
            // 
            // textBoxLoginSignUp
            // 
            this.textBoxLoginSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLoginSignUp.Location = new System.Drawing.Point(112, 93);
            this.textBoxLoginSignUp.Name = "textBoxLoginSignUp";
            this.textBoxLoginSignUp.Size = new System.Drawing.Size(518, 30);
            this.textBoxLoginSignUp.TabIndex = 5;
            // 
            // labelLoginSignUp
            // 
            this.labelLoginSignUp.AutoSize = true;
            this.labelLoginSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoginSignUp.Location = new System.Drawing.Point(327, 44);
            this.labelLoginSignUp.Name = "labelLoginSignUp";
            this.labelLoginSignUp.Size = new System.Drawing.Size(88, 29);
            this.labelLoginSignUp.TabIndex = 4;
            this.labelLoginSignUp.Text = "Логин";
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "Клиент",
            "Продавец"});
            this.comboBoxUserType.Location = new System.Drawing.Point(292, 253);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(171, 28);
            this.comboBoxUserType.TabIndex = 8;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignUp.Location = new System.Drawing.Point(461, 630);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(260, 47);
            this.buttonSignUp.TabIndex = 9;
            this.buttonSignUp.Text = "Зарегистрироваться";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.ButtonSignUp_Click);
            // 
            // labelWarningSignUp
            // 
            this.labelWarningSignUp.AutoSize = true;
            this.labelWarningSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarningSignUp.Location = new System.Drawing.Point(38, 617);
            this.labelWarningSignUp.Name = "labelWarningSignUp";
            this.labelWarningSignUp.Size = new System.Drawing.Size(224, 18);
            this.labelWarningSignUp.TabIndex = 10;
            this.labelWarningSignUp.Text = "Поля не могут содержать *";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSurname.Location = new System.Drawing.Point(41, 361);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(206, 30);
            this.textBoxSurname.TabIndex = 12;
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSurname.Location = new System.Drawing.Point(77, 313);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(130, 29);
            this.labelSurname.TabIndex = 11;
            this.labelSurname.Text = "Фамилия";
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAdress.Location = new System.Drawing.Point(112, 470);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(518, 30);
            this.textBoxAdress.TabIndex = 14;
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdress.Location = new System.Drawing.Point(336, 425);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(87, 29);
            this.labelAdress.TabIndex = 13;
            this.labelAdress.Text = "Адрес";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPhone.Location = new System.Drawing.Point(112, 564);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(518, 30);
            this.textBoxPhone.TabIndex = 16;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhone.Location = new System.Drawing.Point(315, 517);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(126, 29);
            this.labelPhone.TabIndex = 15;
            this.labelPhone.Text = "Телефон";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(271, 361);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(206, 30);
            this.textBoxName.TabIndex = 18;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(348, 313);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(66, 29);
            this.labelName.TabIndex = 17;
            this.labelName.Text = "Имя";
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPatronymic.Location = new System.Drawing.Point(505, 361);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(206, 30);
            this.textBoxPatronymic.TabIndex = 20;
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatronymic.Location = new System.Drawing.Point(555, 313);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(131, 29);
            this.labelPatronymic.TabIndex = 19;
            this.labelPatronymic.Text = "Отчество";
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 704);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxAdress);
            this.Controls.Add(this.labelAdress);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelWarningSignUp);
            this.Controls.Add(this.buttonSignUp);
            this.Controls.Add(this.comboBoxUserType);
            this.Controls.Add(this.textBoxPasswordSignUp);
            this.Controls.Add(this.labelPasswordSignUp);
            this.Controls.Add(this.textBoxLoginSignUp);
            this.Controls.Add(this.labelLoginSignUp);
            this.MaximumSize = new System.Drawing.Size(751, 751);
            this.MinimumSize = new System.Drawing.Size(751, 751);
            this.Name = "SignUpForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPasswordSignUp;
        private System.Windows.Forms.Label labelPasswordSignUp;
        private System.Windows.Forms.TextBox textBoxLoginSignUp;
        private System.Windows.Forms.Label labelLoginSignUp;
        private System.Windows.Forms.ComboBox comboBoxUserType;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Label labelWarningSignUp;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.TextBox textBoxAdress;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.Label labelPatronymic;
    }
}