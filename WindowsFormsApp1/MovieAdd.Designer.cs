namespace MovieCommentSystem
{
    partial class MovieAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieAdd));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblActor = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSearchDirector = new System.Windows.Forms.Button();
            this.btnSearchActor = new System.Windows.Forms.Button();
            this.lblPicture = new System.Windows.Forms.Label();
            this.txtPicture = new System.Windows.Forms.TextBox();
            this.btnSearchPicture = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.btnSearchType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxType = new System.Windows.Forms.ListBox();
            this.deleteType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxActor = new System.Windows.Forms.ListBox();
            this.deleteActor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.deleteType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(54, 50);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.BackColor = System.Drawing.Color.Transparent;
            this.lblYear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblYear.Location = new System.Drawing.Point(54, 94);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(35, 12);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Year:";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.BackColor = System.Drawing.Color.Transparent;
            this.lblDirector.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDirector.Location = new System.Drawing.Point(54, 140);
            this.lblDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(59, 12);
            this.lblDirector.TabIndex = 2;
            this.lblDirector.Text = "Director:";
            // 
            // lblActor
            // 
            this.lblActor.AutoSize = true;
            this.lblActor.BackColor = System.Drawing.Color.Transparent;
            this.lblActor.ForeColor = System.Drawing.Color.White;
            this.lblActor.Location = new System.Drawing.Point(234, 191);
            this.lblActor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(41, 12);
            this.lblActor.TabIndex = 3;
            this.lblActor.Text = "Actor:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(130, 47);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(169, 21);
            this.txtTitle.TabIndex = 6;
            // 
            // txtDirector
            // 
            this.txtDirector.BackColor = System.Drawing.Color.White;
            this.txtDirector.Enabled = false;
            this.txtDirector.Location = new System.Drawing.Point(130, 135);
            this.txtDirector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(169, 21);
            this.txtDirector.TabIndex = 8;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblSummary.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSummary.Location = new System.Drawing.Point(54, 399);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(53, 12);
            this.lblSummary.TabIndex = 12;
            this.lblSummary.Text = "Summary:";
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(130, 397);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(462, 97);
            this.txtSummary.TabIndex = 14;
            this.txtSummary.Text = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(205, 521);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 38);
            this.btnSubmit.TabIndex = 15;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(363, 521);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 38);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSearchDirector
            // 
            this.btnSearchDirector.Location = new System.Drawing.Point(323, 136);
            this.btnSearchDirector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchDirector.Name = "btnSearchDirector";
            this.btnSearchDirector.Size = new System.Drawing.Size(53, 20);
            this.btnSearchDirector.TabIndex = 17;
            this.btnSearchDirector.Text = "Search";
            this.btnSearchDirector.UseVisualStyleBackColor = true;
            this.btnSearchDirector.Click += new System.EventHandler(this.btnSearchDirector_Click);
            // 
            // btnSearchActor
            // 
            this.btnSearchActor.Location = new System.Drawing.Point(286, 294);
            this.btnSearchActor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchActor.Name = "btnSearchActor";
            this.btnSearchActor.Size = new System.Drawing.Size(53, 20);
            this.btnSearchActor.TabIndex = 18;
            this.btnSearchActor.Text = "Search";
            this.btnSearchActor.UseVisualStyleBackColor = true;
            this.btnSearchActor.Click += new System.EventHandler(this.btnSearchActor1_Click);
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.BackColor = System.Drawing.Color.Transparent;
            this.lblPicture.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPicture.Location = new System.Drawing.Point(53, 346);
            this.lblPicture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(53, 12);
            this.lblPicture.TabIndex = 21;
            this.lblPicture.Text = "Picture:";
            // 
            // txtPicture
            // 
            this.txtPicture.BackColor = System.Drawing.Color.White;
            this.txtPicture.Location = new System.Drawing.Point(130, 343);
            this.txtPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.ReadOnly = true;
            this.txtPicture.Size = new System.Drawing.Size(367, 21);
            this.txtPicture.TabIndex = 22;
            // 
            // btnSearchPicture
            // 
            this.btnSearchPicture.Location = new System.Drawing.Point(526, 337);
            this.btnSearchPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchPicture.Name = "btnSearchPicture";
            this.btnSearchPicture.Size = new System.Drawing.Size(64, 30);
            this.btnSearchPicture.TabIndex = 23;
            this.btnSearchPicture.Text = "Search";
            this.btnSearchPicture.UseVisualStyleBackColor = true;
            this.btnSearchPicture.Click += new System.EventHandler(this.btnSearchPicture_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblType.Location = new System.Drawing.Point(78, 191);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 12);
            this.lblType.TabIndex = 24;
            this.lblType.Text = "type:";
            // 
            // btnSearchType
            // 
            this.btnSearchType.Location = new System.Drawing.Point(131, 294);
            this.btnSearchType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchType.Name = "btnSearchType";
            this.btnSearchType.Size = new System.Drawing.Size(53, 20);
            this.btnSearchType.TabIndex = 28;
            this.btnSearchType.Text = "Search";
            this.btnSearchType.UseVisualStyleBackColor = true;
            this.btnSearchType.Click += new System.EventHandler(this.btnSearchType1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(38, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(38, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(38, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(38, 346);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(38, 399);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "*";
            // 
            // listBoxType
            // 
            this.listBoxType.FormattingEnabled = true;
            this.listBoxType.ItemHeight = 12;
            this.listBoxType.Location = new System.Drawing.Point(131, 191);
            this.listBoxType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxType.Name = "listBoxType";
            this.listBoxType.Size = new System.Drawing.Size(91, 88);
            this.listBoxType.TabIndex = 37;
            this.listBoxType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxType_MouseDown);
            // 
            // deleteType
            // 
            this.deleteType.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.deleteType.Name = "deleteType";
            this.deleteType.Size = new System.Drawing.Size(113, 26);
            this.deleteType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteType_MouseClick);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            // 
            // listBoxActor
            // 
            this.listBoxActor.FormattingEnabled = true;
            this.listBoxActor.ItemHeight = 12;
            this.listBoxActor.Location = new System.Drawing.Point(286, 191);
            this.listBoxActor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxActor.Name = "listBoxActor";
            this.listBoxActor.Size = new System.Drawing.Size(91, 88);
            this.listBoxActor.TabIndex = 38;
            this.listBoxActor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxActor_MouseDown);
            // 
            // deleteActor
            // 
            this.deleteActor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteActor.Name = "deleteActor";
            this.deleteActor.Size = new System.Drawing.Size(61, 4);
            this.deleteActor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteActor_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 80;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(130, 91);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 20);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(406, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // MovieAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.back1;
            this.ClientSize = new System.Drawing.Size(660, 581);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBoxActor);
            this.Controls.Add(this.listBoxType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnSearchPicture);
            this.Controls.Add(this.txtPicture);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.btnSearchActor);
            this.Controls.Add(this.btnSearchDirector);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblActor);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MovieAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovieAdd";
            this.Load += new System.EventHandler(this.MovieAdd_Load);
            this.deleteType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblActor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox txtSummary;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSearchDirector;
        private System.Windows.Forms.Button btnSearchActor;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.TextBox txtPicture;
        private System.Windows.Forms.Button btnSearchPicture;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxType;
        private System.Windows.Forms.ListBox listBoxActor;
        private System.Windows.Forms.ContextMenuStrip deleteType;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip deleteActor;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}