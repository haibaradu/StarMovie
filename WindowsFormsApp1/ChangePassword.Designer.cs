namespace MovieCommentSystem
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.labelPrePwd = new System.Windows.Forms.Label();
            this.textBoxPrePwd = new System.Windows.Forms.TextBox();
            this.labelNewPwd = new System.Windows.Forms.Label();
            this.textBoxNewPwd = new System.Windows.Forms.TextBox();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.textBoxConfirm = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPrePwd
            // 
            this.labelPrePwd.AutoSize = true;
            this.labelPrePwd.BackColor = System.Drawing.Color.Transparent;
            this.labelPrePwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPrePwd.Location = new System.Drawing.Point(12, 37);
            this.labelPrePwd.Name = "labelPrePwd";
            this.labelPrePwd.Size = new System.Drawing.Size(213, 20);
            this.labelPrePwd.TabIndex = 0;
            this.labelPrePwd.Text = "Enter your previous password :";
            // 
            // textBoxPrePwd
            // 
            this.textBoxPrePwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPrePwd.Location = new System.Drawing.Point(76, 71);
            this.textBoxPrePwd.Name = "textBoxPrePwd";
            this.textBoxPrePwd.PasswordChar = '*';
            this.textBoxPrePwd.Size = new System.Drawing.Size(183, 26);
            this.textBoxPrePwd.TabIndex = 1;
            this.textBoxPrePwd.TextChanged += new System.EventHandler(this.textBoxPrePwd_TextChanged);
            // 
            // labelNewPwd
            // 
            this.labelNewPwd.AutoSize = true;
            this.labelNewPwd.BackColor = System.Drawing.Color.Transparent;
            this.labelNewPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNewPwd.Location = new System.Drawing.Point(12, 111);
            this.labelNewPwd.Name = "labelNewPwd";
            this.labelNewPwd.Size = new System.Drawing.Size(146, 20);
            this.labelNewPwd.TabIndex = 3;
            this.labelNewPwd.Text = "Your new password :";
            // 
            // textBoxNewPwd
            // 
            this.textBoxNewPwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNewPwd.Location = new System.Drawing.Point(76, 147);
            this.textBoxNewPwd.Name = "textBoxNewPwd";
            this.textBoxNewPwd.PasswordChar = '*';
            this.textBoxNewPwd.Size = new System.Drawing.Size(183, 26);
            this.textBoxNewPwd.TabIndex = 4;
            // 
            // labelConfirm
            // 
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.BackColor = System.Drawing.Color.Transparent;
            this.labelConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelConfirm.Location = new System.Drawing.Point(12, 191);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(83, 20);
            this.labelConfirm.TabIndex = 5;
            this.labelConfirm.Text = "Confirm it :";
            // 
            // textBoxConfirm
            // 
            this.textBoxConfirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxConfirm.Location = new System.Drawing.Point(76, 213);
            this.textBoxConfirm.Name = "textBoxConfirm";
            this.textBoxConfirm.PasswordChar = '*';
            this.textBoxConfirm.Size = new System.Drawing.Size(183, 26);
            this.textBoxConfirm.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(56, 262);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBack.Location = new System.Drawing.Point(174, 262);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(85, 23);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.mainBack;
            this.ClientSize = new System.Drawing.Size(326, 308);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.textBoxConfirm);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.textBoxNewPwd);
            this.Controls.Add(this.labelNewPwd);
            this.Controls.Add(this.textBoxPrePwd);
            this.Controls.Add(this.labelPrePwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPrePwd;
        private System.Windows.Forms.TextBox textBoxPrePwd;
        private System.Windows.Forms.Label labelNewPwd;
        private System.Windows.Forms.TextBox textBoxNewPwd;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox textBoxConfirm;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button buttonBack;
    }
}