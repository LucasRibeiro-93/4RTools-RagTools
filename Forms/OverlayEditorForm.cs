using System;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Overlay;
using _4RTools.Utils;
using Newtonsoft.Json;

namespace _4RTools.Forms
{
    public partial class OverlayEditorForm : Form, IObserver
    {
        private OverlayCanvas _overlayCanvas = new OverlayCanvas();
        
        private BindingSource _groupListBindingSource = new BindingSource();
        private BindingSource _buffListBindingSource = new BindingSource();

        private OverlayGroup SelectedGroup =>
            groupList.SelectedIndex >= 0 && groupList.SelectedIndex < _overlayCanvas.Groups.Count
                ? _overlayCanvas.Groups[groupList.SelectedIndex]
                : null;

        private OverlayBuff SelectedBuff => 
            SelectedGroup != null && buffList.SelectedIndex >= 0 && buffList.SelectedIndex < SelectedGroup.TrackedBuffs.Count 
                ? SelectedGroup.TrackedBuffs[buffList.SelectedIndex] 
                : null;
        
        public OverlayEditorForm(Subject subject)
        {
            InitializeComponent();
            
            UpdateGroupList();
            
            subject.Attach(this);
        }

        private void UpdateGroupList()
        {
            groupList.DisplayMember = "DisplayName";
            groupList.DataSource = _groupListBindingSource;
            
            _groupListBindingSource.DataSource = _overlayCanvas.Groups;
            _groupListBindingSource.ResetBindings(false);
        }
        
        private void UpdateSelectedGroup()
        {
            textGroupName.Text = SelectedGroup.GroupName;
            textGroupPosX.Text = SelectedGroup.Position.X.ToString();
            textGroupPosY.Text = SelectedGroup.Position.Y.ToString();
            textGroupSize.Text = SelectedGroup.Size.ToString();
            textGroupSpacing.Text = SelectedGroup.Spacing.ToString();
            checkBoxVertical.Checked = SelectedGroup.VerticalFirst;
            checkBoxGrowLeft.Checked = SelectedGroup.GrowLeft;
            checkBoxGrowUp.Checked = SelectedGroup.GrowUp;
            textMaxElementsX.Text = SelectedGroup.MaxElementsX.ToString();
            textMaxElementsY.Text = SelectedGroup.MaxElementsY.ToString();
            checkBoxGroupEnabled.Checked = SelectedGroup.Enabled;

            buffList.DisplayMember = "DisplayName";
            buffList.DataSource = _buffListBindingSource;
            
            _buffListBindingSource.DataSource = SelectedGroup.TrackedBuffs;
            _buffListBindingSource.ResetBindings(false);
        }

        private void UpdateSelectedBuff()
        {
            textBuffId.Text = SelectedBuff.BuffID.ToString();
            textBuffIcon.Text = SelectedBuff.IconId;
            checkBoxBuffShowActive.Checked = SelectedBuff.ShowActive;
            
            pictureBuffIcon.Image = SelectedBuff.Icon;
        }

        private void ApplyGroupListChanges()
        {
            var canvas = ProfileSingleton.GetCurrent().OverlayCanvas;
            ProfileSingleton.SetConfiguration(canvas);
            _groupListBindingSource.ResetBindings(false);

            canvas.MarkDirty();
        }

        private void ApplyBuffListChanges()
        {
            var canvas = ProfileSingleton.GetCurrent().OverlayCanvas;
            ProfileSingleton.SetConfiguration(canvas);
            _buffListBindingSource.ResetBindings(false);
            
            canvas.MarkDirty();
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.TURN_ON:
                    _overlayCanvas.Start();
                    break;
                case MessageCode.TURN_OFF:
                    _overlayCanvas.Stop();
                    break;
                case MessageCode.PROFILE_CHANGED:
                    _overlayCanvas = ProfileSingleton.GetCurrent().OverlayCanvas;
                    UpdateGroupList();
                    break;
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            _overlayCanvas.Groups.Add(new OverlayGroup());
            ApplyGroupListChanges();
            groupList.SelectedIndex = _overlayCanvas.Groups.Count - 1;
            groupList_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var groups = _overlayCanvas.Groups;
            var selectedIndex = groupList.SelectedIndex;
            var groupsCount = groups.Count;
            
            if(groupsCount == 0 || selectedIndex >= groupsCount) return;
            
            var dialogResult = MessageBox.Show(
                $"Are you sure you want to remove the group: \"{SelectedGroup.GroupName}\"?\nThis cannot be undone!",
                "Remove group", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                groups.RemoveAt(selectedIndex);
                ApplyGroupListChanges();

                if (selectedIndex == groupsCount)
                {
                    groupList.SelectedIndex--;
                    groupList_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        private void groupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedGroup();
        }

        private void textGroupName_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            SelectedGroup.GroupName = textGroupName.Text;
            ApplyGroupListChanges();
        }

        private void textGroupPosX_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var posX = SelectedGroup.Position.X;
            try
            {
                posX = int.Parse(textGroupPosX.Text);
                SelectedGroup.Position.X = posX;
                ApplyGroupListChanges();
            }
            catch
            {
                textGroupPosX.Text = posX.ToString();
            }
        }

        private void textGroupPosY_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var posY = SelectedGroup.Position.Y;
            try
            {
                posY = int.Parse(textGroupPosY.Text);
                SelectedGroup.Position.Y = posY;
                ApplyGroupListChanges();
            }
            catch
            {
                textGroupPosY.Text = posY.ToString();
            }
        }

        private void textGroupSize_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var size = SelectedGroup.Size;
            try
            {
                size = int.Parse(textGroupSize.Text);
                SelectedGroup.Size = Math.Max(size, 8);
                ApplyGroupListChanges();
            }
            catch
            {
                textGroupSize.Text = size.ToString();
            }
        }

        private void textGroupSpacing_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var spacing = SelectedGroup.Spacing;
            try
            {
                spacing = int.Parse(textGroupSpacing.Text);
                SelectedGroup.Spacing = Math.Max(spacing, 0);
                ApplyGroupListChanges();
            }
            catch
            {
                textGroupSpacing.Text = spacing.ToString();
            }
        }

        private void checkBoxVertical_CheckedChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            SelectedGroup.VerticalFirst = checkBoxVertical.Checked;
            ApplyGroupListChanges();
        }

        private void checkBoxGrowLeft_CheckedChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            SelectedGroup.GrowLeft = checkBoxGrowLeft.Checked;
            ApplyGroupListChanges();
        }

        private void checkBoxGrowUp_CheckedChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            SelectedGroup.GrowUp = checkBoxGrowUp.Checked;
            ApplyGroupListChanges();
        }

        private void textMaxElementsX_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var maxElementsX = SelectedGroup.MaxElementsX;
            try
            {
                maxElementsX = int.Parse(textMaxElementsX.Text);
                SelectedGroup.MaxElementsX = Math.Max(maxElementsX, 1);
                ApplyGroupListChanges();
            }
            catch
            {
                textMaxElementsX.Text = maxElementsX.ToString();
            }
        }

        private void textMaxElementsY_TextChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var maxElementsY = SelectedGroup.MaxElementsY;
            try
            {
                maxElementsY = int.Parse(textMaxElementsY.Text);
                SelectedGroup.MaxElementsY = Math.Max(maxElementsY, 1);
                ApplyGroupListChanges();
            }
            catch
            {
                textMaxElementsY.Text = maxElementsY.ToString();
            }
        }

        private void buffList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedBuff();
        }
        
        private void btnAddBuff_Click(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            SelectedGroup.AddBuff(new OverlayBuff());
            ApplyBuffListChanges();
            buffList.SelectedIndex = SelectedGroup.TrackedBuffs.Count - 1;
            buffList_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void btnRemoveBuff_Click(object sender, EventArgs e)
        {
            if(SelectedGroup == null || SelectedBuff == null) return;
            
            var buffs = SelectedGroup.TrackedBuffs;
            var selectedIndex = buffList.SelectedIndex;
            var buffsCount = buffs.Count;
            
            if(buffsCount == 0 || selectedIndex >= buffsCount) return;
            
            var dialogResult = MessageBox.Show(
                $"Are you sure you want to remove the buff: \"{SelectedBuff.DisplayName}\"?\nThis cannot be undone!",
                "Remove buff", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                buffs.RemoveAt(selectedIndex);
                ApplyBuffListChanges();
                
                if (selectedIndex == buffsCount)
                {
                    buffList.SelectedIndex--;
                    buffList_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
        }

        private void btnApplyBuffChanges_Click(object sender, EventArgs e)
        {
            if(SelectedBuff == null) return;
            
            if (Enum.TryParse(textBuffId.Text, out EffectStatusIDs enumId))
            {
                SelectedBuff.BuffID = (uint) enumId;
            }
            else if (uint.TryParse(textBuffId.Text, out var uintId))
            {
                SelectedBuff.BuffID = uintId;
            }
            
            textBuffId.Text = SelectedBuff.BuffID.ToString();
            
            SelectedBuff.IconId = textBuffIcon.Text;
            SelectedBuff.InvalidateIcon();
            pictureBuffIcon.Image = SelectedBuff.Icon;
            
            SelectedBuff.ShowActive = checkBoxBuffShowActive.Checked;
            
            ApplyBuffListChanges();
        }

        private void btnGroupMoveUp_Click(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var selectedGroupIndex = groupList.SelectedIndex;
            if (selectedGroupIndex > 0)
            {
                (_overlayCanvas.Groups[selectedGroupIndex - 1], _overlayCanvas.Groups[selectedGroupIndex]) = (_overlayCanvas.Groups[selectedGroupIndex], _overlayCanvas.Groups[selectedGroupIndex - 1]);
            }
            ApplyGroupListChanges();
        }

        private void btnGroupMoveDown_Click(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var selectedGroupIndex = groupList.SelectedIndex;
            if (selectedGroupIndex < _overlayCanvas.Groups.Count - 1)
            {
                (_overlayCanvas.Groups[selectedGroupIndex + 1], _overlayCanvas.Groups[selectedGroupIndex]) = (_overlayCanvas.Groups[selectedGroupIndex], _overlayCanvas.Groups[selectedGroupIndex + 1]);
            }
            ApplyGroupListChanges();
        }

        private void btnBuffMoveUp_Click(object sender, EventArgs e)
        {
            if(SelectedBuff == null) return;
            
            var selectedBuffIndex = buffList.SelectedIndex;
            if (selectedBuffIndex > 0)
            {
                (SelectedGroup.TrackedBuffs[selectedBuffIndex - 1], SelectedGroup.TrackedBuffs[selectedBuffIndex]) = (SelectedGroup.TrackedBuffs[selectedBuffIndex], SelectedGroup.TrackedBuffs[selectedBuffIndex - 1]);
                ApplyBuffListChanges();
            }
        }

        private void btnBuffMoveDown_Click(object sender, EventArgs e)
        {
            if(SelectedBuff == null) return;
            
            var selectedBuffIndex = buffList.SelectedIndex;
            if (selectedBuffIndex < SelectedGroup.TrackedBuffs.Count - 1)
            {
                (SelectedGroup.TrackedBuffs[selectedBuffIndex + 1], SelectedGroup.TrackedBuffs[selectedBuffIndex]) = (SelectedGroup.TrackedBuffs[selectedBuffIndex], SelectedGroup.TrackedBuffs[selectedBuffIndex + 1]);
                ApplyBuffListChanges();
            }
        }

        private void checkBoxGroupEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            SelectedGroup.Enabled = checkBoxGroupEnabled.Checked;
            ApplyGroupListChanges();
        }

        private void btnGroupExport_Click(object sender, EventArgs e)
        {
            if(SelectedGroup == null) return;
            
            var exportString = JsonConvert.SerializeObject(SelectedGroup);
            Clipboard.SetText(exportString);
            MessageBox.Show("Group copied to the clipboard!");
        }

        private void btnGroupImport_Click(object sender, EventArgs e)
        {
            var importedString = Clipboard.GetText();

            if (string.IsNullOrEmpty(importedString))
            {
                MessageBox.Show("Please copy a group string to the clipboard!");
            }

            try
            {
                var importedGroup = JsonConvert.DeserializeObject<OverlayGroup>(importedString);
                
                var dialogResult = MessageBox.Show(
                    $"Are you sure you want to import the group: \"{importedGroup.GroupName}\"?", "Import Group", MessageBoxButtons.YesNo);

                if (dialogResult != DialogResult.Yes) return;
                
                _overlayCanvas.Groups.Add(importedGroup);
                ApplyGroupListChanges();
            }
            catch
            {
                MessageBox.Show("Something went wrong when importing the group.");
            }
        }

        private int _start = 0;
        private int _size = 1024;

        private void SetStart_TextChanged(object sender, EventArgs e)
        {
	        if (int.TryParse(SetStart.Text, out var startValue))
	        {
		        _start = startValue;
	        }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
	        if (int.TryParse(SetEnd.Text, out var size))
	        {
		        _size = size;
	        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
	        Console.WriteLine($"Dumping from {_start}, To {_start + _size}");

	        var client = ClientSingleton.GetClient();
	        if (client == null) return;

	        for (var i = 0; i < _size; i++)
	        {
		        var curAddress = _start + i * 4;
		        var curValue = client.ReadMemory(curAddress);
		        Console.WriteLine($"{curValue} at address {curAddress}");
	        }
        }
    }
}