using System;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Overlay;
using _4RTools.Utils;

namespace _4RTools.Forms
{
    public partial class OverlayEditorForm : Form, IObserver
    {
        private OverlayCanvas _overlayCanvas = new OverlayCanvas();
        
        private BindingSource _groupListBindingSource = new BindingSource();
        private BindingSource _buffListBindingSource = new BindingSource();

        private OverlayGroup SelectedGroup => _overlayCanvas.Groups[groupList.SelectedIndex];
        private OverlayBuff SelectedBuff => SelectedGroup._trackedBuffs[buffList.SelectedIndex];
        
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

            buffList.DisplayMember = "DisplayName";
            buffList.DataSource = _buffListBindingSource;
            
            _buffListBindingSource.DataSource = SelectedGroup._trackedBuffs;
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
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().OverlayCanvas);
            _groupListBindingSource.ResetBindings(false);
        }

        private void ApplyBuffListChanges()
        {
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().OverlayCanvas);
            _buffListBindingSource.ResetBindings(false);
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
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void groupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedGroup();
        }

        private void textGroupName_TextChanged(object sender, EventArgs e)
        {
            SelectedGroup.GroupName = textGroupName.Text;
            ApplyGroupListChanges();
        }

        private void textGroupPosX_TextChanged(object sender, EventArgs e)
        {
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
            SelectedGroup.VerticalFirst = checkBoxVertical.Checked;
            ApplyGroupListChanges();
        }

        private void checkBoxGrowLeft_CheckedChanged(object sender, EventArgs e)
        {
            SelectedGroup.GrowLeft = checkBoxGrowLeft.Checked;
            ApplyGroupListChanges();
        }

        private void checkBoxGrowUp_CheckedChanged(object sender, EventArgs e)
        {
            SelectedGroup.GrowUp = checkBoxGrowUp.Checked;
            ApplyGroupListChanges();
        }

        private void textMaxElementsX_TextChanged(object sender, EventArgs e)
        {
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
            SelectedGroup.AddBuff(new OverlayBuff());
            ApplyBuffListChanges();
        }

        private void btnRemoveBuff_Click(object sender, EventArgs e)
        {
            var buffs = SelectedGroup._trackedBuffs;
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
            }
        }

        private void btnApplyBuffChanges_Click(object sender, EventArgs e)
        {
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
    }
}