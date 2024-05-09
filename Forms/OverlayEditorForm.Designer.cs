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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.groupList = new System.Windows.Forms.ListBox();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.pnlGroups = new System.Windows.Forms.Panel();
            this.btnGroupImport = new System.Windows.Forms.Button();
            this.btnGroupExport = new System.Windows.Forms.Button();
            this.btnGroupMoveDown = new System.Windows.Forms.Button();
            this.btnGroupMoveUp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxGroupEnabled = new System.Windows.Forms.CheckBox();
            this.btnBuffMoveDown = new System.Windows.Forms.Button();
            this.btnBuffMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveBuff = new System.Windows.Forms.Button();
            this.btnAddBuff = new System.Windows.Forms.Button();
            this.buffList = new System.Windows.Forms.ListBox();
            this.checkBoxGrowLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxGrowUp = new System.Windows.Forms.CheckBox();
            this.checkBoxVertical = new System.Windows.Forms.CheckBox();
            this.textMaxElementsY = new System.Windows.Forms.TextBox();
            this.textMaxElementsX = new System.Windows.Forms.TextBox();
            this.textGroupSpacing = new System.Windows.Forms.TextBox();
            this.textGroupSize = new System.Windows.Forms.TextBox();
            this.textGroupPosY = new System.Windows.Forms.TextBox();
            this.textGroupPosX = new System.Windows.Forms.TextBox();
            this.textGroupName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBuffIcon = new System.Windows.Forms.PictureBox();
            this.btnApplyBuffChanges = new System.Windows.Forms.Button();
            this.checkBoxBuffShowActive = new System.Windows.Forms.CheckBox();
            this.textBuffIcon = new System.Windows.Forms.TextBox();
            this.textBuffId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.pnlGroups.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBuffIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 20);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(3, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 20);
            label2.TabIndex = 5;
            label2.Text = "Position";
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(3, 61);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 20);
            label3.TabIndex = 8;
            label3.Text = "Icon Size";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(3, 87);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(72, 20);
            label4.TabIndex = 9;
            label4.Text = "Spacing";
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(227, 87);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(105, 20);
            label8.TabIndex = 15;
            label8.Text = "Max Elements";
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(4, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(72, 20);
            label5.TabIndex = 5;
            label5.Text = "Buff ID";
            // 
            // label6
            // 
            label6.Location = new System.Drawing.Point(4, 35);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 20);
            label6.TabIndex = 7;
            label6.Text = "Icon";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.ForeColor = System.Drawing.Color.Black;
            this.btnAddGroup.Location = new System.Drawing.Point(338, 3);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(84, 23);
            this.btnAddGroup.TabIndex = 1;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // groupList
            // 
            this.groupList.FormattingEnabled = true;
            this.groupList.Location = new System.Drawing.Point(3, 3);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(329, 108);
            this.groupList.TabIndex = 0;
            this.groupList.SelectedIndexChanged += new System.EventHandler(this.groupList_SelectedIndexChanged);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveGroup.Location = new System.Drawing.Point(338, 90);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(84, 23);
            this.btnRemoveGroup.TabIndex = 2;
            this.btnRemoveGroup.Text = "Remove";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // pnlGroups
            // 
            this.pnlGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGroups.Controls.Add(this.btnGroupImport);
            this.pnlGroups.Controls.Add(this.btnGroupExport);
            this.pnlGroups.Controls.Add(this.btnGroupMoveDown);
            this.pnlGroups.Controls.Add(this.btnGroupMoveUp);
            this.pnlGroups.Controls.Add(this.btnRemoveGroup);
            this.pnlGroups.Controls.Add(this.groupList);
            this.pnlGroups.Controls.Add(this.btnAddGroup);
            this.pnlGroups.Location = new System.Drawing.Point(12, 12);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(518, 118);
            this.pnlGroups.TabIndex = 3;
            // 
            // btnGroupImport
            // 
            this.btnGroupImport.ForeColor = System.Drawing.Color.Black;
            this.btnGroupImport.Location = new System.Drawing.Point(426, 32);
            this.btnGroupImport.Name = "btnGroupImport";
            this.btnGroupImport.Size = new System.Drawing.Size(84, 23);
            this.btnGroupImport.TabIndex = 6;
            this.btnGroupImport.Text = "Import";
            this.btnGroupImport.UseVisualStyleBackColor = true;
            this.btnGroupImport.Click += new System.EventHandler(this.btnGroupImport_Click);
            // 
            // btnGroupExport
            // 
            this.btnGroupExport.ForeColor = System.Drawing.Color.Black;
            this.btnGroupExport.Location = new System.Drawing.Point(426, 3);
            this.btnGroupExport.Name = "btnGroupExport";
            this.btnGroupExport.Size = new System.Drawing.Size(84, 23);
            this.btnGroupExport.TabIndex = 5;
            this.btnGroupExport.Text = "Export";
            this.btnGroupExport.UseVisualStyleBackColor = true;
            this.btnGroupExport.Click += new System.EventHandler(this.btnGroupExport_Click);
            // 
            // btnGroupMoveDown
            // 
            this.btnGroupMoveDown.ForeColor = System.Drawing.Color.Black;
            this.btnGroupMoveDown.Location = new System.Drawing.Point(338, 61);
            this.btnGroupMoveDown.Name = "btnGroupMoveDown";
            this.btnGroupMoveDown.Size = new System.Drawing.Size(84, 23);
            this.btnGroupMoveDown.TabIndex = 4;
            this.btnGroupMoveDown.Text = "Move Down";
            this.btnGroupMoveDown.UseVisualStyleBackColor = true;
            this.btnGroupMoveDown.Click += new System.EventHandler(this.btnGroupMoveDown_Click);
            // 
            // btnGroupMoveUp
            // 
            this.btnGroupMoveUp.ForeColor = System.Drawing.Color.Black;
            this.btnGroupMoveUp.Location = new System.Drawing.Point(338, 32);
            this.btnGroupMoveUp.Name = "btnGroupMoveUp";
            this.btnGroupMoveUp.Size = new System.Drawing.Size(84, 23);
            this.btnGroupMoveUp.TabIndex = 3;
            this.btnGroupMoveUp.Text = "Move Up";
            this.btnGroupMoveUp.UseVisualStyleBackColor = true;
            this.btnGroupMoveUp.Click += new System.EventHandler(this.btnGroupMoveUp_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxGroupEnabled);
            this.panel1.Controls.Add(this.btnBuffMoveDown);
            this.panel1.Controls.Add(this.btnBuffMoveUp);
            this.panel1.Controls.Add(this.btnRemoveBuff);
            this.panel1.Controls.Add(this.btnAddBuff);
            this.panel1.Controls.Add(this.buffList);
            this.panel1.Controls.Add(this.checkBoxGrowLeft);
            this.panel1.Controls.Add(this.checkBoxGrowUp);
            this.panel1.Controls.Add(this.checkBoxVertical);
            this.panel1.Controls.Add(this.textMaxElementsY);
            this.panel1.Controls.Add(this.textMaxElementsX);
            this.panel1.Controls.Add(label8);
            this.panel1.Controls.Add(this.textGroupSpacing);
            this.panel1.Controls.Add(this.textGroupSize);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(this.textGroupPosY);
            this.panel1.Controls.Add(this.textGroupPosX);
            this.panel1.Controls.Add(label2);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.textGroupName);
            this.panel1.Location = new System.Drawing.Point(12, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 264);
            this.panel1.TabIndex = 4;
            // 
            // checkBoxGroupEnabled
            // 
            this.checkBoxGroupEnabled.Location = new System.Drawing.Point(4, 110);
            this.checkBoxGroupEnabled.Name = "checkBoxGroupEnabled";
            this.checkBoxGroupEnabled.Size = new System.Drawing.Size(104, 24);
            this.checkBoxGroupEnabled.TabIndex = 23;
            this.checkBoxGroupEnabled.Text = "Enabled";
            this.checkBoxGroupEnabled.UseVisualStyleBackColor = true;
            this.checkBoxGroupEnabled.CheckedChanged += new System.EventHandler(this.checkBoxGroupEnabled_CheckedChanged);
            // 
            // btnBuffMoveDown
            // 
            this.btnBuffMoveDown.ForeColor = System.Drawing.Color.Black;
            this.btnBuffMoveDown.Location = new System.Drawing.Point(338, 209);
            this.btnBuffMoveDown.Name = "btnBuffMoveDown";
            this.btnBuffMoveDown.Size = new System.Drawing.Size(84, 23);
            this.btnBuffMoveDown.TabIndex = 5;
            this.btnBuffMoveDown.Text = "Move Down";
            this.btnBuffMoveDown.UseVisualStyleBackColor = true;
            this.btnBuffMoveDown.Click += new System.EventHandler(this.btnBuffMoveDown_Click);
            // 
            // btnBuffMoveUp
            // 
            this.btnBuffMoveUp.ForeColor = System.Drawing.Color.Black;
            this.btnBuffMoveUp.Location = new System.Drawing.Point(338, 180);
            this.btnBuffMoveUp.Name = "btnBuffMoveUp";
            this.btnBuffMoveUp.Size = new System.Drawing.Size(84, 23);
            this.btnBuffMoveUp.TabIndex = 5;
            this.btnBuffMoveUp.Text = "Move Up";
            this.btnBuffMoveUp.UseVisualStyleBackColor = true;
            this.btnBuffMoveUp.Click += new System.EventHandler(this.btnBuffMoveUp_Click);
            // 
            // btnRemoveBuff
            // 
            this.btnRemoveBuff.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveBuff.Location = new System.Drawing.Point(338, 238);
            this.btnRemoveBuff.Name = "btnRemoveBuff";
            this.btnRemoveBuff.Size = new System.Drawing.Size(84, 23);
            this.btnRemoveBuff.TabIndex = 22;
            this.btnRemoveBuff.Text = "Remove Buff";
            this.btnRemoveBuff.UseVisualStyleBackColor = true;
            this.btnRemoveBuff.Click += new System.EventHandler(this.btnRemoveBuff_Click);
            // 
            // btnAddBuff
            // 
            this.btnAddBuff.ForeColor = System.Drawing.Color.Black;
            this.btnAddBuff.Location = new System.Drawing.Point(338, 151);
            this.btnAddBuff.Name = "btnAddBuff";
            this.btnAddBuff.Size = new System.Drawing.Size(84, 23);
            this.btnAddBuff.TabIndex = 3;
            this.btnAddBuff.Text = "Add Buff";
            this.btnAddBuff.UseVisualStyleBackColor = true;
            this.btnAddBuff.Click += new System.EventHandler(this.btnAddBuff_Click);
            // 
            // buffList
            // 
            this.buffList.FormattingEnabled = true;
            this.buffList.Location = new System.Drawing.Point(3, 151);
            this.buffList.Name = "buffList";
            this.buffList.Size = new System.Drawing.Size(327, 108);
            this.buffList.TabIndex = 21;
            this.buffList.SelectedIndexChanged += new System.EventHandler(this.buffList_SelectedIndexChanged);
            // 
            // checkBoxGrowLeft
            // 
            this.checkBoxGrowLeft.Location = new System.Drawing.Point(227, 30);
            this.checkBoxGrowLeft.Name = "checkBoxGrowLeft";
            this.checkBoxGrowLeft.Size = new System.Drawing.Size(104, 24);
            this.checkBoxGrowLeft.TabIndex = 20;
            this.checkBoxGrowLeft.Text = "Grow Left";
            this.checkBoxGrowLeft.UseVisualStyleBackColor = true;
            this.checkBoxGrowLeft.CheckedChanged += new System.EventHandler(this.checkBoxGrowLeft_CheckedChanged);
            // 
            // checkBoxGrowUp
            // 
            this.checkBoxGrowUp.Location = new System.Drawing.Point(227, 56);
            this.checkBoxGrowUp.Name = "checkBoxGrowUp";
            this.checkBoxGrowUp.Size = new System.Drawing.Size(104, 24);
            this.checkBoxGrowUp.TabIndex = 19;
            this.checkBoxGrowUp.Text = "Grow Up";
            this.checkBoxGrowUp.UseVisualStyleBackColor = true;
            this.checkBoxGrowUp.CheckedChanged += new System.EventHandler(this.checkBoxGrowUp_CheckedChanged);
            // 
            // checkBoxVertical
            // 
            this.checkBoxVertical.Location = new System.Drawing.Point(227, 4);
            this.checkBoxVertical.Name = "checkBoxVertical";
            this.checkBoxVertical.Size = new System.Drawing.Size(104, 24);
            this.checkBoxVertical.TabIndex = 18;
            this.checkBoxVertical.Text = "Vertical Growth";
            this.checkBoxVertical.UseVisualStyleBackColor = true;
            this.checkBoxVertical.CheckedChanged += new System.EventHandler(this.checkBoxVertical_CheckedChanged);
            // 
            // textMaxElementsY
            // 
            this.textMaxElementsY.Location = new System.Drawing.Point(379, 84);
            this.textMaxElementsY.Name = "textMaxElementsY";
            this.textMaxElementsY.Size = new System.Drawing.Size(35, 20);
            this.textMaxElementsY.TabIndex = 17;
            this.textMaxElementsY.TextChanged += new System.EventHandler(this.textMaxElementsY_TextChanged);
            // 
            // textMaxElementsX
            // 
            this.textMaxElementsX.Location = new System.Drawing.Point(338, 84);
            this.textMaxElementsX.Name = "textMaxElementsX";
            this.textMaxElementsX.Size = new System.Drawing.Size(35, 20);
            this.textMaxElementsX.TabIndex = 16;
            this.textMaxElementsX.TextChanged += new System.EventHandler(this.textMaxElementsX_TextChanged);
            // 
            // textGroupSpacing
            // 
            this.textGroupSpacing.Location = new System.Drawing.Point(81, 84);
            this.textGroupSpacing.Name = "textGroupSpacing";
            this.textGroupSpacing.Size = new System.Drawing.Size(35, 20);
            this.textGroupSpacing.TabIndex = 11;
            this.textGroupSpacing.TextChanged += new System.EventHandler(this.textGroupSpacing_TextChanged);
            // 
            // textGroupSize
            // 
            this.textGroupSize.Location = new System.Drawing.Point(81, 58);
            this.textGroupSize.Name = "textGroupSize";
            this.textGroupSize.Size = new System.Drawing.Size(35, 20);
            this.textGroupSize.TabIndex = 10;
            this.textGroupSize.TextChanged += new System.EventHandler(this.textGroupSize_TextChanged);
            // 
            // textGroupPosY
            // 
            this.textGroupPosY.Location = new System.Drawing.Point(122, 32);
            this.textGroupPosY.Name = "textGroupPosY";
            this.textGroupPosY.Size = new System.Drawing.Size(35, 20);
            this.textGroupPosY.TabIndex = 7;
            this.textGroupPosY.TextChanged += new System.EventHandler(this.textGroupPosY_TextChanged);
            // 
            // textGroupPosX
            // 
            this.textGroupPosX.Location = new System.Drawing.Point(81, 32);
            this.textGroupPosX.Name = "textGroupPosX";
            this.textGroupPosX.Size = new System.Drawing.Size(35, 20);
            this.textGroupPosX.TabIndex = 6;
            this.textGroupPosX.TextChanged += new System.EventHandler(this.textGroupPosX_TextChanged);
            // 
            // textGroupName
            // 
            this.textGroupName.Location = new System.Drawing.Point(81, 6);
            this.textGroupName.Name = "textGroupName";
            this.textGroupName.Size = new System.Drawing.Size(100, 20);
            this.textGroupName.TabIndex = 3;
            this.textGroupName.TextChanged += new System.EventHandler(this.textGroupName_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBuffIcon);
            this.panel2.Controls.Add(this.btnApplyBuffChanges);
            this.panel2.Controls.Add(this.checkBoxBuffShowActive);
            this.panel2.Controls.Add(this.textBuffIcon);
            this.panel2.Controls.Add(label6);
            this.panel2.Controls.Add(this.textBuffId);
            this.panel2.Controls.Add(label5);
            this.panel2.Location = new System.Drawing.Point(12, 406);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 85);
            this.panel2.TabIndex = 5;
            // 
            // pictureBuffIcon
            // 
            this.pictureBuffIcon.Location = new System.Drawing.Point(447, 6);
            this.pictureBuffIcon.Name = "pictureBuffIcon";
            this.pictureBuffIcon.Size = new System.Drawing.Size(40, 40);
            this.pictureBuffIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBuffIcon.TabIndex = 21;
            this.pictureBuffIcon.TabStop = false;
            // 
            // btnApplyBuffChanges
            // 
            this.btnApplyBuffChanges.ForeColor = System.Drawing.Color.Black;
            this.btnApplyBuffChanges.Location = new System.Drawing.Point(415, 52);
            this.btnApplyBuffChanges.Name = "btnApplyBuffChanges";
            this.btnApplyBuffChanges.Size = new System.Drawing.Size(95, 23);
            this.btnApplyBuffChanges.TabIndex = 20;
            this.btnApplyBuffChanges.Text = "Apply";
            this.btnApplyBuffChanges.UseVisualStyleBackColor = true;
            this.btnApplyBuffChanges.Click += new System.EventHandler(this.btnApplyBuffChanges_Click);
            // 
            // checkBoxBuffShowActive
            // 
            this.checkBoxBuffShowActive.Location = new System.Drawing.Point(4, 58);
            this.checkBoxBuffShowActive.Name = "checkBoxBuffShowActive";
            this.checkBoxBuffShowActive.Size = new System.Drawing.Size(104, 24);
            this.checkBoxBuffShowActive.TabIndex = 19;
            this.checkBoxBuffShowActive.Text = "ShowActive";
            this.checkBoxBuffShowActive.UseVisualStyleBackColor = true;
            // 
            // textBuffIcon
            // 
            this.textBuffIcon.Location = new System.Drawing.Point(82, 32);
            this.textBuffIcon.Name = "textBuffIcon";
            this.textBuffIcon.Size = new System.Drawing.Size(100, 20);
            this.textBuffIcon.TabIndex = 8;
            // 
            // textBuffId
            // 
            this.textBuffId.Location = new System.Drawing.Point(82, 6);
            this.textBuffId.Name = "textBuffId";
            this.textBuffId.Size = new System.Drawing.Size(100, 20);
            this.textBuffId.TabIndex = 6;
            // 
            // OverlayEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (43)))), ((int) (((byte) (45)))), ((int) (((byte) (49)))));
            this.ClientSize = new System.Drawing.Size(542, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlGroups);
            this.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (148)))), ((int) (((byte) (155)))), ((int) (((byte) (164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "OverlayEditorForm";
            this.pnlGroups.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBuffIcon)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnGroupExport;
        private System.Windows.Forms.Button btnGroupImport;

        private System.Windows.Forms.CheckBox checkBoxGroupEnabled;

        private System.Windows.Forms.Button btnGroupMoveUp;
        private System.Windows.Forms.Button btnGroupMoveDown;
        private System.Windows.Forms.Button btnBuffMoveUp;
        private System.Windows.Forms.Button btnBuffMoveDown;

        private System.Windows.Forms.PictureBox pictureBuffIcon;

        private System.Windows.Forms.Button btnApplyBuffChanges;

        private System.Windows.Forms.CheckBox checkBoxBuffShowActive;

        private System.Windows.Forms.TextBox textBuffId;
        private System.Windows.Forms.TextBox textBuffIcon;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Button btnRemoveBuff;

        private System.Windows.Forms.ListBox buffList;
        private System.Windows.Forms.Button btnAddBuff;

        private System.Windows.Forms.CheckBox checkBoxGrowUp;
        private System.Windows.Forms.CheckBox checkBoxGrowLeft;

        private System.Windows.Forms.TextBox textMaxElementsY;
        private System.Windows.Forms.TextBox textMaxElementsX;
        private System.Windows.Forms.CheckBox checkBoxVertical;

        private System.Windows.Forms.TextBox textGroupSize;
        private System.Windows.Forms.TextBox textGroupSpacing;

        private System.Windows.Forms.TextBox textGroupPosX;
        private System.Windows.Forms.TextBox textGroupPosY;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textGroupName;

        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ListBox groupList;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Panel pnlGroups;

        #endregion
    }
}