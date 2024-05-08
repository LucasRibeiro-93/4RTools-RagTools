using System.ComponentModel;

namespace _4RTools.Forms
{
    partial class OverlayEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.PlaceholderSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlaceholderSave
            // 
            this.PlaceholderSave.ForeColor = System.Drawing.Color.Black;
            this.PlaceholderSave.Location = new System.Drawing.Point(12, 12);
            this.PlaceholderSave.Name = "PlaceholderSave";
            this.PlaceholderSave.Size = new System.Drawing.Size(75, 23);
            this.PlaceholderSave.TabIndex = 0;
            this.PlaceholderSave.Text = "Save";
            this.PlaceholderSave.UseVisualStyleBackColor = true;
            this.PlaceholderSave.Click += new System.EventHandler(this.PlaceholderSave_Click);
            // 
            // OverlayEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (43)))), ((int) (((byte) (45)))), ((int) (((byte) (49)))));
            this.ClientSize = new System.Drawing.Size(542, 542);
            this.Controls.Add(this.PlaceholderSave);
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (155)))), ((int) (((byte) (164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OverlayEditorForm";
            this.Text = "OverlayEditorForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button PlaceholderSave;

        #endregion
    }
}