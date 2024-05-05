using _4RTools.Utils;

namespace _4RTools.Forms
{
    partial class InputForm
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnConfirmInput = new System.Windows.Forms.Button();
            this.btnCancelInput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(16, 29);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(213, 23);
            this.txtInput.TabIndex = 11;
            // 
            // lblInput
            // 
            this.lblInput.Location = new System.Drawing.Point(13, 4);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(216, 22);
            this.lblInput.TabIndex = 13;
            this.lblInput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnConfirmInput
            // 
            this.btnConfirmInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnConfirmInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirmInput.ForeColor = System.Drawing.Color.White;
            this.btnConfirmInput.Location = new System.Drawing.Point(16, 70);
            this.btnConfirmInput.Name = "btnConfirmInput";
            this.btnConfirmInput.Size = new System.Drawing.Size(78, 23);
            this.btnConfirmInput.TabIndex = 14;
            this.btnConfirmInput.Text = "Confirm";
            this.btnConfirmInput.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmInput.UseVisualStyleBackColor = false;
            this.btnConfirmInput.Click += new System.EventHandler(this.btnCancelInput_Click);
            // 
            // btnCancelInput
            // 
            this.btnCancelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnCancelInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelInput.ForeColor = System.Drawing.Color.White;
            this.btnCancelInput.Location = new System.Drawing.Point(151, 70);
            this.btnCancelInput.Name = "btnCancelInput";
            this.btnCancelInput.Size = new System.Drawing.Size(78, 23);
            this.btnCancelInput.TabIndex = 15;
            this.btnCancelInput.Text = "Cancel";
            this.btnCancelInput.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelInput.UseVisualStyleBackColor = false;
            this.btnCancelInput.Click += new System.EventHandler(this.btnCancelInput_Click_1);
            // 
            // InputForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(254, 106);
            this.Controls.Add(this.btnCancelInput);
            this.Controls.Add(this.btnConfirmInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatusEffect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnConfirmInput;
        private System.Windows.Forms.Button btnCancelInput;
    }
}