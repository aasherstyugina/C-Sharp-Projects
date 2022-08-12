
namespace BuyersAndOrders
{
    partial class SellerApp
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxOrders = new System.Windows.Forms.ListBox();
            this.checkBoxActiveOrders = new System.Windows.Forms.CheckBox();
            this.labelUserList = new System.Windows.Forms.Label();
            this.labelOrderList = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paidOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payedOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.1809F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.8191F));
            this.tableLayoutPanel.Controls.Add(this.listBoxOrders, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.checkBoxActiveOrders, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelUserList, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelOrderList, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.listBoxUsers, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.menuStrip2, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.menuStrip1, 0, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(885, 443);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // listBoxOrders
            // 
            this.listBoxOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOrders.FormattingEnabled = true;
            this.listBoxOrders.ItemHeight = 16;
            this.listBoxOrders.Location = new System.Drawing.Point(323, 65);
            this.listBoxOrders.Name = "listBoxOrders";
            this.listBoxOrders.Size = new System.Drawing.Size(559, 340);
            this.listBoxOrders.TabIndex = 1;
            // 
            // checkBoxActiveOrders
            // 
            this.checkBoxActiveOrders.AutoSize = true;
            this.checkBoxActiveOrders.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBoxActiveOrders.Location = new System.Drawing.Point(323, 34);
            this.checkBoxActiveOrders.Name = "checkBoxActiveOrders";
            this.checkBoxActiveOrders.Size = new System.Drawing.Size(145, 25);
            this.checkBoxActiveOrders.TabIndex = 2;
            this.checkBoxActiveOrders.Text = "Активные заказы";
            this.checkBoxActiveOrders.UseVisualStyleBackColor = true;
            this.checkBoxActiveOrders.CheckedChanged += new System.EventHandler(this.CheckBoxActiveOrders_CheckedChanged);
            // 
            // labelUserList
            // 
            this.labelUserList.AutoSize = true;
            this.labelUserList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserList.Location = new System.Drawing.Point(3, 0);
            this.labelUserList.Name = "labelUserList";
            this.labelUserList.Size = new System.Drawing.Size(314, 25);
            this.labelUserList.TabIndex = 3;
            this.labelUserList.Text = "Список пользователей";
            // 
            // labelOrderList
            // 
            this.labelOrderList.AutoSize = true;
            this.labelOrderList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOrderList.Location = new System.Drawing.Point(323, 0);
            this.labelOrderList.Name = "labelOrderList";
            this.labelOrderList.Size = new System.Drawing.Size(559, 25);
            this.labelOrderList.TabIndex = 4;
            this.labelOrderList.Text = "Список заказов";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 16;
            this.listBoxUsers.Location = new System.Drawing.Point(3, 65);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(314, 340);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxUsers_SelectedIndexChanged);
            this.listBoxUsers.DoubleClick += new System.EventHandler(this.ListBoxUsers_DoubleClick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeStatusToolStripMenuItem,
            this.orderInfoToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(320, 411);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(565, 28);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // changeStatusToolStripMenuItem
            // 
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.changeStatusToolStripMenuItem.Text = "Изменить статус заказа";
            this.changeStatusToolStripMenuItem.Click += new System.EventHandler(this.ChangeStatusToolStripMenuItem_Click);
            // 
            // orderInfoToolStripMenuItem
            // 
            this.orderInfoToolStripMenuItem.Name = "orderInfoToolStripMenuItem";
            this.orderInfoToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.orderInfoToolStripMenuItem.Text = "Информация о заказе";
            this.orderInfoToolStripMenuItem.Click += new System.EventHandler(this.OrderInfoToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paidOrdersToolStripMenuItem,
            this.productOrderToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.reportToolStripMenuItem.Text = "Отчет";
            // 
            // paidOrdersToolStripMenuItem
            // 
            this.paidOrdersToolStripMenuItem.Name = "paidOrdersToolStripMenuItem";
            this.paidOrdersToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.paidOrdersToolStripMenuItem.Text = "Оплата заказов";
            this.paidOrdersToolStripMenuItem.Click += new System.EventHandler(this.PaidOrdersToolStripMenuItem_Click);
            // 
            // productOrderToolStripMenuItem
            // 
            this.productOrderToolStripMenuItem.Name = "productOrderToolStripMenuItem";
            this.productOrderToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.productOrderToolStripMenuItem.Text = "Заказ товара";
            this.productOrderToolStripMenuItem.Click += new System.EventHandler(this.ProductOrderToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.payedOrdersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 411);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(320, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.helpToolStripMenuItem.Text = "Справка";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // payedOrdersToolStripMenuItem
            // 
            this.payedOrdersToolStripMenuItem.Name = "payedOrdersToolStripMenuItem";
            this.payedOrdersToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.payedOrdersToolStripMenuItem.Text = "Сумма оплаченных заказов";
            this.payedOrdersToolStripMenuItem.Click += new System.EventHandler(this.PayedOrdersToolStripMenuItem_Click);
            // 
            // SellerApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 446);
            this.Controls.Add(this.tableLayoutPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "SellerApp";
            this.Text = "Продавец";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellerApp_FormClosing);
            this.Load += new System.EventHandler(this.SellerApp_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.ListBox listBoxOrders;
        private System.Windows.Forms.CheckBox checkBoxActiveOrders;
        private System.Windows.Forms.Label labelUserList;
        private System.Windows.Forms.Label labelOrderList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem changeStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payedOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paidOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productOrderToolStripMenuItem;
    }
}