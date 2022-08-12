
namespace BuyersAndOrders
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLoginSignIn = new System.Windows.Forms.Label();
            this.textBoxLoginSignIn = new System.Windows.Forms.TextBox();
            this.textBoxPasswordSignIn = new System.Windows.Forms.TextBox();
            this.labelPasswordSignIn = new System.Windows.Forms.Label();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.buttonCreateUser = new System.Windows.Forms.Button();
            this.labelWarningSignIn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLoginSignIn
            // 
            this.labelLoginSignIn.AutoSize = true;
            this.labelLoginSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoginSignIn.Location = new System.Drawing.Point(326, 43);
            this.labelLoginSignIn.Name = "labelLoginSignIn";
            this.labelLoginSignIn.Size = new System.Drawing.Size(88, 29);
            this.labelLoginSignIn.TabIndex = 0;
            this.labelLoginSignIn.Text = "Логин";
            // 
            // textBoxLoginSignIn
            // 
            this.textBoxLoginSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLoginSignIn.Location = new System.Drawing.Point(111, 92);
            this.textBoxLoginSignIn.Name = "textBoxLoginSignIn";
            this.textBoxLoginSignIn.Size = new System.Drawing.Size(518, 30);
            this.textBoxLoginSignIn.TabIndex = 1;
            // 
            // textBoxPasswordSignIn
            // 
            this.textBoxPasswordSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPasswordSignIn.Location = new System.Drawing.Point(111, 184);
            this.textBoxPasswordSignIn.Name = "textBoxPasswordSignIn";
            this.textBoxPasswordSignIn.Size = new System.Drawing.Size(518, 30);
            this.textBoxPasswordSignIn.TabIndex = 3;
            // 
            // labelPasswordSignIn
            // 
            this.labelPasswordSignIn.AutoSize = true;
            this.labelPasswordSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPasswordSignIn.Location = new System.Drawing.Point(326, 135);
            this.labelPasswordSignIn.Name = "labelPasswordSignIn";
            this.labelPasswordSignIn.Size = new System.Drawing.Size(105, 29);
            this.labelPasswordSignIn.TabIndex = 2;
            this.labelPasswordSignIn.Text = "Пароль";
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSignIn.Location = new System.Drawing.Point(533, 248);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(133, 46);
            this.buttonSignIn.TabIndex = 4;
            this.buttonSignIn.Text = "Войти";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.ButtonSignIn_Click);
            // 
            // buttonCreateUser
            // 
            this.buttonCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateUser.Location = new System.Drawing.Point(58, 327);
            this.buttonCreateUser.Name = "buttonCreateUser";
            this.buttonCreateUser.Size = new System.Drawing.Size(340, 38);
            this.buttonCreateUser.TabIndex = 5;
            this.buttonCreateUser.Text = "У меня нет аккаунта";
            this.buttonCreateUser.UseVisualStyleBackColor = true;
            this.buttonCreateUser.Click += new System.EventHandler(this.ButtonCreateUser_Click);
            // 
            // labelWarningSignIn
            // 
            this.labelWarningSignIn.AutoSize = true;
            this.labelWarningSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarningSignIn.Location = new System.Drawing.Point(111, 221);
            this.labelWarningSignIn.Name = "labelWarningSignIn";
            this.labelWarningSignIn.Size = new System.Drawing.Size(305, 18);
            this.labelWarningSignIn.TabIndex = 6;
            this.labelWarningSignIn.Text = "Логин и пароль не могут содержать *";
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 396);
            this.Controls.Add(this.labelWarningSignIn);
            this.Controls.Add(this.buttonCreateUser);
            this.Controls.Add(this.buttonSignIn);
            this.Controls.Add(this.textBoxPasswordSignIn);
            this.Controls.Add(this.labelPasswordSignIn);
            this.Controls.Add(this.textBoxLoginSignIn);
            this.Controls.Add(this.labelLoginSignIn);
            this.MaximumSize = new System.Drawing.Size(751, 443);
            this.MinimumSize = new System.Drawing.Size(751, 443);
            this.Name = "AuthorizationForm";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLoginSignIn;
        private System.Windows.Forms.TextBox textBoxLoginSignIn;
        private System.Windows.Forms.TextBox textBoxPasswordSignIn;
        private System.Windows.Forms.Label labelPasswordSignIn;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.Button buttonCreateUser;
        private System.Windows.Forms.Label labelWarningSignIn;
    }
}

