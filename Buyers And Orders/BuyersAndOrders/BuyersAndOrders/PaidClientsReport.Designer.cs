
namespace BuyersAndOrders
{
    partial class PaidClientsReport
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
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.buttonMakeReport = new System.Windows.Forms.Button();
            this.labelSetCost = new System.Windows.Forms.Label();
            this.labelDiscription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxUsers.ItemHeight = 20;
            this.listBoxUsers.Location = new System.Drawing.Point(23, 110);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(502, 304);
            this.listBoxUsers.TabIndex = 0;
            // 
            // textBoxCost
            // 
            this.textBoxCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCost.Location = new System.Drawing.Point(563, 160);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(177, 26);
            this.textBoxCost.TabIndex = 1;
            // 
            // buttonMakeReport
            // 
            this.buttonMakeReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMakeReport.Location = new System.Drawing.Point(563, 375);
            this.buttonMakeReport.Name = "buttonMakeReport";
            this.buttonMakeReport.Size = new System.Drawing.Size(177, 43);
            this.buttonMakeReport.TabIndex = 2;
            this.buttonMakeReport.Text = "Сформировать";
            this.buttonMakeReport.UseVisualStyleBackColor = true;
            this.buttonMakeReport.Click += new System.EventHandler(this.ButtonMakeReport_Click);
            // 
            // labelSetCost
            // 
            this.labelSetCost.AutoSize = true;
            this.labelSetCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSetCost.Location = new System.Drawing.Point(558, 110);
            this.labelSetCost.Name = "labelSetCost";
            this.labelSetCost.Size = new System.Drawing.Size(182, 25);
            this.labelSetCost.TabIndex = 3;
            this.labelSetCost.Text = "Заданная сумма";
            // 
            // labelDiscription
            // 
            this.labelDiscription.AutoSize = true;
            this.labelDiscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiscription.Location = new System.Drawing.Point(51, 40);
            this.labelDiscription.MaximumSize = new System.Drawing.Size(700, 80);
            this.labelDiscription.Name = "labelDiscription";
            this.labelDiscription.Size = new System.Drawing.Size(654, 40);
            this.labelDiscription.TabIndex = 4;
            this.labelDiscription.Text = "В отчете будут выведены клиенты, потратившие на заказы больше заданной суммы.";
            // 
            // PaidClientsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelDiscription);
            this.Controls.Add(this.labelSetCost);
            this.Controls.Add(this.buttonMakeReport);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.listBoxUsers);
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "PaidClientsReport";
            this.Text = "Отчет";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Button buttonMakeReport;
        private System.Windows.Forms.Label labelSetCost;
        private System.Windows.Forms.Label labelDiscription;
    }
}