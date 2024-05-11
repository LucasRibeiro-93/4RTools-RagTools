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
        private OverlayBuff SelectedBuff => SelectedGroup.TrackedBuffs[buffList.SelectedIndex];
        
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

        private void btnGroupMoveUp_Click(object sender, EventArgs e)
        {
            var selectedGroupIndex = groupList.SelectedIndex;
            if (selectedGroupIndex > 0)
            {
                (_overlayCanvas.Groups[selectedGroupIndex - 1], _overlayCanvas.Groups[selectedGroupIndex]) = (_overlayCanvas.Groups[selectedGroupIndex], _overlayCanvas.Groups[selectedGroupIndex - 1]);
            }
            ApplyGroupListChanges();
        }

        private void btnGroupMoveDown_Click(object sender, EventArgs e)
        {
            var selectedGroupIndex = groupList.SelectedIndex;
            if (selectedGroupIndex < _overlayCanvas.Groups.Count - 1)
            {
                (_overlayCanvas.Groups[selectedGroupIndex + 1], _overlayCanvas.Groups[selectedGroupIndex]) = (_overlayCanvas.Groups[selectedGroupIndex], _overlayCanvas.Groups[selectedGroupIndex + 1]);
            }
            ApplyGroupListChanges();
        }

        private void btnBuffMoveUp_Click(object sender, EventArgs e)
        {
            var selectedBuffIndex = buffList.SelectedIndex;
            if (selectedBuffIndex > 0)
            {
                (SelectedGroup.TrackedBuffs[selectedBuffIndex - 1], SelectedGroup.TrackedBuffs[selectedBuffIndex]) = (SelectedGroup.TrackedBuffs[selectedBuffIndex], SelectedGroup.TrackedBuffs[selectedBuffIndex - 1]);
                ApplyBuffListChanges();
            }
        }

        private void btnBuffMoveDown_Click(object sender, EventArgs e)
        {
            var selectedBuffIndex = buffList.SelectedIndex;
            if (selectedBuffIndex < SelectedGroup.TrackedBuffs.Count - 1)
            {
                (SelectedGroup.TrackedBuffs[selectedBuffIndex + 1], SelectedGroup.TrackedBuffs[selectedBuffIndex]) = (SelectedGroup.TrackedBuffs[selectedBuffIndex], SelectedGroup.TrackedBuffs[selectedBuffIndex + 1]);
                ApplyBuffListChanges();
            }
        }

        private uint[] _memDump = new uint[1024];
        private void button1_Click(object sender, EventArgs e)
        {
	        var client = ClientSingleton.GetClient();
	        var address = client.currentHPBaseAddress - 4096 * 4 + 440 * 4;
	        //Console.WriteLine($"{Enum.GetName(typeof(AmmoIDs), ammoID)} id: {ammoID} is equipped");

	        var start = address - 256;
	        for (int i = 0; i < _memDump.Length; i++)
	        {
		        var curAddress = start + i * 4;
		        var curMem = client.ReadMemory(curAddress);

		        if (curAddress == address)
		        {
			        Console.WriteLine($"{curMem} at address: AMMO ADDRESS");
			        continue;
		        }
		        
		        if (curAddress == 15249388)
		        {
			        Console.WriteLine($"{curMem} at address: ARMOR!!");
			        continue;
		        }
		        
		        if (curAddress == 15248964)
		        {
			        Console.WriteLine($"{curMem} at address: GARMENT!!");
			        continue;
		        }
		        
		        if (curAddress == 15248716)
		        {
			        Console.WriteLine($"{curMem} at address: RIGHT HAND!!");
			        continue;
		        }
		        
		        if (curAddress == 15248740)
		        {
			        Console.WriteLine($"{curMem} at address: IS THIS LEFT???");
			        continue;
		        }
		        
		        if (curAddress == 15249188)
		        {
			        Console.WriteLine($"{curMem} at address: RIGHT ACCESSORY!!");
			        continue;
		        }
		        
		        if (curAddress == 15250060)
		        {
			        Console.WriteLine($"{curMem} at address: LEFT ACCESSORY!!");
			        continue;
		        }
		        
		        if (curAddress == 15249612)
		        {
			        Console.WriteLine($"{curMem} at address: SHIELD!!");
			        continue;
		        }
		        
		        if (curAddress == 15250284)
		        {
			        Console.WriteLine($"{curMem} at address: HELM!!");
			        continue;
		        }
		        
		        Console.WriteLine($"{curMem} at address: {curAddress}");
		        
		        continue;
		        
		        if (i == address) Console.WriteLine("inventory ID equipped ammo address at " + address);
		        if (i == client.currentHPBaseAddress) Console.WriteLine("HP base address at " + client.currentHPBaseAddress);
		        
		        //if (curMem == 4294967295) continue;
		        //if (curMem == 0) continue;

		        //if (curMem == 1750) Console.WriteLine($"found arrow at {i}");
		        if (curMem == 1751) Console.WriteLine($"6 :found silver arrow at {i}");
		        if (curMem == 1752) Console.WriteLine($"1 :found fire arrow at {i}");
		        if (curMem == 1756) Console.WriteLine($"2 :found stone arrow at {i}");
		        if (curMem == 1753) Console.WriteLine($"3 :found steel arrow at {i}");
		        if (curMem == 1755) Console.WriteLine($"4 :found wind arrow at {i}");
		        if (curMem == 1765) Console.WriteLine($"5 :found oridecon arrow at {i}");
		        //if (curMem == 1767) Console.WriteLine($"found shadow arrow at {i}");
		        if (curMem == 1763) Console.WriteLine($"0 :found poison arrow at {i}");
		        //if (curMem == 1764) Console.WriteLine($"found sharp arrow at {i}");
		        //if (curMem == 1761) Console.WriteLine($"found cursed arrow at {i}");
		        if (curMem == 1769) Console.WriteLine($"7 :found mute arrow at {i}");
	        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
	        Console.WriteLine("Comparing Memory");
	        var client = ClientSingleton.GetClient();
	        for (int i = 0; i < _memDump.Length; i++)
	        {
		        var curBuff = client.CurrentBuffStatusCode(i);
		        if (curBuff != _memDump[i])
		        {
			        //Console.WriteLine($"{curBuff.ToString()} is now {_memDump[i].ToString()} at address {i}");
		        }
	        }
        }
    }
}