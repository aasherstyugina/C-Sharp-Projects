namespace FractalCreater
{
    partial class Form1
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
            this.headline = new System.Windows.Forms.Label();
            this.kindOfFractalLabel = new System.Windows.Forms.Label();
            this.kindOfFractal = new System.Windows.Forms.ComboBox();
            this.startColorDialog = new System.Windows.Forms.ColorDialog();
            this.endColorDialog = new System.Windows.Forms.ColorDialog();
            this.startColorButton = new System.Windows.Forms.Button();
            this.endColorButton = new System.Windows.Forms.Button();
            this.startColorLabel = new System.Windows.Forms.Label();
            this.endColorLabel = new System.Windows.Forms.Label();
            this.recursionDepthLabel = new System.Windows.Forms.Label();
            this.recursionTrackBar = new System.Windows.Forms.TrackBar();
            this.currentTrackBar1 = new System.Windows.Forms.Label();
            this.currentTrackBar2 = new System.Windows.Forms.Label();
            this.lengthTrackBar = new System.Windows.Forms.TrackBar();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.currentTrackBar3 = new System.Windows.Forms.Label();
            this.angle1TrackBar = new System.Windows.Forms.TrackBar();
            this.angle1Label1 = new System.Windows.Forms.Label();
            this.currentTrackBar4 = new System.Windows.Forms.Label();
            this.angle2TrackBar = new System.Windows.Forms.TrackBar();
            this.angle2Label1 = new System.Windows.Forms.Label();
            this.currentTrackBar5 = new System.Windows.Forms.Label();
            this.coefficientTrackBar = new System.Windows.Forms.TrackBar();
            this.coefficientLabel = new System.Windows.Forms.Label();
            this.angle1Label2 = new System.Windows.Forms.Label();
            this.angle2Label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.submitButton = new System.Windows.Forms.Button();
            this.currentTrackBar6 = new System.Windows.Forms.Label();
            this.distanceTrackBar = new System.Windows.Forms.TrackBar();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkStart = new System.Windows.Forms.Label();
            this.checkEnd = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.recursionTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle1TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle2TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coefficientTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // headline
            // 
            this.headline.AutoSize = true;
            this.headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headline.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.headline.Location = new System.Drawing.Point(636, 9);
            this.headline.Name = "headline";
            this.headline.Size = new System.Drawing.Size(168, 31);
            this.headline.TabIndex = 0;
            this.headline.Text = "Параметры";
            // 
            // kindOfFractalLabel
            // 
            this.kindOfFractalLabel.AutoSize = true;
            this.kindOfFractalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kindOfFractalLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.kindOfFractalLabel.Location = new System.Drawing.Point(23, 45);
            this.kindOfFractalLabel.Name = "kindOfFractalLabel";
            this.kindOfFractalLabel.Size = new System.Drawing.Size(120, 18);
            this.kindOfFractalLabel.TabIndex = 1;
            this.kindOfFractalLabel.Text = "Вид фрактала";
            // 
            // kindOfFractal
            // 
            this.kindOfFractal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kindOfFractal.FormattingEnabled = true;
            this.kindOfFractal.Items.AddRange(new object[] {
            "Обдуваемое ветром дерево",
            "Кривая Коха",
            "Ковер Серпинского",
            "Треугольник Серпинского",
            "Множество Кантора"});
            this.kindOfFractal.Location = new System.Drawing.Point(27, 82);
            this.kindOfFractal.Name = "kindOfFractal";
            this.kindOfFractal.Size = new System.Drawing.Size(221, 24);
            this.kindOfFractal.TabIndex = 2;
            this.kindOfFractal.SelectedIndexChanged += new System.EventHandler(this.kindOfFractal_SelectedIndexChanged);
            // 
            // startColorButton
            // 
            this.startColorButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startColorButton.Location = new System.Drawing.Point(27, 127);
            this.startColorButton.Name = "startColorButton";
            this.startColorButton.Size = new System.Drawing.Size(102, 32);
            this.startColorButton.TabIndex = 3;
            this.startColorButton.UseVisualStyleBackColor = false;
            this.startColorButton.Click += new System.EventHandler(this.startColorButton_Click);
            // 
            // endColorButton
            // 
            this.endColorButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.endColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endColorButton.Location = new System.Drawing.Point(146, 127);
            this.endColorButton.Name = "endColorButton";
            this.endColorButton.Size = new System.Drawing.Size(102, 32);
            this.endColorButton.TabIndex = 4;
            this.endColorButton.UseVisualStyleBackColor = false;
            this.endColorButton.Click += new System.EventHandler(this.endColorButton_Click);
            // 
            // startColorLabel
            // 
            this.startColorLabel.AutoSize = true;
            this.startColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startColorLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.startColorLabel.Location = new System.Drawing.Point(23, 173);
            this.startColorLabel.Name = "startColorLabel";
            this.startColorLabel.Size = new System.Drawing.Size(101, 24);
            this.startColorLabel.TabIndex = 5;
            this.startColorLabel.Text = "StartColor";
            // 
            // endColorLabel
            // 
            this.endColorLabel.AutoSize = true;
            this.endColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endColorLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.endColorLabel.Location = new System.Drawing.Point(147, 173);
            this.endColorLabel.Name = "endColorLabel";
            this.endColorLabel.Size = new System.Drawing.Size(98, 24);
            this.endColorLabel.TabIndex = 6;
            this.endColorLabel.Text = "EndColor";
            // 
            // recursionDepthLabel
            // 
            this.recursionDepthLabel.AutoSize = true;
            this.recursionDepthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recursionDepthLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.recursionDepthLabel.Location = new System.Drawing.Point(266, 45);
            this.recursionDepthLabel.Name = "recursionDepthLabel";
            this.recursionDepthLabel.Size = new System.Drawing.Size(149, 18);
            this.recursionDepthLabel.TabIndex = 7;
            this.recursionDepthLabel.Text = "Глубина рекурсии";
            // 
            // recursionTrackBar
            // 
            this.recursionTrackBar.Location = new System.Drawing.Point(269, 82);
            this.recursionTrackBar.Maximum = 7;
            this.recursionTrackBar.Minimum = 1;
            this.recursionTrackBar.Name = "recursionTrackBar";
            this.recursionTrackBar.Size = new System.Drawing.Size(220, 56);
            this.recursionTrackBar.TabIndex = 8;
            this.recursionTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.recursionTrackBar.Value = 1;
            this.recursionTrackBar.Scroll += new System.EventHandler(this.recursionTrackBar_Scroll);
            // 
            // currentTrackBar1
            // 
            this.currentTrackBar1.AutoSize = true;
            this.currentTrackBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTrackBar1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentTrackBar1.Location = new System.Drawing.Point(266, 142);
            this.currentTrackBar1.Name = "currentTrackBar1";
            this.currentTrackBar1.Size = new System.Drawing.Size(0, 15);
            this.currentTrackBar1.TabIndex = 9;
            // 
            // currentTrackBar2
            // 
            this.currentTrackBar2.AutoSize = true;
            this.currentTrackBar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTrackBar2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentTrackBar2.Location = new System.Drawing.Point(506, 142);
            this.currentTrackBar2.Name = "currentTrackBar2";
            this.currentTrackBar2.Size = new System.Drawing.Size(0, 15);
            this.currentTrackBar2.TabIndex = 12;
            // 
            // lengthTrackBar
            // 
            this.lengthTrackBar.Location = new System.Drawing.Point(509, 82);
            this.lengthTrackBar.Maximum = 450;
            this.lengthTrackBar.Minimum = 1;
            this.lengthTrackBar.Name = "lengthTrackBar";
            this.lengthTrackBar.Size = new System.Drawing.Size(220, 56);
            this.lengthTrackBar.TabIndex = 11;
            this.lengthTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.lengthTrackBar.Value = 1;
            this.lengthTrackBar.Scroll += new System.EventHandler(this.lengthTrackBar_Scroll);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lengthLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lengthLabel.Location = new System.Drawing.Point(506, 45);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(126, 18);
            this.lengthLabel.TabIndex = 10;
            this.lengthLabel.Text = "Длина отрезка";
            // 
            // currentTrackBar3
            // 
            this.currentTrackBar3.AutoSize = true;
            this.currentTrackBar3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTrackBar3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentTrackBar3.Location = new System.Drawing.Point(751, 142);
            this.currentTrackBar3.Name = "currentTrackBar3";
            this.currentTrackBar3.Size = new System.Drawing.Size(0, 15);
            this.currentTrackBar3.TabIndex = 15;
            this.currentTrackBar3.Visible = false;
            // 
            // angle1TrackBar
            // 
            this.angle1TrackBar.Location = new System.Drawing.Point(754, 82);
            this.angle1TrackBar.Maximum = 90;
            this.angle1TrackBar.Minimum = 1;
            this.angle1TrackBar.Name = "angle1TrackBar";
            this.angle1TrackBar.Size = new System.Drawing.Size(220, 56);
            this.angle1TrackBar.TabIndex = 14;
            this.angle1TrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.angle1TrackBar.Value = 1;
            this.angle1TrackBar.Visible = false;
            this.angle1TrackBar.Scroll += new System.EventHandler(this.angle1TrackBar_Scroll);
            // 
            // angle1Label1
            // 
            this.angle1Label1.AutoSize = true;
            this.angle1Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle1Label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.angle1Label1.Location = new System.Drawing.Point(760, 45);
            this.angle1Label1.Name = "angle1Label1";
            this.angle1Label1.Size = new System.Drawing.Size(116, 18);
            this.angle1Label1.TabIndex = 13;
            this.angle1Label1.Text = "Угол наклона";
            this.angle1Label1.Visible = false;
            // 
            // currentTrackBar4
            // 
            this.currentTrackBar4.AutoSize = true;
            this.currentTrackBar4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTrackBar4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentTrackBar4.Location = new System.Drawing.Point(991, 142);
            this.currentTrackBar4.Name = "currentTrackBar4";
            this.currentTrackBar4.Size = new System.Drawing.Size(0, 15);
            this.currentTrackBar4.TabIndex = 18;
            this.currentTrackBar4.Visible = false;
            // 
            // angle2TrackBar
            // 
            this.angle2TrackBar.Location = new System.Drawing.Point(994, 82);
            this.angle2TrackBar.Maximum = 90;
            this.angle2TrackBar.Minimum = 1;
            this.angle2TrackBar.Name = "angle2TrackBar";
            this.angle2TrackBar.Size = new System.Drawing.Size(220, 56);
            this.angle2TrackBar.TabIndex = 17;
            this.angle2TrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.angle2TrackBar.Value = 1;
            this.angle2TrackBar.Visible = false;
            this.angle2TrackBar.Scroll += new System.EventHandler(this.angle2TrackBar_Scroll);
            // 
            // angle2Label1
            // 
            this.angle2Label1.AutoSize = true;
            this.angle2Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle2Label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.angle2Label1.Location = new System.Drawing.Point(990, 45);
            this.angle2Label1.Name = "angle2Label1";
            this.angle2Label1.Size = new System.Drawing.Size(116, 18);
            this.angle2Label1.TabIndex = 16;
            this.angle2Label1.Text = "Угол наклона";
            this.angle2Label1.Visible = false;
            // 
            // currentTrackBar5
            // 
            this.currentTrackBar5.AutoSize = true;
            this.currentTrackBar5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTrackBar5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentTrackBar5.Location = new System.Drawing.Point(1241, 142);
            this.currentTrackBar5.Name = "currentTrackBar5";
            this.currentTrackBar5.Size = new System.Drawing.Size(0, 15);
            this.currentTrackBar5.TabIndex = 21;
            this.currentTrackBar5.Visible = false;
            // 
            // coefficientTrackBar
            // 
            this.coefficientTrackBar.Location = new System.Drawing.Point(1233, 83);
            this.coefficientTrackBar.Minimum = 1;
            this.coefficientTrackBar.Name = "coefficientTrackBar";
            this.coefficientTrackBar.Size = new System.Drawing.Size(220, 56);
            this.coefficientTrackBar.TabIndex = 20;
            this.coefficientTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.coefficientTrackBar.Value = 1;
            this.coefficientTrackBar.Visible = false;
            this.coefficientTrackBar.Scroll += new System.EventHandler(this.coefficientTrackBar_Scroll);
            // 
            // coefficientLabel
            // 
            this.coefficientLabel.AutoSize = true;
            this.coefficientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coefficientLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.coefficientLabel.Location = new System.Drawing.Point(1221, 45);
            this.coefficientLabel.Name = "coefficientLabel";
            this.coefficientLabel.Size = new System.Drawing.Size(232, 18);
            this.coefficientLabel.TabIndex = 19;
            this.coefficientLabel.Text = "Отношение соседних ветвей";
            this.coefficientLabel.Visible = false;
            // 
            // angle1Label2
            // 
            this.angle1Label2.AutoSize = true;
            this.angle1Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle1Label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.angle1Label2.Location = new System.Drawing.Point(760, 61);
            this.angle1Label2.Name = "angle1Label2";
            this.angle1Label2.Size = new System.Drawing.Size(139, 18);
            this.angle1Label2.TabIndex = 22;
            this.angle1Label2.Text = "первого отрезка";
            this.angle1Label2.Visible = false;
            // 
            // angle2Label2
            // 
            this.angle2Label2.AutoSize = true;
            this.angle2Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.angle2Label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.angle2Label2.Location = new System.Drawing.Point(991, 61);
            this.angle2Label2.Name = "angle2Label2";
            this.angle2Label2.Size = new System.Drawing.Size(139, 18);
            this.angle2Label2.TabIndex = 23;
            this.angle2Label2.Text = "второго отрезка";
            this.angle2Label2.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 863);
            this.splitter1.TabIndex = 24;
            this.splitter1.TabStop = false;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.submitButton.Location = new System.Drawing.Point(642, 167);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(162, 36);
            this.submitButton.TabIndex = 25;
            this.submitButton.Text = "Подтвердить";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // currentTrackBar6
            // 
            this.currentTrackBar6.AutoSize = true;
            this.currentTrackBar6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTrackBar6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.currentTrackBar6.Location = new System.Drawing.Point(977, 142);
            this.currentTrackBar6.Name = "currentTrackBar6";
            this.currentTrackBar6.Size = new System.Drawing.Size(0, 15);
            this.currentTrackBar6.TabIndex = 28;
            this.currentTrackBar6.Visible = false;
            // 
            // distanceTrackBar
            // 
            this.distanceTrackBar.Location = new System.Drawing.Point(980, 82);
            this.distanceTrackBar.Minimum = 2;
            this.distanceTrackBar.Name = "distanceTrackBar";
            this.distanceTrackBar.Size = new System.Drawing.Size(220, 56);
            this.distanceTrackBar.TabIndex = 27;
            this.distanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.distanceTrackBar.Value = 2;
            this.distanceTrackBar.Visible = false;
            this.distanceTrackBar.Scroll += new System.EventHandler(this.distanceTrackBar_Scroll);
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distanceLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.distanceLabel.Location = new System.Drawing.Point(977, 45);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(258, 18);
            this.distanceLabel.TabIndex = 26;
            this.distanceLabel.Text = "Какая часть отрезка удаляется";
            this.distanceLabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Location = new System.Drawing.Point(86, 220);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1307, 578);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // checkStart
            // 
            this.checkStart.AutoSize = true;
            this.checkStart.Location = new System.Drawing.Point(49, 109);
            this.checkStart.Name = "checkStart";
            this.checkStart.Size = new System.Drawing.Size(46, 17);
            this.checkStart.TabIndex = 30;
            this.checkStart.Text = "label1";
            this.checkStart.Visible = false;
            // 
            // checkEnd
            // 
            this.checkEnd.AutoSize = true;
            this.checkEnd.Location = new System.Drawing.Point(177, 109);
            this.checkEnd.Name = "checkEnd";
            this.checkEnd.Size = new System.Drawing.Size(46, 17);
            this.checkEnd.TabIndex = 31;
            this.checkEnd.Text = "label1";
            this.checkEnd.Visible = false;
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Maroon;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.save.Location = new System.Drawing.Point(1173, 167);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(207, 36);
            this.save.TabIndex = 32;
            this.save.Text = "Сохранить в файл";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1476, 863);
            this.Controls.Add(this.save);
            this.Controls.Add(this.checkEnd);
            this.Controls.Add(this.checkStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.currentTrackBar6);
            this.Controls.Add(this.distanceTrackBar);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.angle2Label2);
            this.Controls.Add(this.angle1Label2);
            this.Controls.Add(this.currentTrackBar5);
            this.Controls.Add(this.coefficientTrackBar);
            this.Controls.Add(this.coefficientLabel);
            this.Controls.Add(this.currentTrackBar4);
            this.Controls.Add(this.angle2TrackBar);
            this.Controls.Add(this.angle2Label1);
            this.Controls.Add(this.currentTrackBar3);
            this.Controls.Add(this.angle1TrackBar);
            this.Controls.Add(this.angle1Label1);
            this.Controls.Add(this.currentTrackBar2);
            this.Controls.Add(this.lengthTrackBar);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.currentTrackBar1);
            this.Controls.Add(this.recursionTrackBar);
            this.Controls.Add(this.recursionDepthLabel);
            this.Controls.Add(this.endColorLabel);
            this.Controls.Add(this.startColorLabel);
            this.Controls.Add(this.endColorButton);
            this.Controls.Add(this.startColorButton);
            this.Controls.Add(this.kindOfFractal);
            this.Controls.Add(this.kindOfFractalLabel);
            this.Controls.Add(this.headline);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.recursionTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle1TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle2TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coefficientTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headline;
        private System.Windows.Forms.Label kindOfFractalLabel;
        private System.Windows.Forms.ComboBox kindOfFractal;
        private System.Windows.Forms.ColorDialog startColorDialog;
        private System.Windows.Forms.ColorDialog endColorDialog;
        private System.Windows.Forms.Button startColorButton;
        private System.Windows.Forms.Button endColorButton;
        private System.Windows.Forms.Label startColorLabel;
        private System.Windows.Forms.Label endColorLabel;
        private System.Windows.Forms.Label recursionDepthLabel;
        private System.Windows.Forms.TrackBar recursionTrackBar;
        private System.Windows.Forms.Label currentTrackBar1;
        private System.Windows.Forms.Label currentTrackBar2;
        private System.Windows.Forms.TrackBar lengthTrackBar;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label currentTrackBar3;
        private System.Windows.Forms.TrackBar angle1TrackBar;
        private System.Windows.Forms.Label angle1Label1;
        private System.Windows.Forms.Label currentTrackBar4;
        private System.Windows.Forms.TrackBar angle2TrackBar;
        private System.Windows.Forms.Label angle2Label1;
        private System.Windows.Forms.Label currentTrackBar5;
        private System.Windows.Forms.TrackBar coefficientTrackBar;
        private System.Windows.Forms.Label coefficientLabel;
        private System.Windows.Forms.Label angle1Label2;
        private System.Windows.Forms.Label angle2Label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label currentTrackBar6;
        private System.Windows.Forms.TrackBar distanceTrackBar;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label checkStart;
        private System.Windows.Forms.Label checkEnd;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

