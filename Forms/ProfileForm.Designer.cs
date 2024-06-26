﻿namespace _4RTools.Forms
{
    partial class ProfileForm
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
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveProfile = new System.Windows.Forms.Button();
            this.lblProfilesList = new System.Windows.Forms.Label();
            this.lbProfilesList = new System.Windows.Forms.ListBox();
            this.btnCopyProfile = new System.Windows.Forms.Button();
            this.btnRenameProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProfileName
            // 
            this.txtProfileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtProfileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileName.ForeColor = System.Drawing.Color.White;
            this.txtProfileName.Location = new System.Drawing.Point(23, 29);
            this.txtProfileName.Multiline = true;
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(238, 23);
            this.txtProfileName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(267, 29);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Create";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create a new profile";
            // 
            // btnRemoveProfile
            // 
            this.btnRemoveProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnRemoveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProfile.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProfile.Location = new System.Drawing.Point(267, 106);
            this.btnRemoveProfile.Name = "btnRemoveProfile";
            this.btnRemoveProfile.Size = new System.Drawing.Size(78, 23);
            this.btnRemoveProfile.TabIndex = 3;
            this.btnRemoveProfile.Text = "Remove Selected Profile";
            this.btnRemoveProfile.UseVisualStyleBackColor = false;
            this.btnRemoveProfile.Click += new System.EventHandler(this.btnRemoveProfile_Click);
            // 
            // lblProfilesList
            // 
            this.lblProfilesList.AutoSize = true;
            this.lblProfilesList.Location = new System.Drawing.Point(23, 61);
            this.lblProfilesList.Name = "lblProfilesList";
            this.lblProfilesList.Size = new System.Drawing.Size(55, 13);
            this.lblProfilesList.TabIndex = 6;
            this.lblProfilesList.Text = "Profile List";
            this.lblProfilesList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbProfilesList
            // 
            this.lbProfilesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.lbProfilesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbProfilesList.ForeColor = System.Drawing.Color.White;
            this.lbProfilesList.FormattingEnabled = true;
            this.lbProfilesList.Location = new System.Drawing.Point(23, 77);
            this.lbProfilesList.Name = "lbProfilesList";
            this.lbProfilesList.ScrollAlwaysVisible = true;
            this.lbProfilesList.Size = new System.Drawing.Size(238, 132);
            this.lbProfilesList.TabIndex = 8;
            // 
            // btnCopyProfile
            // 
            this.btnCopyProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnCopyProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCopyProfile.ForeColor = System.Drawing.Color.White;
            this.btnCopyProfile.Location = new System.Drawing.Point(267, 77);
            this.btnCopyProfile.Name = "button1";
            this.btnCopyProfile.Size = new System.Drawing.Size(78, 23);
            this.btnCopyProfile.TabIndex = 9;
            this.btnCopyProfile.Text = "Copy Selected Profile";
            this.btnCopyProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyProfile.UseVisualStyleBackColor = false;
            this.btnCopyProfile.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRenameProfile
            // 
            this.btnRenameProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnRenameProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRenameProfile.ForeColor = System.Drawing.Color.White;
            this.btnRenameProfile.Location = new System.Drawing.Point(267, 135);
            this.btnRenameProfile.Name = "button2";
            this.btnRenameProfile.Size = new System.Drawing.Size(78, 23);
            this.btnRenameProfile.TabIndex = 10;
            this.btnRenameProfile.Text = "Rename Selected Profile";
            this.btnRenameProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRenameProfile.UseVisualStyleBackColor = false;
            this.btnRenameProfile.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(374, 232);
            this.Controls.Add(this.btnRenameProfile);
            this.Controls.Add(this.btnCopyProfile);
            this.Controls.Add(this.lbProfilesList);
            this.Controls.Add(this.lblProfilesList);
            this.Controls.Add(this.btnRemoveProfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtProfileName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfileForm";
            this.Text = "ProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveProfile;
        private System.Windows.Forms.Label lblProfilesList;
        private System.Windows.Forms.ListBox lbProfilesList;
        private System.Windows.Forms.Button btnCopyProfile;
        private System.Windows.Forms.Button btnRenameProfile;
    }
}