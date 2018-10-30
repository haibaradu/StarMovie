using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;


namespace MovieCommentSystem
{
    partial class UserCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCenter));
            this.labelName = new System.Windows.Forms.Label();
            this.btnMyLove = new System.Windows.Forms.Button();
            this.btnNewPwd = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbEm = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.userPortrait = new System.Windows.Forms.PictureBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userPortrait)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelName.Location = new System.Drawing.Point(35, 32);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(66, 25);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Hello!";
            // 
            // btnMyLove
            // 
            this.btnMyLove.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMyLove.Location = new System.Drawing.Point(39, 246);
            this.btnMyLove.Name = "btnMyLove";
            this.btnMyLove.Size = new System.Drawing.Size(123, 30);
            this.btnMyLove.TabIndex = 1;
            this.btnMyLove.Text = "My favortite";
            this.btnMyLove.UseVisualStyleBackColor = true;
            this.btnMyLove.Click += new System.EventHandler(this.btnMyLove_Click);
            // 
            // btnNewPwd
            // 
            this.btnNewPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewPwd.Location = new System.Drawing.Point(39, 291);
            this.btnNewPwd.Name = "btnNewPwd";
            this.btnNewPwd.Size = new System.Drawing.Size(123, 30);
            this.btnNewPwd.TabIndex = 7;
            this.btnNewPwd.Text = "Change password";
            this.btnNewPwd.UseVisualStyleBackColor = true;
            this.btnNewPwd.Click += new System.EventHandler(this.btnNewPwd_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbName.Location = new System.Drawing.Point(60, 71);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(50, 20);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "label1";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbEmail.Location = new System.Drawing.Point(61, 179);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(50, 20);
            this.lbEmail.TabIndex = 9;
            this.lbEmail.Text = "label2";
            // 
            // lbEm
            // 
            this.lbEm.AutoSize = true;
            this.lbEm.BackColor = System.Drawing.Color.Transparent;
            this.lbEm.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbEm.Location = new System.Drawing.Point(36, 137);
            this.lbEm.Name = "lbEm";
            this.lbEm.Size = new System.Drawing.Size(66, 25);
            this.lbEm.TabIndex = 13;
            this.lbEm.Text = "Email:";
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.back.Location = new System.Drawing.Point(264, 291);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 30);
            this.back.TabIndex = 14;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // userPortrait
            // 
            this.userPortrait.BackColor = System.Drawing.Color.Transparent;
            this.userPortrait.Location = new System.Drawing.Point(185, 12);
            this.userPortrait.Name = "userPortrait";
            this.userPortrait.Size = new System.Drawing.Size(259, 238);
            this.userPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPortrait.TabIndex = 12;
            this.userPortrait.TabStop = false;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinAllForm = false;
            this.skinEngine1.SkinFile = null;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(369, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 15;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(457, 343);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.lbEm);
            this.Controls.Add(this.userPortrait);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnNewPwd);
            this.Controls.Add(this.btnMyLove);
            this.Controls.Add(this.labelName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserCenter";
            this.Load += new System.EventHandler(this.UserCenter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPortrait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button btnMyLove;
        private System.Windows.Forms.Button btnNewPwd;
        private Label lbName;
        private Label lbEmail;
        private PictureBox userPortrait;
        private Label lbEm;
        private Button back;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private Button button1;
    }
}